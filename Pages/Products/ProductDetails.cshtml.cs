using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ware_HW3.Data;
using Ware_HW3.Models;

namespace Ware_HW3.Pages.Products
{
        public class ProductDetailsModel : PageModel
        {
            private readonly IProductRepository _productRepository;

            public ProductDetailsModel(IProductRepository prodRepository)
            {
                _productRepository = prodRepository;
            }

            public Product product { get; set; }
            public void OnGet(int productID)
            {
                product = _productRepository.GetProductsByProductId(productID);
            }
        }
}
