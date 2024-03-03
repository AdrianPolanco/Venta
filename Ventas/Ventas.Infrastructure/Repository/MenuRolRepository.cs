using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repository
{
    public class MenuRolRepository : IMenuRolRepository
    {
        private readonly VentasContext context;
        public MenuRolRepository(VentasContext context)
        {
            
        }
        public void Create(MenuRol menuRol)
        {
            try
            {
                this.context.MenuRol.Add(menuRol);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MenuRol> GetMenuRol(MenuRol menuRol)
        {
            return this.context.MenuRol.ToList();
        }

        public MenuRol GetMenuRol(int idMenuRol)
        {
            return this.context.MenuRol.Find(idMenuRol); 
        }

        public void Remove(MenuRol menuRol)
        {
            try
            {
                var menuRolToRemove = this.GetMenuRol(menuRol.menuRol);

                menuRolToRemove.deleted = true;
                menuRolToRemove.delete_date = menuRol.delete_date;
                menuRolToRemove.delete_user = menuRol.delete_user;

                this.context.MenuRol.Update(menuRolToRemove):
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
                
             


  
            //this.context.MenuRol.Remove(menuRol);
        }

        public void Update(MenuRol menuRol)
        {
            try
            {
                var menuRolToUpdate = this.GetMenuRol(menuRol.menuRol);

                menuRolToUpdate.menuRolName = menuRol.Name;
                menuRolToUpdate.description = menuRol.Description;
                menuRolToUpdate.modify_user = menuRol.modify_user;
                menuRolToUpdate.modify_date = menuRol.modify_date;



                this.context.MenuRol.Update(menuRolToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
