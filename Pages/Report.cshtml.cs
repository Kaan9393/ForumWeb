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
    public class ReportModel : PageModel
    {
        private readonly IReport _reportGateway;
        private readonly IComment _commentGateway;
        private readonly IPost _postGateway;
        private readonly UserManager<ForumWebUser> _userManager;

        public ReportModel(IReport reportGateway ,IComment commentGateway,IPost postGateway, UserManager<ForumWebUser> userManager)
        {
            _reportGateway = reportGateway;
            _commentGateway = commentGateway;
            _postGateway = postGateway;
            _userManager = userManager;
        }

        public ForumWebUser CurrentUser { get; set; }
        public Comment NewComment { get; set; }
        public Post NewPost { get; set; }

        [BindProperty]
        public Report NewReport { get; set; }


        [BindProperty(SupportsGet = true)]
        public Guid CommentId { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid PostId { get; set; }



        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            if (PostId != Guid.Empty)
            {
                NewPost = await _postGateway.GetOnePostByPostId(PostId);
            }

            if (CommentId != Guid.Empty)
            {
                NewComment = await _commentGateway.GetOneCommentById(CommentId);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            NewReport.Id = Guid.NewGuid();
            NewReport.Date = DateTime.Now;

            await _reportGateway.PostReport(NewReport);

            return RedirectToPage("Index");
        }
    }
}
