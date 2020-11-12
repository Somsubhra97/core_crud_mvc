using CoreServices.Models;
using CoreServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_mvc_crud.Repository
{
    public interface IRepository
    {
        Task<List<Category>> GetCategories();

        Task<List<PostViewModel>> GetPosts();

        Task<PostViewModel> GetPost(int? postId);

        Task<List<PostViewModel>> GetPostsByCategory(int id);
        
        Task<CategoryViewModel> GetCatViewModel(int id);

        Task<int> AddPost(Post post);

        Task<int> DeletePost(int? postId);

        Task UpdatePost(Post post);
    }
}