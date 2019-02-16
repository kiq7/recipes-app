using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Recipes.Infra.Data.Mappings;

namespace Recipes.Infra.Data.Context
{
    public class RecipesContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}