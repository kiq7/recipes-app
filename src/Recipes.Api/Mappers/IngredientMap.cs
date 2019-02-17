using System;
using AutoMapper;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Recipes.Api.ViewModels;
using Recipes.Domain.Entities;

namespace Recipes.Api.Mappers
{
    public class IngredientMap : Profile
    {
        public IngredientMap()
        {
            CreateMap<Ingredient, IngredientViewModel>();
            CreateMap<IngredientViewModel, RecipeIngredient>()
                .ForMember(x => x.IngredientId, y => y.MapFrom(z => z.Id));
        }
    }
}