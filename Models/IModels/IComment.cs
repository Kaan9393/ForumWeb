using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    interface IComment
    {
        Task<List<Comment>> GetComments();
        Task<Comment> PostComment(Comment comment);
        Task PutComment(int editId, Comment comment);
        Task<Comment> DeleteComment(int deleteId);
    }
}
