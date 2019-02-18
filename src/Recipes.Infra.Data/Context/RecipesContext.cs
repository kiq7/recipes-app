using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Recipes.Domain.Entities;
using Recipes.Infra.Data.Mappings;

namespace Recipes.Infra.Data.Context
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> context)
            : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeMap());
            modelBuilder.ApplyConfiguration(new IngredientMap());

            modelBuilder.Entity<RecipeIngredient>().HasKey(sc => new { sc.RecipeId, sc.IngredientId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(sc => sc.Ingredient)
                .WithMany(s => s.RecipeIngredients)
                .HasForeignKey(sc => sc.IngredientId);


            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(sc => sc.Recipe)
                .WithMany(s => s.Ingredients)
                .HasForeignKey(sc => sc.RecipeId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}