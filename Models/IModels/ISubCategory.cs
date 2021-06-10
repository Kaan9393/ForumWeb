using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    public interface ISubCategory
    {
        Task<List<SubCategory>> GetSubCategories();
        Task<List<SubCategory>> GetAllSubCategoriesById(Guid categoryId);
        Task<SubCategory> PostSubCategory(SubCategory subCategory);
        Task PutSubCategory(Guid editId, SubCategory subCategory);
        Task DeleteSubCategory(Guid deleteId);
    }
}
