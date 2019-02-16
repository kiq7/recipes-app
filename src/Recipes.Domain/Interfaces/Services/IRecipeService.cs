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
    }
}