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
    public class MessageUserModel : PageModel
    {
        private readonly IMessage _messageGateway;
        private readonly UserManager<ForumWebUser> _userManager;

        public MessageUserModel(IMessage messageGateway, UserManager<ForumWebUser> userManager)
        {
            _messageGateway = messageGateway;
            _userManager = userManager;
            MessageList = new List<UserMessageModel>();
        }

        public Guid UserId { get; set; }

        [BindProperty]
        public Message NewMessage { get; set; }

        public List<UserMessageModel> MessageList { get; set; }

        public class UserMessageModel
        {
            public Guid Id { get; set; }
            public ForumWebUser CurrentUser { get; set; }
            public ForumWebUser FromUser { get; set; }
            public DateTime Date { get; set; }
            public string Text { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(Guid userId)
        {
            UserId = userId;

            var messageList = await _messageGateway.GetMessageByUserId(userId);

            foreach (var item in messageList)
            {
                var itemsInMessageList = new UserMessageModel
                {
                    Id = item.Id,
                    Date = item.Date,
                    Text = item.Text,
                    CurrentUser = await _userManager.FindByIdAsync(item.MessageToUser.ToString()),
                    FromUser = await _userManager.FindByIdAsync(item.MessageFromUser.ToString())
                };
                MessageList.Add(itemsInMessageList);
            }

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
           
        //}
    }
}
