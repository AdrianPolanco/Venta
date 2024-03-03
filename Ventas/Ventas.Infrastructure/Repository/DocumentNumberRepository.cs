using Microsoft.EntityFrameworkCore;
using System.Linq;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{

    public class DocumentNumberRepository : BaseRepository<DocumentNumber >, IDocumentNumberRepository
    {

        
        public DocumentNumberRepository(ApplicationDbContext context) : base(context) 
        {
            
        }

        public override void update(DocumentNumber entity)
        {
            base.update(entity);
        }

        override 











        /// <summary>
        /// Creando una venta en la BD
        /// </summary>
        /// <param name="documentNumber">Venta que se quiere crear</param>
        /// <returns>Venta creada</returns>


        public async Task<DocumentNumber> Create(DocumentNumber documentNumber)
        {


            try
            {
                if (documentNumber == null) 
                    throw new DocumentNumberException ("El numero de documento se encuentra regitrado ");
                        
                await context.NumeroDocumento.AddAsync(documentNumber);
                await context.SaveChangesAsync();
                return documentNumber;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Borrando NumeroDocumento, en caso de que exista
        /// </summary>
        /// <param name="documentNumber">El NumeroDocumento que se quiere eliminar</param>
        /// <returns>Venta borrada</returns>
        public async Task<DocumentNumber?> Delete(DocumentNumber documentNumber)
        {
            bool documentNumberExists = context.NumeroDocumento.Any<DocumentNumber>(d => d.idNumeroDocumento == documentNumber.idNumeroDocumento);
            if (!documentNumberExists) return null;

            context.NumeroDocumento.Remove(documentNumber);
            await context.SaveChangesAsync();
            return documentNumber;
        }

        /// <summary>
        /// Obteniendo NumeroDocumento por su id
        /// </summary>
        /// <param name="id">Id del NumeroDocumento que se quiere obtener</param>
        /// <returns>NumeroDocumento coincidente con el id</returns>
        public async Task<DocumentNumber?> GetNumeroDocumento(int id)
        {
            bool documentNumberExists = context.NumeroDocumento.Any<DocumentNumber>(d => d.idNumeroDocumento == id);
            if (!documentNumberExists) return null;

            DocumentNumber foundDocumentNumber = await context.NumeroDocumento.FindAsync(id);

            return foundDocumentNumber;
        }

        /// <summary>
        /// Obteniendo todas los NumeroDocumentos existentes
        /// </summary>
        /// <returns>Todas los NumeroDocumentos</returns>
        public async Task<List<DocumentNumber>> GetNumeroDocumentos()
        {
            List<DocumentNumber> documentNumbers = await context.NumeroDocumento.ToListAsync();
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
            bool documentNumberExists = context.NumeroDocumento.Any<DocumentNumber>(d => d.idNumeroDocumento == currentNumeroDocumentoId);
            if (!documentNumberExists) return null;

            DocumentNumber foundDocumentNumber = await context.NumeroDocumento.FindAsync(currentNumeroDocumentoId);

            foundDocumentNumber.idNumeroDocumento = numeroDocumento.idNumeroDocumento;
            foundDocumentNumber.ultimo_Numero = numeroDocumento.ultimo_Numero;
            foundDocumentNumber.FechaMod = numeroDocumento.FechaMod;
            foundDocumentNumber.FechaElimino = numeroDocumento.FechaElimino;
            foundDocumentNumber.fechaRegistro = numeroDocumento.fechaRegistro;


            await context.SaveChangesAsync();

            return foundDocumentNumber;
        }
    }


}
