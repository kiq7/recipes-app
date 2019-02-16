using System.Collections.Generic;
using Recipes.Domain.Entities;

namespace Recipes.Domain.Interfaces.Services
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAll();
    }
}