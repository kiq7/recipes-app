using System;
using System.Collections.Generic;
using System.Linq;
using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Repository;
using Recipes.Domain.Interfaces.Services;

namespace Recipes.Domain.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _repository;

        public IngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public void Add(Ingredient ingredient)
        {
            _repository.Add(ingredient);
            _repository.SaveChanges();
        }

        public Ingredient GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _repository.GetAll().OrderBy(recipe => recipe.Name);
        }
    }
}