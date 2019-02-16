using System;
using Flunt.Notifications;

namespace Recipes.Domain.Core.Entities
{
    public class Entity : Notifiable
    {
        public Guid Id { get; set; }
    }
}
