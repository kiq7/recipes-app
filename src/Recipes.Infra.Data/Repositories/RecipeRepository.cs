using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Repository;
using Recipes.Infra.Data.Context;

namespace Recipes.Infra.Data.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipesContext context)
            : base(context)
        {
        }
    }
}