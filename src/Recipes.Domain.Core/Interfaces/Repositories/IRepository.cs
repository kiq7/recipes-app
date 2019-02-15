using System;
using System.Linq;
using Recipes.Domain.Core.Entities;

namespace Recipes.Domain.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        int SaveChanges();
    }
}