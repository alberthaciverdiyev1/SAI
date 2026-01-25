using SAI.Core.DTOs.Parser;
using SAI.Core.Interfaces.Repositories;
using SAI.Core.Interfaces.Services;

namespace SAI.Infrastructure.Services;

public class SearchQueryBuilderService(ISearchAttributeRepository attributeRepository, ILlmService llmService)
{
    public async Task<ServiceResult<string>> BuildSearchUrl(string userMessage)
    {
        string message = "mene bakida satilan junyor islerini tap maasi 3000 pilus olsun";
        userMessage = message.ToLower();
        
        var attributes = await attributeRepository.GetAllAsync();

        ParsedSearchDto parsedData = await llmService.ParseUserIntent(userMessage, attributes);

        var queryParams = new List<string>();

        // // 3. AI'dan gelen her filtreyi DB'deki ID'si ile eşleştir
        // foreach (var filter in parsedData.Filters)
        // {
        //     var attr = attributes.FirstOrDefault(a => a.Key == filter.Key);
        //     var option = attr?.Options.FirstOrDefault(o => o.Value == filter.Value);
        //
        //     if (option != null)
        //     {
        //         // Senin istediğin format: cityId=28
        //         queryParams.Add($"{attr.Key.ToLower()}Id={option.ValueId}");
        //     }
        // }
        //
        // // 4. Maaş gibi statik alanları ekle
        // if (parsedData.MinSalary > 0) queryParams.Add($"minSalary={parsedData.MinSalary}");

        string url= "/vakansiyalar?" + string.Join("&", queryParams);
        
        return ServiceResult<string>.Success(url);
    }
}