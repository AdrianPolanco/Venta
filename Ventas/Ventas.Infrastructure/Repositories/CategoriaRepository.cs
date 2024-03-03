

using Microsoft.Extensions.Logging;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Interfaces;


namespace Ventas.Infrastructure.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository 
    {
        private readonly VentaContext context;
        private readonly ILogger<CategoriaRepository> logger;

        

        public CategoriaRepository(VentaContext context, ILogger<CategoriaRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Categoria> GetEntities()
        {
            return base.GetEntities().Where(ca => (bool)!ca.eliminado).ToList();
        }

        public override void Update(Categoria entity)
        {
            try
            {
                var categoryToUpdate = this.GetEntity(entity.categoria_id);
                if (categoryToUpdate == null)
                {
                    throw new CategoryException("La categoría no se encuentra registrada.");
                }

                categoryToUpdate.categoria_Nombre = entity.categoria_Nombre;
                categoryToUpdate.categoria_Activo = true;
                categoryToUpdate.idUsuarioModificacion = entity.idUsuarioModificacion;
                categoryToUpdate.fechaModificiacion = entity.fechaModificiacion;

                this.context.Categoria.Update(categoryToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error modificando la categoria", ex.ToString());
            }
        }

        public override void Save(Categoria entity)
        {
            try
            {
                if (context.Categoria.Any(ca => ca.categoria_Nombre == entity.categoria_Nombre))
                    throw new CategoryException("La categoria se encuentra registrada");

                this.context.SaveChanges();
                this.context.Categoria.Add(entity);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error guardando la categoria", ex.ToString());
            }
        }



    }
}
