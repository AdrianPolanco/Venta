
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
            this.context.Menu.Add(menu);
        }

        public List<Menu> Getmenu()
        {

            //me quede aqui
            throw new NotImplementedException();
        }

        public Menu GetMenu(int IdMenu)
        {
            throw new NotImplementedException();
        }

        public void Remove(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
