using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task Delete(Book entity)
        {
            dbContext.Books.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Book> Get(int id)
        {
           return await dbContext
                  .Books
                  .Where(x=> x.Id == id)
                  .AsNoTracking()
                  .FirstAsync();
        }

        public async Task<List<Book>> GetAll()
        {
            return await dbContext
                 .Books
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task Insert(Book entity)
        {
            try
            {
                dbContext.Books.Add(entity);
                await dbContext.SaveChangesAsync();
            }catch (Exception ex)
            {
                return;
            }
            

        }

        public async Task Update(Book entity)
        {

            dbContext.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await dbContext.SaveChangesAsync();
            
        }
    }

}
