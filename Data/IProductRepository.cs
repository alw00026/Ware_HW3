using Ware_HW3.Models;

namespace Ware_HW3.Data
{
    public interface IProductRepository
    {
        List<Product> GetProductsByCategoryList(int categoryID);

        Product GetProductsByProductId(int productID);

    }
}
