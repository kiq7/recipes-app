using System;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Domain.Interfaces.Repository;
using Recipes.Domain.Interfaces.Services;
using Recipes.Domain.Services;
using Recipes.Infra.Data.Context;
using Recipes.Infra.Data.Repositories;

namespace Recipes.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<RecipesContext>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeService, RecipeService>();
        }
    }
}
