

using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class DocumentNumber : AuditBaseEntity
    {

        public int? idNumeroDocumento { get; set; }
        public int? ultimo_Numero { get; set; } = 0;
       
        
       
        
    }
      
}
