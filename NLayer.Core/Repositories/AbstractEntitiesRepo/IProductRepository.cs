using NLayer.Core.Entities;

namespace NLayer.Core.Repositories.AbstractEntitiesRepo
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategory();
    }
}
