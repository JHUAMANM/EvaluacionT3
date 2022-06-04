using HUAMAN_T3.WEB.DB.Mapping;
using HUAMAN_T3.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace HUAMAN_T3.WEB.DB;

public class DbEntities: DbContext
{
    public virtual DbSet<Veterinaria> Veterinarias { get; set; }

    public DbEntities() { }
    public DbEntities(DbContextOptions<DbEntities> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new VeterinariaMapping());
    }
}