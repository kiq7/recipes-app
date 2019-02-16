using Recipes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Recipes.Api.ViewModels
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set;  }
        public int Serves { get; set; }
        public decimal Calories { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        public string Directions { get; set; }
    }
}
