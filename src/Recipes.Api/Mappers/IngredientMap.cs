using AutoMapper;
using Recipes.Api.ViewModels;
using Recipes.Domain.Entities;

namespace Recipes.Api.Mappers
{
    public class IngredientMap : Profile
    {
        public IngredientMap()
        {
            CreateMap<Ingredient, IngredientViewModel>();
            CreateMap<IngredientViewModel, Ingredient>();
        }
    }
}