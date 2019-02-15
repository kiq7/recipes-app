using System;
using System.Collections.Generic;
using Flunt.Validations;
using Recipes.Domain.Core.Entities;

namespace Recipes.Domain.Entities
{
    public class Recipe : Entity
    {
        public Recipe(string name, int serves, decimal calories, List<Ingredient> ingredients, string directions)
        {
            Name = name;
            Serves = serves;
            Calories = calories;
            Ingredients = ingredients;
            Directions = directions;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "A receita deve ter um nome.")
                .IsNotNullOrEmpty(Directions, "Directions", "A receita deve ter um modo de preparo.")
                .IsGreaterOrEqualsThan(Serves, 0, "Serves", "Quantidade de porções deve ser maior que zero.")
                .IsGreaterThan(Calories, 0, "Calories", "Calorias deve ser maior que zero.")
                .IsNotNull(Ingredients, "Ingredients", "A receita deve possuir pelo menos um ingrediente.")
                .IsGreaterThan(Ingredients.Count, 0, "Ingredients", "A receita deve possuir pelo menos um ingrediente."));
        }

        public string Name { get; }
        public int Serves { get; }
        public decimal Calories { get; }
        public List<Ingredient> Ingredients { get; }
        public string Directions { get; }

        internal void SetId(Guid id)
        {
            Id = id;
        }
    }
}