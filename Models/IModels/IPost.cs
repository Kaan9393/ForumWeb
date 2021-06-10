using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    public interface IPost
    {
        Task<List<Post>> GetPosts();
        Task<List<Post>> GetPostsBySubCategoryId(Guid subCategoryId);
        Task<Post> GetOnePostByPostId(Guid postId);
        Task<Post> PostPosts(Post post);
        Task PutPost(Guid editId, Post post);
        Task DeletePost(Guid deleteId);
    }
}
