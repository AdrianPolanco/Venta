    
using Ventas.Domain.Entities.Categoria;
using Ventas.Domain.Repository;

namespace Ventas.Infrastructure.Interfaces
{
    public interface ICategoriaRepository
    {
        void Create(Categoria categoria);
        void Update(Categoria categoria);
        void Remove (Categoria categoria);
        
        List<Categoria> GetCategorias();
        Categoria GetCategoria(int categoriaId);

    }
}
