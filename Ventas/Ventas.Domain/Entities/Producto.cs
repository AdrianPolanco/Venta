
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Producto : AuditEntity
    {

        public int idProducto { get; set; }

        public string? nombre { get; set; }
        public int idCategoria { get; set; }

        public int stock { get; set; }  

        public decimal precio { get; set; }
        public bool? esActivo { get; set; }


        /*
       [idProducto]
      ,[nombre]
      ,[idCategoria]
      ,[stock]
      ,[precio]
      ,[esActivo]
      ,[fechaRegistro].


      ,[IdUsuarioCreacion]
      ,[FechaMod]
      ,[IdUsuarioMod]
      ,[IdUsuarioElimino]
      ,[FechaElimino]
      ,[Eliminado]
         */
    }
}
