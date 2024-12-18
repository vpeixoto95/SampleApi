using Microsoft.EntityFrameworkCore;
using SampleApi.Data.Entities;

namespace SampleApi.Data;

public class SampleApiDbContext : DbContext
{
    public SampleApiDbContext(DbContextOptions<SampleApiDbContext> options) : base(options) { }

    internal virtual DbSet<Record> Records { get; set; }
}
