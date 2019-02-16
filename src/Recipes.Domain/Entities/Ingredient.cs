using System;
using System.Collections.Generic;
using Flunt.Validations;
using Recipes.Domain.Core.Entities;

namespace Recipes.Domain.Entities
{
    public class Ingredient : Entity
    {
        public Ingredient() { }

        public Ingredient(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public string Name { get; private set; }
        public List<RecipeIngredient> RecipeIngredients{ get; private set; }


    }
}