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
        }

        public Post Post { get; set; }

        [BindProperty]
        public Comment NewComment { get; set; }
        public List<Comment> CommentList { get; set; }

        public ForumWebUser CurrentUser { get; set; }
        public Guid PostId { get; set; }


        public async Task OnGetAsync(Guid postId)
        {
            Post = await _postGateway.GetOnePostByPostId(postId);

            CommentList = await _commentGateway.GetCommentsByPostId(postId);
            PostId = postId;


            CurrentUser = await _userManager.GetUserAsync(User);

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
