using Microsoft.EntityFrameworkCore;
using SAI.Core.Entities;
using SAI.Core.Interfaces.Repositories;
using SAI.Infrastructure.Persistence;

namespace SAI.Infrastructure.Repositories;

public class SearchAttributeRepository(AppDbContext context) : ISearchAttributeRepository
{
    public async Task<SearchAttribute?> GetByIdAsync(Guid id)
    {
        return await context.SearchAttributes
            .Include(x => x.Options)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<SearchAttribute>> GetAllAsync()
    {
        return await context.SearchAttributes.Include(x=>x.Options).ToListAsync();
    }

    public async Task AddAsync(SearchAttribute entity)
    {
        await context.SearchAttributes.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SearchAttribute entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(SearchAttribute entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
}