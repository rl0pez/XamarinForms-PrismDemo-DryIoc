using PrismDemoD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismDemoD.Services
{
    public interface IBookService
    {
        Task<IList<BookGroup>> GetBookGroups();
    }
}