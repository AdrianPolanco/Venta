
using Microsoft.EntityFrameworkCore;
using Ventas.Application.Contracts.Repositories;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;


namespace Ventas.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        /// <summary>
        /// Actualizando el usuario, en caso de que exista
        /// </summary>
        /// <param name="user">Los nuevos datos que tendra el usuario</param>
        /// <param name="currentUserId">El id del usuario que se quiere actualizar</param>
        /// <returns>Usuario actualizado</returns>
        public override async Task<User?> Update(User user, int currentUserId)
        {
            try
            {
                bool userExists = await base.Exists(u => u.idUsuario == currentUserId);
                if (!userExists) return null;

                User foundUser = await _dbContext.Usuario.FindAsync(currentUserId);

                if(foundUser.Eliminado == true) return null;

                foundUser.nombreCompleto = user.nombreCompleto;
                foundUser.correo = user.correo;
                foundUser.idRol = user.idRol;
                foundUser.clave = user.clave;
                foundUser.esActivo = user.esActivo;
                foundUser.FechaMod = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return foundUser;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Borrando un usuario, en caso de que exista
        /// </summary>
        /// <param name="user">El usuario que se quiere eliminar</param>
        /// <returns>Usuario borrado</returns>
        public override async Task<User?> Delete(int id)
        {
            try
            {
                bool userExists = await base.Exists(u => u.idUsuario == id);
                if (!userExists) return null;

                User deletedUser = await base.GetEntity(id);

                if (deletedUser.Eliminado is not null) return null;

                deletedUser.FechaElimino = DateTime.Now;
                deletedUser.Eliminado = true;
                deletedUser.esActivo = false;

                await _dbContext.SaveChangesAsync();

                return deletedUser;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public override async Task<List<User?>> GetEntities()
        {
            try
            {
                IQueryable<User> usersQuery = _dbSet.Where(u => u.Eliminado != true);
                List<User?> users = await usersQuery.ToListAsync();

                return users;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obteniendo un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario que se quiere obtener</param>
        /// <returns>Usuario coincidente con el id</returns>
        public override async Task<User?> GetEntity(int id)
        {
            bool userExists = await base.Exists(u => u.idUsuario == id);

            if (!userExists) return null;

            User foundUser = await _dbSet.Where(u => u.idUsuario == id).Include(u => u.Role).FirstAsync();

            return foundUser;
        }

        public async Task<List<User>> GetByName(bool isDescending)
        {
            try
            {

                List<User> users;

                if (!isDescending)
                {
                    users = await _dbContext.Usuario.OrderBy(u => u.nombreCompleto).ToListAsync();
                }
                else
                {
                    users = users = await _dbContext.Usuario.OrderByDescending(u => u.nombreCompleto).ToListAsync();
                }

                return users;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<User>> GetByRole(bool isDescending)
        {
            try
            {
                List<User> users;

                if (!isDescending)
                {
                    users = await _dbContext.Usuario.OrderBy(u => u.idRol).ToListAsync();
                }
                else
                {
                    users = users = await _dbContext.Usuario.OrderByDescending(u => u.idRol).ToListAsync();
                }

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> GetByDate(bool isDescending)
        {
            try
            {
                List<User> users;

                if (!isDescending)
                {
                    users = await _dbContext.Usuario.OrderBy(u => u.fechaRegistro).ToListAsync();
                }
                else
                {
                    users = users = await _dbContext.Usuario.OrderByDescending(u => u.fechaRegistro).ToListAsync();
                }

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}