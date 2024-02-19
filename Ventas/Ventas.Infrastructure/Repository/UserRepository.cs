
using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) {
            _context = context;
        }
        /// <summary>
        /// Creando usuario en la BD
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>Usuario creado</returns>
        public async Task<User> Create(User user)
        {
                await _context.Usuario.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
        }

        /// <summary>
        /// Actualizando el usuario, en caso de que exista
        /// </summary>
        /// <param name="user">Los nuevos datos que tendra el usuario</param>
        /// <param name="currentUserId">El id del usuario que se quiere actualizar</param>
        /// <returns>Usuario actualizado</returns>
        public async Task<User?> Update(User user, int currentUserId)
        {
            bool userExists = _context.Usuario.Any<User>(u => u.idUsuario == currentUserId);
            if (!userExists) return null;

            User foundUser = await _context.Usuario.FindAsync(currentUserId);

            foundUser.nombreCompleto = user.nombreCompleto;
            foundUser.correo = user.correo;
            foundUser.idRol = user.idRol;
            foundUser.clave = user.clave;
            foundUser.esActivo = user.esActivo;

            await _context.SaveChangesAsync();

            return foundUser;
        }

        /// <summary>
        /// Borrando un usuario, en caso de que exista
        /// </summary>
        /// <param name="user">El usuario que se quiere eliminar</param>
        /// <returns>Usuario borrado</returns>
        public async Task<User?> Delete(User user)
        {
            bool userExists = _context.Usuario.Any<User>(u => u.idUsuario == user.idUsuario);
            if (!userExists) return null;

            _context.Usuario.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Obteniendo un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario que se quiere obtener</param>
        /// <returns>Usuario coincidente con el id</returns>
        public async Task<User?> GetUser(int id)
        {
            bool userExists = _context.Usuario.Any<User>(u => u.idUsuario == id);

            if (!userExists) return null;

            User foundUser = await _context.Usuario.FindAsync(id);

            return foundUser;
        }

        /// <summary>
        /// Obteniendo todos los usuarios existentes
        /// </summary>
        /// <returns>Todos los usuarios existentes</returns>
        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _context.Usuario.ToListAsync();
            return users;
        }

    }
}
