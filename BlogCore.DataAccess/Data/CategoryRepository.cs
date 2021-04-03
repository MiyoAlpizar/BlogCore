using AutoMapper;
using BlogCore.DataAccess.Data.Repository;
using BlogCore.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper) : base (context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoryList()
        {
            var categories = await context.Categories.ToListAsync();
            return categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
    }
}
