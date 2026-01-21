using SAI.Core.DTOs.SearchAttributeOption;
using SAI.Infrastructure.Services;

namespace SAI.Core.Interfaces.Services;

public interface ISearchAttributeOptionService
{
    Task<ServiceResult<bool>> DeleteAsync(Guid id);     
    Task<ServiceResult<SearchAttributeOptionResponse>> AddAsync(SearchAttributeOptionCreateRequest request);
    Task<ServiceResult<SearchAttributeOptionResponse>> UpdateAsync(Guid id,SearchAttributeOptionUpdateRequest request);
}