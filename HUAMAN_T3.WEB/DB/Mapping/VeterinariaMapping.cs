using HUAMAN_T3.WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HUAMAN_T3.WEB.DB.Mapping;

public class VeterinariaMapping: IEntityTypeConfiguration<Veterinaria>
{
    public void Configure(EntityTypeBuilder<Veterinaria> builder)
    {
       
            builder.ToTable("Veterinaria", "dbo");
            builder.HasKey(o => o.Id);
    } 
}