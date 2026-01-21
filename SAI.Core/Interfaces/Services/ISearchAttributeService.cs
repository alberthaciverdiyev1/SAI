using SAI.Core.DTOs.SearchAttribute;
using SAI.Infrastructure.Services;

namespace SAI.Core.Interfaces.Services;

public interface ISearchAttributeService
{
    Task<ServiceResult<SearchAttributeResponse>> CreateAsync(SearchAttributeCreateRequest request);
    Task<ServiceResult<SearchAttributeResponse>> UpdateAsync(Guid id, SearchAttributeUpdateRequest request);
    Task<ServiceResult<bool>> DeleteAsync(Guid id);
    Task<ServiceResult<SearchAttributeResponse>> GetByIdAsync(Guid id);
    Task<ServiceResult<IEnumerable<SearchAttributeResponse>>> GetAllAsync();
}