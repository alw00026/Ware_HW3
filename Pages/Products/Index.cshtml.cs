using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ware_HW3.Data;
using Ware_HW3.Models;

namespace Ware_HW3.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository productRepository;

        public List<Product> ProductList { get; set; }

        public IndexModel(IProductRepository prodRepos)
        {


            productRepository = prodRepos; 
        }


        public void OnGet(int categoryID)
        {
            ProductList = productRepository.GetProductsByCategoryList(categoryID);
        }

    }
}
