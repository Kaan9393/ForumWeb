using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    public interface IMessage
    {
        Task<List<Message>> GetMessages();
        Task<List<Message>> GetMessageByUserId(Guid messageToUserId);
        Task<Message> PostMessage(Message message);
        Task DeleteMessage(Guid messageId);
    }
}
