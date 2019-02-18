using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Repository;
using Recipes.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Infra.Data.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipesContext context)
            : base(context)
        {
        }

        public IEnumerable<Recipe> GetRecipesByUsedIngredient(Guid ingredientId)
        {
            return _dbSet
                .Include(x => x.Ingredients)
                    .ThenInclude(y => y.Ingredient)
                .Where(x => x.Ingredients.Any(ingredient => ingredient.IngredientId == ingredientId));
        }

        public IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId)
        {
            return _dbSet
                .Include(x => x.Ingredients)
                    .ThenInclude(y => y.Ingredient)
                .FirstOrDefault(x => x.Id == recipeId)?.Ingredients.Select(x => x.Ingredient);
        }

        public override IQueryable<Recipe> GetAll()
        {
            return _dbSet
                .Include(x => x.Ingredients)
                    .ThenInclude(y => y.Ingredient)
                .AsQueryable();
        }

        public override Recipe GetById(Guid id)
        {
            return _dbSet
                .Include(x => x.Ingredients)
                    .ThenInclude(y => y.Ingredient)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}