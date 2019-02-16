using System;
using System.Collections.Generic;

namespace Recipes.Api.ViewModels
{
    public class AddRecipeViewModel
    {
        public string Name { get; set; }
        public int Serves { get; set; }
        public decimal Calories { get; set; }
        public List<Guid> Ingredients { get; set; }
        public string Directions { get; set; }
    }
}