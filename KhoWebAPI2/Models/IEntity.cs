using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoWebAPI2.Models
{
    interface IEntity<T>
    {
        T Id { get; set; }
    }
}
