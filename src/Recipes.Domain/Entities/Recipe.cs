using System;
using System.Collections.Generic;
using Flunt.Validations;
using Recipes.Domain.Core.Entities;

namespace Recipes.Domain.Entities
{
    public class Recipe : Entity
    {
       public Recipe(string name, int serves, decimal calories, string directions)
        {
            Name = name;
            Serves = serves;
            Calories = calories;
            //RecipeIngredients = recipeIngredients;
            Directions = directions;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "A receita deve ter um nome.")
                .IsNotNullOrEmpty(Directions, "Directions", "A receita deve ter um modo de preparo.")
                .IsGreaterOrEqualsThan(Serves, 0, "Serves", "Quantidade de porções deve ser maior que zero.")
                .IsGreaterThan(Calories, 0, "Calories", "Calorias deve ser maior que zero."));
            //.IsNotNull(RecipeIngredients, "Ingredients", "A receita deve possuir pelo menos um ingrediente.")
            //.IsGreaterThan(RecipeIngredients.Count, 0, "Ingredients", "A receita deve possuir pelo menos um ingrediente."));
        }

        public Recipe()
        {

        }

        public string Name { get; private set; }
        public int Serves { get; private set; }
        public decimal Calories { get; private set; }
        public List<RecipeIngredient> RecipeIngredients { get; private set; }
        public string Directions { get; private set; }

        internal void SetId(Guid id)
        {
            Id = id;
        }
    }
}