using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;

namespace Wegot.MyLibrary.Api.ApplicationCore.Services
{
    public class BookService : IBookService
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Insert(BookDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(BookDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
