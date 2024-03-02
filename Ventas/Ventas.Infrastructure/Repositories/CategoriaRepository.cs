

using Ventas.Domain.Entities.Categoria;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly VentaContext context;

        public CategoriaRepository(VentaContext context)
        {
            this.context = context;
        }

        public void Create(Categoria categoria)
        {
            try
            {
                if(context.Categoria.Any(ca => ca.categoria_Nombre == categoria.categoria_Nombre)) 
                    throw new CategoryException("La categoria se encuentra registrada");

                this.context.SaveChanges();
                this.context.Categoria.Add(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Categoria> GetCategorias()
        {
            try
            {
                return this.context.Categoria
                                            .Where(ca => !(ca.eliminado ?? false))
                                            .ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Categoria GetCategoria(int categoriaId)
        {
            return this.context.Categoria.Find(categoriaId);
        }

        public void Remove(Categoria categoria)
        {
            try
            {
 
                var categoryToRemove = this.GetCategoria(categoria.categoria_id);
                if (categoryToRemove == null)
                {
                    throw new CategoryException("La categoría no se encuentra registrada.");
                }

                categoryToRemove.eliminado = true;
                categoryToRemove.fechaEliminado = categoria.fechaEliminado;
                categoryToRemove.idUsuarioEliminado = categoria.idUsuarioEliminado;

                this.context.Categoria.Update(categoryToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Categoria categoria)
        {
            try
            {
                var categoryToUpdate = this.GetCategoria(categoria.categoria_id);
                if (categoryToUpdate == null)
                {
                    throw new CategoryException("La categoría no se encuentra registrada.");
                }

                categoryToUpdate.categoria_Nombre = categoria.categoria_Nombre;
                categoryToUpdate.categoria_Activo = true;
                categoryToUpdate.idUsuarioModificacion = categoria.idUsuarioModificacion;
                categoryToUpdate.fechaModificiacion = categoria.fechaModificiacion;

                this.context.Categoria.Update(categoryToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
