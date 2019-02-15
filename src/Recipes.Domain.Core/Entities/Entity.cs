using System;
using Flunt.Notifications;

namespace Recipes.Domain.Core.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; protected set; }
    }
}
