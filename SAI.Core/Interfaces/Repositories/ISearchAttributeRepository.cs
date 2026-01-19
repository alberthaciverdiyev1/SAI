using SAI.Core.DTOs.SearchAttribute;
using SAI.Core.Entities;

namespace SAI.Core.Interfaces.Repositories;

public interface ISearchAttributeRepository
{
    Task<SearchAttribute?> GetByIdAsync(Guid id);
    Task<IEnumerable<SearchAttribute>> GetAllAsync();
    Task AddAsync(SearchAttribute entity);
    Task UpdateAsync(SearchAttribute entity);
    Task DeleteAsync(SearchAttribute entity);
}