
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    { 
        
      //List<CategoriaModels> GetsCategoryForUser (int categoriaId);

    }
}
