using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhoWebAPI2.Models
{
    public class Entity<T>: IEntity<T>
    {
        public virtual T Id { get; set; } 
    }
}