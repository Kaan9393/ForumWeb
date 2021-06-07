using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    interface IPost
    {
        Task<List<Post>> GetPosts();
        Task<Post> PostPosts(Post post);
        Task PutPost(int editId, Post post);
        Task<Post> DeletePost(int deleteId);
    }
}
