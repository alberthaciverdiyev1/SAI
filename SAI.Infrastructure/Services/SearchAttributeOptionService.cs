using System.Net;
using SAI.Core.DTOs.SearchAttributeOption;
using SAI.Core.Entities;
using SAI.Core.Interfaces.Repositories;
using SAI.Core.Interfaces.Services;

namespace SAI.Infrastructure.Services;

public class SearchAttributeOptionService(ISearchAttributeOptionRepository repository) : ISearchAttributeOptionService
{
    public async Task<ServiceResult<SearchAttributeOptionResponse>> AddAsync(SearchAttributeOptionCreateRequest request)
    {
        var option = new SearchAttributeOption
        {
            SearchAttributeId = request.SearchAttributeId,
            Value = request.Value,
            ValueId = request.ValueId
        };

        await repository.AddAsync(option);
        var response =
            new SearchAttributeOptionResponse(option.Id, option.SearchAttributeId, option.Value, option.ValueId);
        return ServiceResult<SearchAttributeOptionResponse>.Success(response, HttpStatusCode.Created);
    }

    public async Task<ServiceResult<SearchAttributeOptionResponse>> UpdateAsync(Guid id,
        SearchAttributeOptionUpdateRequest request)
    {
        var attribute = await repository.GetByIdAsync(id);
        if (attribute is null)
        {
            return ServiceResult<SearchAttributeOptionResponse>.Fail($"Attribute with id {id} not found", HttpStatusCode.NotFound);
        }
        attribute.Value = request.Value;
        attribute.ValueId = request.ValueId;
        await repository.UpdateAsync(attribute);
        return ServiceResult<SearchAttributeOptionResponse>.Success(new SearchAttributeOptionResponse(attribute.Id, attribute.SearchAttributeId, attribute.Value, attribute.ValueId));
    }

    public async Task<ServiceResult<bool>> DeleteAsync(Guid id)
    {
        var attribute = await repository.GetByIdAsync(id);
        if (attribute is null)
        {
            return ServiceResult<bool>.Fail($"Attribute with id {id} not found", HttpStatusCode.NotFound);
        }

        await repository.DeleteAsync(attribute);
        return ServiceResult<bool>.Success(true);
    }
}