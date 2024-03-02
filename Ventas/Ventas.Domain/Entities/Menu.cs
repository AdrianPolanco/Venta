using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Menu : BaseEntity
    {
       
        public string icono { get; set; }  
        public string url { get; set;}
    }
}
