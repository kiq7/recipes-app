using System;
using System.Collections.Generic;
using Recipes.Domain.Core.Interfaces.Repositories;
using Recipes.Domain.Entities;

namespace Recipes.Domain.Interfaces.Repository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        IEnumerable<Recipe> GetRecipesByUsedIngredient(Guid ingredientId);
        IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId);
    }
}