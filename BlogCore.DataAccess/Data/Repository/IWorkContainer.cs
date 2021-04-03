using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.DataAccess.Data.Repository
{
    public interface IWorkContainer : IDisposable
    {
        ICategoryRepository Category { get; }

        Task Save();

    }
}
