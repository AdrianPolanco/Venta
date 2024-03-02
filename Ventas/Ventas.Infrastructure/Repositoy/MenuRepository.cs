
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repositoy
{
    public class MenuRepository : IMenuRepository
    {
        private readonly VentaContext context;
        public MenuRepository(VentaContext context)
        {
            this.context = context;
        }
        public void Create(Menu menu)
        {

            try
            {

                this.context.Menu.Add(menu);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }


            
        }

        public List<Menu> Getmenu()
        {

          
            return this.context.Menu.ToList();
        }

        public Menu? GetMenu(int IdMenu)
        {
            return this.context.Menu.Find(IdMenu);
        }

        public void Remove(Menu menu)
        {

            try
            {

                var menuToRemove = this.GetMenu(menu.IdMenu);



                this.context.Menu.Update(menu);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }
           
           

            //this.context.Menu.Remove(menu);
        }

        public void Update(Menu menu)
        {


            try
            {

                var menuToUpdate = this.GetMenu(menu.IdMenu);


                this.context.Menu.Update(menu);
                this.context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw ex;

            }
       
        }
    }
}
