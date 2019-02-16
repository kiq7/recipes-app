using System;

namespace Recipes.Domain.Entities
{
    public class RecipeIngredient
    {
        public RecipeIngredient()
        {
            
        }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}