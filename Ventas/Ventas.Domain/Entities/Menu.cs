using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Menu: BaseEntityA
    {

        public string icono { get; set; }
        public string url { get; set; }
    }
}
