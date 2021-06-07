using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    interface ISubCategory
    {
        Task<List<SubCategory>> GetSubCategories();
        Task<SubCategory> PostSubCategory(SubCategory subCategory);
        Task PutSubCategory(int editId, SubCategory subCategory);
        Task<SubCategory> DeleteSubCategory(int deleteId);
    }
}
