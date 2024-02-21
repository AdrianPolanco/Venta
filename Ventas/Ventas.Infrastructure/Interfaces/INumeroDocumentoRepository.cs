using Ventas.Domain.Entities;
namespace Ventas.Infrastructure.Interfaces
{
    public interface INumeroDocumentoRepository
    {
        Task<NumeroDocumento> Create(NumeroDocumento NumeroDocumento);
        Task<NumeroDocumento?> Update(NumeroDocumento NumeroDocumento, int currentSaleId);
        Task<NumeroDocumento?> Delete(NumeroDocumento NumeroDocumento);

        Task<List<NumeroDocumento>> GetNumeroDocumento();
        Task<NumeroDocumento?> GetNumeroDocumento(int id);
    }
}
