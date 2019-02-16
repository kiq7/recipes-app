using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Recipes.Api.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Domain.Entities;
using Recipes.Infra.Data.Context;
using Recipes.Infra.IoC;

namespace Recipes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<RecipesContext>(context => context.UseInMemoryDatabase("RecipesApp"));

            services.AddCors();
            services.AddMvc();
            services.AddSwaggerDocument(document =>
            {
                document.Title = "Recipes API";
            });

            services.AddAutoMapper(mapper =>
            {
                mapper.AddProfile(new RecipeMap());
                mapper.AddProfile(new IngredientMap());
            });

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
           
            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi3();


            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RecipesContext>();
                SeedIngredientsData(context);
            }
            
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }

        private static void SeedIngredientsData(DbContext context)
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient("Leite em pó"),
                new Ingredient("Leite condensado"),
                new Ingredient("Ovos"),
                new Ingredient("Açucar"),
                new Ingredient("Chocolate em pó"),
                new Ingredient("Agua"),
                new Ingredient("Farinha de trigo"),
                new Ingredient("Coco ralado"),
                new Ingredient("Creme de leite"),
                new Ingredient("Sal"),
                new Ingredient("Óleo"),
                new Ingredient("Fermento em pó"),
                new Ingredient("Margarina"),
                new Ingredient("Chocolate derretido"),
            };


            context.AddRange(ingredients);
            context.SaveChanges();
        }
    }
}
