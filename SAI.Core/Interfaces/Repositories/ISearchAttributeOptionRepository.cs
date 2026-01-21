using SAI.Core.Entities;

namespace SAI.Core.Interfaces.Repositories;

public interface ISearchAttributeOptionRepository
{
    Task AddAsync(SearchAttributeOption entity);
    Task UpdateAsync(SearchAttributeOption entity);
    Task<SearchAttributeOption?> GetByIdAsync(Guid id);
    Task DeleteAsync(SearchAttributeOption entity);
}