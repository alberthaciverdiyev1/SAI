using SAI.Core.DTOs.Parser;
using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Entities;

namespace SAI.Core.Interfaces.Services;

public interface ILlmService
{
    Task<ParsedSearchDto> ParseUserIntent(string userMessage, IEnumerable<SearchAttribute> allAttributes);
}