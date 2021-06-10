using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumWeb.Areas.Identity.Data;
using ForumWeb.Models;
using ForumWeb.Models.IModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForumWeb.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ICategory _categoryGateway;
        private readonly ISubCategory _subCatGateway;

        private readonly UserManager<ForumWebUser> _userManager;


        public IndexModel(ICategory categoryGateway, UserManager<ForumWebUser> userManager, ISubCategory subCatGateway)
        {
            _userManager = userManager;
            _categoryGateway = categoryGateway;
            _subCatGateway = subCatGateway;
        }
        public ForumWebUser CurrentUser { get; set; }



        //CATEGORY
        public List<Category> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid DeleteCatId { get; set; }

        [BindProperty]
        public Category NewCategory { get; set; }


        //SUBCATEGORY
        public List<SubCategory> SubCategories { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid DeleteSubCatId { get; set; }

        [BindProperty]
        public SubCategory NewSubCategory { get; set; }


        public SelectList SelectList { get; set; }

        //[BindProperty]
        //public Guid SelectedCatId { get; set; }



        public async Task OnGetAsync()
        {
            if (DeleteCatId != Guid.Empty)
            {
                await _categoryGateway.DeleteCategory(DeleteCatId);
            }
            Categories = await _categoryGateway.GetCategories();

            if (DeleteSubCatId != Guid.Empty)
            {
                await _subCatGateway.DeleteSubCategory(DeleteSubCatId);
            }

            SelectList = new SelectList(Categories, "Id", "Text");

            SubCategories = await _subCatGateway.GetSubCategories();

        }

        public async Task<IActionResult> OnPostCategoryAdd()
        {
            NewCategory.Id = Guid.NewGuid();
            await _categoryGateway.PostCategory(NewCategory);


            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostSubCategoryAddAsync()
        {

            NewSubCategory.Id = Guid.NewGuid();
            await _subCatGateway.PostSubCategory(NewSubCategory);


            return RedirectToPage("./Index");
        }
    }
}
