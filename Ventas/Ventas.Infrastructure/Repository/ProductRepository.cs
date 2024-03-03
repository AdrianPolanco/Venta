using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
       public ProductRepository(ApplicationDbContext context) : base(context) { }

        public override List<Product> GetEntities()
        {
            return base.GetEntities();//.Where(pr => pr.).ToList();
        }



        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetProductsBySupplier(int supplierId)
        {
            throw new NotImplementedException();
        }
    }
}


