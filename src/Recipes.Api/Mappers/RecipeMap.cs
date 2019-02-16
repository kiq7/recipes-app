using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Recipes.Api.ViewModels;
using Recipes.Domain.Entities;

namespace Recipes.Api.Mappers
{
    public class RecipeMap : Profile
    {
        public RecipeMap()
        {
            CreateMap<Recipe, RecipeViewModel>()
                .ForMember(x => x.Ingredients, y => y.MapFrom(z => ResolveIngredientsToViewModel(z.RecipeIngredients)));
            CreateMap<RecipeViewModel, Recipe>();

            CreateMap<Recipe, AddRecipeViewModel>();
            CreateMap<AddRecipeViewModel, Recipe>()
                .ForMember(x => x.RecipeIngredients, y => y.MapFrom(z => ResolveIngredientsToEntity(z.Ingredients)));
        }

        public List<RecipeIngredient> ResolveIngredientsToEntity(List<Guid> ingredientsId)
        {
            return ingredientsId.Select(x => new RecipeIngredient
            {
                IngredientId = x
            }).ToList();
        }

        public List<IngredientViewModel> ResolveIngredientsToViewModel(List<RecipeIngredient> recipeIngredients)
        {
            return recipeIngredients.Select(x => new IngredientViewModel
            {
                Id = x.IngredientId,
                Name = x.Ingredient.Name
            }).ToList();
        }
    }
}
