using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    public interface IComment
    {
        Task<List<Comment>> GetComments();
        Task<List<Comment>> GetCommentsByPostId(Guid postId);
        Task<Comment> PostComment(Comment comment);
        Task PutComment(Guid editId, Comment comment);
        Task DeleteComment(Guid deleteId);
    }
}
