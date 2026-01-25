using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SAI.Core.DTOs.Parser;
using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Entities;
using SAI.Core.Interfaces.Services;

namespace SAI.Infrastructure.Services;

public class DeepSeekR1Service(HttpClient httpClient) : ILlmService
{
    public async Task<ParsedSearchDto> ParseUserIntent(string userMessage, IEnumerable<SearchAttribute> allAttributes)
    {
        var filterSchema = allAttributes.Select(a => 
            $"- {a.Key}: Options [{string.Join(", ", a.Options.Select(o => $"{o.Value} (value: {o.ValueId})"))}]");
        
        string schemaString = string.Join("\n", filterSchema);

        string prompt = $@"### GÖREV
                            Sen profesyonel bir veri eşleştirme asistanısın. Kullanıcı mesajındaki anahtar kelimeleri aşağıdaki şema ile eşleştir.

                            ### KESİN KURALLAR
                            1. SADECE kullanıcı mesajında açıkça geçen bilgileri eşleştir. Mesajda yoksa asla uydurma.
                            2. 'Filters' sözlüğünde Key olarak şemadaki anahtarı, Value olarak ise parantez içindeki ID değerini yaz.
                            3. Bir anahtar için sadece tek bir ID döndür. Liste/Dizi (Array) kullanma.
                            4. Mesajda fiyat belirtilmemişse MinSalary ve MaxSalary değerlerini 0 bırak.
                            5. Mesajda fiyat MinSalary belirtilmişse ve MaxSalary belirtilmemişse hez zaman MaxSalary max degeri alsin.
                            6. <think> bloklarını veya açıklamaları asla dahil etme, sadece saf JSON döndür.

                            ### FİLTRE ŞEMASI (Eşleştirme Listesi)
                            {schemaString}

                            ### ÖRNEK ANALİZ
                            Mesaj: ""Bakıda ucuz telefonlar""
                            Çıktı: {{ ""Filters"": {{ ""city"": ""12"", ""category"": ""5"" }}, ""MinSalary"": 0, ""MaxSalary"": 0, ""Sort"": ""asc"" }}

                            ### ANALİZ EDİLECEK VERİ
                            Kullanıcı Mesajı: ""{userMessage}""

                            JSON ÇIKTISI:";

        var requestBody = new
        {
            model = "deepseek-r1:8b",
            prompt = prompt,
            stream = false,
            format = "json",
            options = new {
                temperature = 0.0, 
                top_p = 0.1,
                seed = 42
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("api/generate", content);    
        
        if (!response.IsSuccessStatusCode)
            return new ParsedSearchDto();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        
        using var doc = JsonDocument.Parse(jsonResponse);
        string aiContent = doc.RootElement.GetProperty("response").GetString();

        if (aiContent.Contains("</think>"))
        {
            aiContent = aiContent.Split("</think>").Last().Trim();
        }

        try 
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<ParsedSearchDto>(aiContent, options);
            
            return result ?? new ParsedSearchDto();
        }
        catch (JsonException)
        {
            return new ParsedSearchDto(); 
        }
    }
}