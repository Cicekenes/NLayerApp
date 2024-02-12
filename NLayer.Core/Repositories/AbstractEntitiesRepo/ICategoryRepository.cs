using NLayer.Core.Entities;

namespace NLayer.Core.Repositories.AbstractEntitiesRepo
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
