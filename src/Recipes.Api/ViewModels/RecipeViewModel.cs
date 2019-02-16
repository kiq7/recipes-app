using Recipes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Recipes.Api.ViewModels
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public int Serves { get; }
        public decimal Calories { get; }
        public List<Ingredient> Ingredients { get; }
        public string Directions { get; }
    }
}
