using AutoMapper;
using Recipes.Api.ViewModels;
using Recipes.Domain.Entities;

namespace Recipes.Api.Mappers
{
    public class RecipeMap : Profile
    {
        public RecipeMap()
        {
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<RecipeViewModel, Recipe>();
        }
    }
}
