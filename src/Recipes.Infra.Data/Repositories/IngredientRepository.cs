using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Repository;
using Recipes.Infra.Data.Context;

namespace Recipes.Infra.Data.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RecipesContext context) : base(context)
        {
        }
    }
}