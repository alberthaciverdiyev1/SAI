using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Entities;
using SAI.Core.Interfaces.Repositories;
using SAI.Core.Interfaces.Services;
using System.Net;

namespace SAI.Infrastructure.Services;

public class SearchAttributeService(ISearchAttributeRepository repository) : ISearchAttributeService
{
    public async Task<ServiceResult<SearchAttributeResponse>> CreateAsync(SearchAttributeCreateRequest request)
    {
        var attribute = new SearchAttribute
        {
            Key = request.Key
        };

        await repository.AddAsync(attribute);

        var response = new SearchAttributeResponse(
            attribute.Id,
            attribute.Key,
            attribute.Options.Select(x => x.Value)
        );

        return ServiceResult<SearchAttributeResponse>.Success(response, HttpStatusCode.Created);
    }

    public async Task<ServiceResult<SearchAttributeResponse>> UpdateAsync(Guid id, SearchAttributeUpdateRequest request)
    {
        var attribute = await repository.GetByIdAsync(id);
        if (attribute == null)
            return ServiceResult<SearchAttributeResponse>.Fail($"Attribute with id {id} not found", HttpStatusCode.NotFound);

        attribute.Key = request.Key;
        await repository.UpdateAsync(attribute);

        var response = new SearchAttributeResponse(
            attribute.Id,
            attribute.Key,
            attribute.Options.Select(x => x.Value)
        );

        return ServiceResult<SearchAttributeResponse>.Success(response);
    }

    public async Task<ServiceResult<bool>> DeleteAsync(Guid id)
    {
        var attribute = await repository.GetByIdAsync(id);
        if (attribute == null)
            return ServiceResult<bool>.Fail($"Attribute with id {id} not found", HttpStatusCode.NotFound);

        await repository.DeleteAsync(attribute);
        return ServiceResult<bool>.Success(true, HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<SearchAttributeResponse>?> GetByIdAsync(Guid id)
    {
        var attribute = await repository.GetByIdAsync(id);
        if (attribute == null)
            return ServiceResult<SearchAttributeResponse>.Fail($"Attribute with id {id} not found", HttpStatusCode.NotFound);

        var response = new SearchAttributeResponse(
            attribute.Id,
            attribute.Key,
            attribute.Options.Select(x => x.Value)
        );

        return ServiceResult<SearchAttributeResponse>.Success(response);
    }

    public async Task<ServiceResult<IEnumerable<SearchAttributeResponse>>> GetAllAsync()
    {
        var attributes = await repository.GetAllAsync();

        if (!attributes.Any())
            return ServiceResult<IEnumerable<SearchAttributeResponse>>.Fail("No search attributes found", HttpStatusCode.NotFound);

        var responses = attributes.Select(x => new SearchAttributeResponse(
            x.Id,
            x.Key,
            x.Options.Select(y => y.Value)
        ));

        return ServiceResult<IEnumerable<SearchAttributeResponse>>.Success(responses);
    }
}
