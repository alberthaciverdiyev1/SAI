using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Entities;
using SAI.Core.Interfaces.Repositories;
using SAI.Core.Interfaces.Services;

namespace SAI.Infrastructure.Services;

public class SearchAttributeService(ISearchAttributeRepository repository) : ISearchAttributeService
{
    public async Task<SearchAttributeResponse> CreateAsync(SearchAttributeCreateRequest request)
    {
        var attribute = new SearchAttribute
        {
            Key = request.Key
        };

        await repository.AddAsync(attribute);
        return new SearchAttributeResponse(attribute.Id, attribute.Key, attribute.Options.Select(x => x.Value));
    }

    public async Task<SearchAttributeResponse> UpdateAsync(Guid id, SearchAttributeUpdateRequest request)
    {
        var attribute = await repository.GetByIdAsync(id);
        if (attribute is null) return null;

        attribute.Key = request.Key;
        await repository.UpdateAsync(attribute);
        return new SearchAttributeResponse(attribute.Id, attribute.Key, attribute.Options.Select(x => x.Value));
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var attribute = await repository.GetByIdAsync(id);
        if (attribute is null) return false;

        await repository.DeleteAsync(attribute);
        return true;
    }

    public async Task<SearchAttributeResponse?> GetByIdAsync(Guid id)
    {
        var attributes = await repository.GetByIdAsync(id);
         if(attributes is null) return null;

         return new SearchAttributeResponse(attributes.Id, attributes.Key, attributes.Options.Select(x => x.Value));
    }

    public async Task<IEnumerable<SearchAttributeResponse>> GetAllAsync()
    {
        var attributes = await repository.GetAllAsync();
        
        return attributes.Select(x => new SearchAttributeResponse(x.Id, x.Key, x.Options.Select(y => y.Value)));
    }
}