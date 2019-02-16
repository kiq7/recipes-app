using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipes.Domain.Entities;

namespace Recipes.Infra.Data.Mappings
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {



            // Ignore flunt properties
            builder.Ignore(x => x.Valid);
            builder.Ignore(x => x.Invalid);
            builder.Ignore(x => x.Notifications);
        }
    }
}