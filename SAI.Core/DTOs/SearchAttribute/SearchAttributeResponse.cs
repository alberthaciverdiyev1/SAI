namespace SAI.Core.DTOs.SearchAttribute;

public record SearchAttributeResponse(Guid Id,string Key,IEnumerable<string> Options);