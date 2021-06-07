using ForumWeb.Areas.Identity.Data;
using ForumWeb.Gateway;
using ForumWeb.Models;
using ForumWeb.Models.IModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForumWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ICategory _categoryGateway;
        private readonly UserManager<ForumWebUser> _userManager;

        public List<Category> categories;

        public ForumWebUser MyUser { get; set; }

        [BindProperty]
        public Category NewOrChangedCategory { get; set; }


        public IndexModel(ILogger<IndexModel> logger, UserManager<ForumWebUser> userManager ,ICategory categoryGateway)
        {
            _logger = logger;
            _userManager = userManager;
            _categoryGateway = categoryGateway;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            MyUser = await _userManager.GetUserAsync(User);
            return Page();
            //categories = await _categoryGateway.GetCategories();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryGateway.PostCategory(NewOrChangedCategory);

            return RedirectToPage("./Index");
        }
    }
}
