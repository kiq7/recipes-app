using System;
using System.Collections.Generic;
using System.Linq;
using Recipes.Domain.Entities;
using Xunit;
using FluentAssertions;

namespace Recipes.Domain.Tests
{
    public class RecipeTests
    {
        private readonly string _name;
        private readonly int _serves;
        private readonly decimal _calories;
        private readonly List<RecipeIngredient> _recipeIngredients;
        private readonly string _directions;

        public RecipeTests()
        {
            _name = "My cake test";
            _serves = 30;
            _calories = 60;
            _recipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient
                {
                    IngredientId = Guid.NewGuid()
                }
            };
            _directions = "My recipe directions";
        }
        
        [Fact]
        public void ShouldReturnErrorWhenRecipeHasNoName()
        {
            var recipe = new Recipe(string.Empty, _serves, _calories, _directions, _recipeIngredients);
            recipe.Invalid.Should().BeTrue();
            recipe.Notifications.Should().HaveCount(1);
            recipe.Notifications.FirstOrDefault()?.Property.Should().Be(nameof(recipe.Name));
        }
        
        [Fact]
        public void ShouldReturnErrorWhenRecipeHasZeroServes()
        {
            var recipe = new Recipe(_name, 0, _calories, _directions, _recipeIngredients);
            recipe.Invalid.Should().BeTrue();
            recipe.Notifications.Should().HaveCount(1);
            recipe.Notifications.FirstOrDefault()?.Property.Should().Be(nameof(recipe.Serves));
        }
        
        [Fact]
        public void ShouldReturnErrorWhenRecipeHasNoDirections()
        {
            var recipe = new Recipe(_name, _serves, _calories, string.Empty, _recipeIngredients);
            recipe.Invalid.Should().BeTrue();
            recipe.Notifications.Should().HaveCount(1);
            recipe.Notifications.FirstOrDefault()?.Property.Should().Be(nameof(recipe.Directions));
        }
        
        [Fact]
        public void ShouldReturnErrorWhenRecipeHasNoIngredients()
        {
            var recipe = new Recipe(_name, _serves, _calories, _directions, new List<RecipeIngredient>());
            recipe.Invalid.Should().BeTrue();
            recipe.Notifications.Should().HaveCount(1);
            recipe.Notifications.FirstOrDefault()?.Property.Should().Be(nameof(recipe.Ingredients));
        }
    }
}