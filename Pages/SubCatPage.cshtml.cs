using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumWeb.Models;
using ForumWeb.Models.IModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumWeb.Pages
{
    public class SubCatPageModel : PageModel
    {
        private readonly ICategory _categoryGateway;
        private readonly ISubCategory _subCatGateway;

        public SubCatPageModel(ICategory categoryGateway, ISubCategory subCatGateway)
        {
            _categoryGateway = categoryGateway;
            _subCatGateway = subCatGateway;
        }

        public List<Category> Categories { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public async Task OnGetAsync(Guid categoryId)
        {
            Categories = await _categoryGateway.GetCategories();

            SubCategories = await _subCatGateway.GetAllSubCategoriesById(categoryId);

        }
    }
}
