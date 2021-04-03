using AutoMapper;
using BlogCore.DataAccess.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data
{
    public class WorkContainer : IWorkContainer
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ICategoryRepository Category { get; private set; }
        public WorkContainer(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            Category = new CategoryRepository(context, mapper);
        }

        public void Dispose()
        {
            context.Dispose();            
        }

        public async Task Save()
        {
           await context.SaveChangesAsync();
        }
    }
}
