using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumWeb.Areas.Identity.Data;
using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumWeb.Pages.Admin
{
    public class IndexModel : PageModel
    {

        public ForumWebUser CurrentUser { get; set; }
        public List<Category> Categories { get; set; }

        

        public void OnGet()
        {
            
        }
    }
}
