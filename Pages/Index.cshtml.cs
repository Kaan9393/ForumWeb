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
        private readonly ICategory _categoryGateway;
        private readonly UserManager<ForumWebUser> _userManager;

        public IndexModel(ICategory categoryGateway, UserManager<ForumWebUser> userManager)
        {
            _categoryGateway = categoryGateway;
            _userManager = userManager;
        }

        public ForumWebUser CurrentUser { get; set; }

        public List<Category> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _categoryGateway.GetCategories();
        }


    }
}
