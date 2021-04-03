using BlogCore.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
       public Task<IEnumerable<SelectListItem>> GetCategoryList();
    }
}
