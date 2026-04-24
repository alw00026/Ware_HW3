using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ware_HW3.Data;
using Ware_HW3.Models;

namespace Ware_HW3.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository categoryRepository;
        public List<Category> CategoryList { get; set; }

        public IndexModel(ICategoryRepository catRepos)
        {


            categoryRepository = catRepos; 
        }


        public void OnGet()
        {
            CategoryList = categoryRepository.GetCategoryList();
        }

    }
}
