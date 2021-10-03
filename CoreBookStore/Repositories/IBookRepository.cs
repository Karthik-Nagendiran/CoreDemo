using CoreBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBookStore.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
