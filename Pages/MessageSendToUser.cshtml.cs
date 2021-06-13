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
    public class MessageSendToUserModel : PageModel
    {
        private readonly IMessage _messageGateway;
        private readonly UserManager<ForumWebUser> _userManager;

        public MessageSendToUserModel(IMessage messageGateway, UserManager<ForumWebUser> userManager)
        {
            _messageGateway = messageGateway;
            _userManager = userManager;
        }

        public ForumWebUser CurrentUser { get; set; }

        [BindProperty]
        public Message NewMessage { get; set; }

        public ForumWebUser MessageCurrentUserId { get; set; }
        public Guid UserId { get; set; }


        public async Task OnGetAsync(Guid userId)
        {
            MessageCurrentUserId = await _userManager.FindByIdAsync(userId.ToString());
            UserId = userId;


            CurrentUser = await _userManager.GetUserAsync(User);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            NewMessage.Id = Guid.NewGuid();
            NewMessage.Date = DateTime.Now;

            await _messageGateway.PostMessage(NewMessage);

            return RedirectToPage("Index");
        }
    }
}
