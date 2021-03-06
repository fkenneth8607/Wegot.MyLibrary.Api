using System;
using System.Collections.Generic;
using System.Linq;
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
            var existing = _books.First(a => a.Id == id);
            _books.Remove(existing);
            return null;
        }
     
        public async Task<BookDTO> Get(int id)
        {
            if (id == 0)
            {
                throw new Exception("Record not found!");
            }
            else
            {
               return _books.Where(a => a.Id == id).FirstOrDefault();
               
            }
            
        }

        public async Task<List<BookDTO>> GetAll()
        {
            return _books;
        }

        public Task Insert(BookDTO entity)
        {
            if (isValid(entity))
            {
                _books.Add(entity);
            }

            return Task.FromResult(true);
        }

        public Task Update(BookDTO entity)
        {
            if (isValid(entity))
            {
                _books.Add(entity);
                BookDTO result = _books.Where(a => a.Id == entity.Id).FirstOrDefault();
                result = entity;
            }
           
            return Task.FromResult(true);
        }
        public bool isValid(BookDTO entity)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(entity.Author))
            {
                valid = false;
                throw new Exception("Autor es un campo Requerido");
            }

            if (string.IsNullOrEmpty(entity.Editorial))
            {
                valid = false;
                throw new Exception("Editorial es un campo Requerido");
            }

            if (string.IsNullOrEmpty(entity.Title))
            {
                valid = false;
                throw new Exception("Titulo es un campo Requerido");
            }

            if (string.IsNullOrEmpty(entity.ISBN))
            {
                valid = false;
                throw new Exception("ISBN es un campo Requerido");
            }

            return valid;

        }
    }
}
