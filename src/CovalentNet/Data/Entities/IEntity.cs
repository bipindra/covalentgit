using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CovalentNet.Data.Entities
{
    public interface IEntityBase<T>
    {
       
        T Id { get; set; }
    }
}
