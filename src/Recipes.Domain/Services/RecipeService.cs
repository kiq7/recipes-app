using System;
using System.Collections.Generic;
using System.Linq;
using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Repository;
using Recipes.Domain.Interfaces.Services;

namespace Recipes.Domain.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public void Add(Recipe recipe)
        {
            recipe.SetId(Guid.NewGuid());

            recipe.RecipeIngredients.ForEach(x => x.RecipeId = recipe.Id);

            _repository.Add(recipe);
            _repository.SaveChanges();
        }

        public Recipe GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _repository.GetAll().OrderBy(recipe => recipe.Name);
        }

        public IEnumerable<Recipe> GetRecipesByUsedIngredient(Guid ingredientId)
        {
            return _repository.GetRecipesByUsedIngredient(ingredientId);
        }

        public IEnumerable<Ingredient> GetRecipeIngredients(Guid recipeId)
        {
            return _repository.GetRecipeIngredients(recipeId);
        }
    }
}