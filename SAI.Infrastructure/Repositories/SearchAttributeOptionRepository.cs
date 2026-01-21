using SAI.Core.Entities;
using SAI.Core.Interfaces.Repositories;
using SAI.Infrastructure.Persistence;

namespace SAI.Infrastructure.Repositories;

public class SearchAttributeOptionRepository(AppDbContext context) : ISearchAttributeOptionRepository
{
    public async Task AddAsync(SearchAttributeOption entity)
    {
        await context.SearchAttributeOptions.AddAsync(entity);
    }

    public async Task UpdateAsync(SearchAttributeOption entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<SearchAttributeOption?> GetByIdAsync(Guid id)
    {
        return await context.FindAsync<SearchAttributeOption>(id);
    }

    public async Task DeleteAsync(SearchAttributeOption entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
}