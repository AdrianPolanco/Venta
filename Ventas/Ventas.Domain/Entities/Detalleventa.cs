using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Detalleventa: BaseEntityB
    {

        public int producto {  get; set; }
        public int cantidad {  get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }

    }
}
