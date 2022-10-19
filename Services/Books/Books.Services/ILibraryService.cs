using Books.Data.Models.Libraries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Services
{
    public interface ILibraryService
    {
        public Task<IEnumerable<LibraryDto>> GetAllForUser(string userId);
    }
}
