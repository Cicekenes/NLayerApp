using NLayer.Core.DTOs.ProductDTOs;

namespace NLayer.Core.DTOs.CategoryDTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
