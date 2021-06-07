﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb.Models.IModels
{
    public interface ICategory
    {
        Task<List<Category>> GetCategories();
        Task<Category> PostCategory(Category category);
        Task PutCategory(int editId, Category category);
        Task<Category> DeleteCategory(int deleteId);
    }
}
