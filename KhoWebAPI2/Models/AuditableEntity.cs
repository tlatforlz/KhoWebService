using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhoWebAPI2.Models
{
    public class AuditableEntity<T> : Entity<T>, IAuditableEntity    
   {
       public DateTime CreatedDate { get; set; }
       public DateTime UpdatedDate { get; set; }
    }
}