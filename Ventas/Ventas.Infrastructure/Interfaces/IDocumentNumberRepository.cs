using Ventas.Domain.Entities;
namespace Ventas.Infrastructure.Interfaces
{
    public interface IDocumentNumberRepository
    {
        Task<DocumentNumber> Create(DocumentNumber NumeroDocumento);
        Task<DocumentNumber?> Update(DocumentNumber NumeroDocumento, int currentNumeroDocumentoId);
        Task<DocumentNumber?> Delete(DocumentNumber NumeroDocumento);

        Task<List<DocumentNumber>> GetNumeroDocumentos();
        Task<DocumentNumber?> GetNumeroDocumento(int id);
    }
}
