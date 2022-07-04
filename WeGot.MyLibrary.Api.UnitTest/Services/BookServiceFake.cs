using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;

namespace WeGot.MyLibrary.Api.UnitTest.Services
{
    public class BookServiceFake : IBookService
    {

        private readonly List<BookDTO> _books;

        public BookServiceFake()
        {
            _books = new List<BookDTO>()
            {
                new BookDTO() { Id = 1,
                    Title = "TItle 1", Author="Autho 1", PagesNumber = 5, Editorial ="Editorial 1", CreatedDate=DateTime.Now, UpdateDate=DateTime.Now, ISBN="BOOK01" },
                new BookDTO() {Id = 2,
                    Title = "TItle 2", Author="Autho 2", PagesNumber = 5, Editorial ="Editorial 2", CreatedDate=DateTime.Now, UpdateDate=DateTime.Now, ISBN="BOOK02" },
                new BookDTO() { Id = 1,
                    Title = "TItle 3", Author="Autho 3", PagesNumber = 5, Editorial ="Editorial 3", CreatedDate=DateTime.Now, UpdateDate=DateTime.Now, ISBN="BOOK03" }
            };
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookDTO>> GetAll()
        {
            return _books;
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
