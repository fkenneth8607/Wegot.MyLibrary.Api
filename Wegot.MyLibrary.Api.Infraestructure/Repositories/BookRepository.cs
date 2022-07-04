using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.Entities;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Repositories;
using WeGot.MyLibrary.Api.Infrastructure.Data;

namespace Wegot.MyLibrary.Api.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<BookRepository> logger;
        private readonly MyLibraryDbContext dbContext;

        public BookRepository(ILogger<BookRepository> logger, MyLibraryDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Task Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }

}
