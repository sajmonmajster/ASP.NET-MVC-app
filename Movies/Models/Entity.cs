using System;

namespace Movies.Models
{
    public class Entity<TKey>
    {
        public TKey Id { get; set; }
    }

    public class Entity:Entity<Guid>
    {

    }
}