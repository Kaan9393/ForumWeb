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

namespace ForumWeb.Pages
{
    public class PostPageModel : PageModel
    {
        private readonly IPost _postGateway;
        private readonly UserManager<ForumWebUser> _userManager;

        public PostPageModel(IPost postGateway, UserManager<ForumWebUser> userManager)
        {
            _postGateway = postGateway;
            _userManager = userManager;
        }

        public List<Post> PostList { get; set; }

        [BindProperty]
        public Post NewPost { get; set; }

        //Användaren som gjort posten
        public ForumWebUser CurrentUser { get; set; }



        public Guid SubCatId { get; set; }
        public string UserId { get; set; }

        public async Task OnGetAsync(Guid subCategoryId)
        {
            PostList = await _postGateway.GetPostsBySubCategoryId(subCategoryId);
            SubCatId = subCategoryId;

            CurrentUser = await _userManager.GetUserAsync(User);


        }

        public async Task<IActionResult> OnPostAsync()
        {
            NewPost.Date = DateTime.Now;
            NewPost.Id = Guid.NewGuid();

            //NewPost.User = Guid.NewGuid();
            await _postGateway.PostPosts(NewPost);

            return RedirectToPage(new {subCategoryId = NewPost.SubCategoryId });
        }
    }
}
