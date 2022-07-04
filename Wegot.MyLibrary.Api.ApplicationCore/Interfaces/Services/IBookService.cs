using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;

namespace Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAll();

        Task<BookDTO> Get(int id);

        Task Insert(BookDTO entity);

        Task Update(BookDTO entity);

        Task Delete(int id);
    }
}
