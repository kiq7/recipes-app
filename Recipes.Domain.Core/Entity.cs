using System;
using Flunt.Notifications;

namespace Recipes.Domain.Core
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; protected set; }
    }
}
