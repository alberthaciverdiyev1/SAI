using SAI.Core.DTOs.SearchAttribute;

namespace SAI.Core.Interfaces.Services;

public interface ISearchAttributeService
{
    Task<SearchAttributeResponse> CreateAsync(SearchAttributeCreateRequest request);
    Task<SearchAttributeResponse> UpdateAsync(Guid id, SearchAttributeUpdateRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<SearchAttributeResponse?> GetByIdAsync(Guid id);
    Task<IEnumerable<SearchAttributeResponse>> GetAllAsync();
}