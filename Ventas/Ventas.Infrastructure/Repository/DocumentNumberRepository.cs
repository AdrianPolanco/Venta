using Microsoft.EntityFrameworkCore;
using System.Linq;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
  
    public class DocumentNumberRepository : IDocumentNumberRepository
    {

        private readonly ApplicationDbContext _context;

        public DocumentNumberRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creando una venta en la BD
        /// </summary>
        /// <param name="documentNumber">Venta que se quiere crear</param>
        /// <returns>Venta creada</returns>


        public async Task<DocumentNumber> Create (DocumentNumber documentNumber)
        {
            await _context.NumeroDocumento.AddAsync(documentNumber);
            await _context.SaveChangesAsync();
            return documentNumber;
        }

        /// <summary>
        /// Borrando NumeroDocumento, en caso de que exista
        /// </summary>
        /// <param name="documentNumber">El NumeroDocumento que se quiere eliminar</param>
        /// <returns>Venta borrada</returns>
        public async Task<DocumentNumber?> Delete(DocumentNumber documentNumber)
        {
            bool documentNumberExists = _context.NumeroDocumento.Any<DocumentNumber>(d => d.idNumeroDocumento == documentNumber.idNumeroDocumento);
            if (!documentNumberExists) return null;

            _context.NumeroDocumento.Remove(documentNumber);
            await _context.SaveChangesAsync();
            return documentNumber;
        }

        /// <summary>
        /// Obteniendo NumeroDocumento por su id
        /// </summary>
        /// <param name="id">Id del NumeroDocumento que se quiere obtener</param>
        /// <returns>NumeroDocumento coincidente con el id</returns>
        public async Task<DocumentNumber?> GetNumeroDocumento(int id)
        {
            bool documentNumberExists = _context.NumeroDocumento.Any<DocumentNumber>(d => d.idNumeroDocumento == id);
            if (!documentNumberExists) return null;

            DocumentNumber foundDocumentNumber = await _context.NumeroDocumento.FindAsync(id);

            return foundDocumentNumber;
        }

        /// <summary>
        /// Obteniendo todas los NumeroDocumentos existentes
        /// </summary>
        /// <returns>Todas los NumeroDocumentos</returns>
        public async Task<List<DocumentNumber>> GetNumeroDocumentos()
        {
            List<DocumentNumber> documentNumbers = await _context.NumeroDocumento.ToListAsync();
            return documentNumbers;
        }

        /// <summary>
        /// Actualizando un NumeroDocumento, en caso de que exista
        /// </summary>
        /// <param name="documentNumber">Los nuevos datos que tendra el NumeroDocumento</param>
        /// <param name="currentDocumentNumberId">El id de el NumeroDocumento que se quiere actualizar</param>
        /// <returns>Venta actualizada</returns>
        /// 
        public async Task<DocumentNumber?> Update(DocumentNumber numeroDocumento, int currentNumeroDocumentoId)
        {
            bool documentNumberExists = _context.NumeroDocumento.Any<DocumentNumber>(d => d.idNumeroDocumento == currentNumeroDocumentoId);
            if (!documentNumberExists) return null;

            DocumentNumber foundDocumentNumber = await _context.NumeroDocumento.FindAsync(currentNumeroDocumentoId);

            foundDocumentNumber.idNumeroDocumento = numeroDocumento.idNumeroDocumento;
            foundDocumentNumber.ultimo_Numero = numeroDocumento.ultimo_Numero;
            foundDocumentNumber.FechaMod = numeroDocumento.FechaMod;
            foundDocumentNumber.FechaElimino = numeroDocumento.FechaElimino;
            foundDocumentNumber.fechaRegistro = numeroDocumento.fechaRegistro;
     
            
            await _context.SaveChangesAsync();

            return foundDocumentNumber;
        }
    }


}
