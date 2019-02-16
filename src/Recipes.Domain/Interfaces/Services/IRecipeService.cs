using System;
using System.Collections.Generic;
using Recipes.Domain.Entities;

namespace Recipes.Domain.Interfaces.Services
{
    public interface IRecipeService
    {
        void Add(Recipe recipe);
        Recipe GetById(Guid id);
        IEnumerable<Recipe> GetAll();
        IEnumerable<Recipe> GetRecipesByUsedIngredient(Guid ingredientId);
        IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId);
    }
}