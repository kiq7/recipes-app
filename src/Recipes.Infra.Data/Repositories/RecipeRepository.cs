using System;
using System.Collections.Generic;
using System.Linq;
using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Repository;
using Recipes.Infra.Data.Context;

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
            return _dbSet.Where(x => x.Ingredients.Any(ingredient => ingredient.Id == ingredientId));
        }

        public IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId)
        {
            return _dbSet.FirstOrDefault(x => x.Id == recipeId)?.Ingredients;
        }
    }
}