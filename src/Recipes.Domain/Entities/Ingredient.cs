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

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "O ingrediente deve ter um nome."));
        }

        public string Name { get; private set; }
        public List<RecipeIngredient> RecipeIngredients{ get; private set; } = new List<RecipeIngredient>();


    }
}