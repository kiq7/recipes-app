using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities;

namespace Recipes.Infra.Data.Mappings
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
               .ToTable("Recipe")
               .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Serves)
                .IsRequired()
                .HasColumnName("Serves");

            builder.Property(x => x.Calories)
                .IsRequired()
                .HasColumnName("Calories");

            builder.Property(x => x.Directions)
                .IsRequired()
                .HasColumnName("Directions");

            // Ignore flunt properties
            builder.Ignore(x => x.Valid);
            builder.Ignore(x => x.Invalid);
            builder.Ignore(x => x.Notifications);
        }
    }
}