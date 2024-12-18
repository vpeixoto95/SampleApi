using Microsoft.EntityFrameworkCore;
using SampleApi.Data.Entities;
using SampleApi.Data.Interfaces;

namespace SampleApi.Data.Repositories;

public class RecordsRepository : IRecordsRepository
{
    private readonly IDbContextFactory<SampleApiDbContext> _contextFactory;

    public RecordsRepository(IDbContextFactory<SampleApiDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Record>> GetAll()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Records.ToListAsync();
    }

    public async Task<Record?> Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Records.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> Create(Record record)
    {
        using var context = _contextFactory.CreateDbContext();
        var entity = new Record
        {
            Name = record.Name,
            Date = record.Date,
        };

        context.Records.Add(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Record?> Update(Record record)
    {
        using var context = _contextFactory.CreateDbContext();
        var entity = await Get(record.Id);
        if (entity == null)
        {
            return null;
        }

        entity.Name = record.Name;
        entity.Date = record.Date;
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var entity = await Get(id);
        if (entity == null)
        {
            return false;
        }

        context.Records.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
}
