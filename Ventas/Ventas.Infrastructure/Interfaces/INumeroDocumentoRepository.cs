using Ventas.Domain.Entities;
namespace Ventas.Infrastructure.Interfaces
{
    public interface INumeroDocumentoRepository
    {
        Task<NumeroDocumento> Create(NumeroDocumento NumeroDocumento);
        Task<NumeroDocumento?> Update(NumeroDocumento NumeroDocumento, int currentNumeroDocumentoId);
        Task<NumeroDocumento?> Delete(NumeroDocumento NumeroDocumento);

        Task<List<NumeroDocumento>> GetNumeroDocumentos();
        Task<NumeroDocumento?> GetNumeroDocumento(int id);
    }
}
