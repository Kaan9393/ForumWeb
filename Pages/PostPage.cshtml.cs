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
            UserList = new List<UserModel>();
        }


        [BindProperty(SupportsGet = true)]
        public Guid DeletePostId { get; set; }

        public List<Post> PostList { get; set; }

        [BindProperty]
        public Post NewPost { get; set; }

        public ForumWebUser CurrentUser { get; set; }

        public Guid SubCatId { get; set; }

        public List<UserModel> UserList { get; set; }

        public class UserModel
        {
            public Guid Id { get; set; }
            public ForumWebUser CreatedUser { get; set; }
            public DateTime Date { get; set; }
            public string Text { get; set; }

        }

        public async Task<IActionResult> OnGetAsync(Guid subCategoryId)
        {
            if (DeletePostId != Guid.Empty)
            {
                await _postGateway.DeletePost(DeletePostId);
                return RedirectToPage("Index");
            }

            PostList = await _postGateway.GetPostsBySubCategoryId(subCategoryId);
            SubCatId = subCategoryId;

            CurrentUser = await _userManager.GetUserAsync(User);

            foreach (var item in PostList)
            {
                var itemsInPostList = new UserModel
                {
                    Id = item.Id,
                    CreatedUser = await _userManager.FindByIdAsync(item.User.ToString()),
                    Date = item.Date,
                    Text = item.Text
                };
                UserList.Add(itemsInPostList);
            }

            return Page();
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
