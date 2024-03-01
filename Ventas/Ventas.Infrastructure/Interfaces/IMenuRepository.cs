using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IMenuRepository
    {


        void Create(Menu menu);
        void Update(Menu menu);
        void Remove(Menu menu);

        List<Menu> Getmenu();

        Menu GetMenu(int IdMenu);
    }
}
