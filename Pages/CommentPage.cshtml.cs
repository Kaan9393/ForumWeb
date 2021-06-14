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
    public class CommentPageModel : PageModel
    {
        private readonly IPost _postGateway;
        private readonly IComment _commentGateway;
        private readonly UserManager<ForumWebUser> _userManager;


        public CommentPageModel(IPost postGateway, IComment commentGateway ,UserManager<ForumWebUser> userManager)
        {
            _postGateway = postGateway;
            _userManager = userManager;
            _commentGateway = commentGateway;
            UserList = new List<UserModel>();
        }

        [BindProperty(SupportsGet = true)]
        public Guid DeleteCommentId { get; set; }

        public Post Post { get; set; }

        [BindProperty]
        public Comment NewComment { get; set; }
        public List<Comment> CommentList { get; set; }

        public ForumWebUser CurrentUser { get; set; }
        public Guid PostId { get; set; }

        public List<UserModel> UserList { get; set; }
        public class UserModel
        {
            public Guid Id { get; set; }
            public ForumWebUser CreatedUser { get; set; }
            public DateTime Date { get; set; }
            public string Text { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(Guid postId)
        {
            if (DeleteCommentId != Guid.Empty)
            {
                await _commentGateway.DeleteComment(DeleteCommentId);
                return RedirectToPage("Index");
            }



            PostId = postId;
            Post = await _postGateway.GetOnePostByPostId(postId);
            CommentList = await _commentGateway.GetCommentsByPostId(postId);

            CurrentUser = await _userManager.GetUserAsync(User);

            foreach (var item in CommentList)
            {
                var itemsInCommentList = new UserModel
                {
                    Id = item.Id,
                    CreatedUser = await _userManager.FindByIdAsync(item.User.ToString()),
                    Date = item.Date,
                    Text = item.Text
                };
                UserList.Add(itemsInCommentList);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            NewComment.Date = DateTime.Now;
            NewComment.Id = Guid.NewGuid();

            await _commentGateway.PostComment(NewComment);

            return RedirectToPage(new { postId = NewComment.PostId });
        }
    }
}
