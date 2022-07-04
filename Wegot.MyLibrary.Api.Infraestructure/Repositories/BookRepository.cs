using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.Entities;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Repositories;
using WeGot.MyLibrary.Api.Infrastructure.Data;

namespace Wegot.MyLibrary.Api.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger<BookRepository> logger;
        private readonly MyLibraryDbContext _dbContext;

        public BookRepository(ILogger<BookRepository> logger, MyLibraryDbContext dbContext)
        {
            this.logger = logger;
            this._dbContext = dbContext;
        }


        /// <summary>
        /// Delete a Book Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Delete(Book entity)
        {
            try
            {
                _dbContext.Books.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar El Libro " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Get Book by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Book> Get(int id)
        {
            try
            {
                return await _dbContext
                       .Books
                       .Where(x => x.Id == id)
                       .AsNoTracking()
                       .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Obtener El Libro " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Get All Books 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Book>> GetAll()
        {
            try
            {
                return await _dbContext
                 .Books
                 .AsNoTracking()
                 .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Obtener Todos los Libros " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Insert Book Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Insert(Book entity)
        {
            try
            {
                _dbContext.Books.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Insertar El Libro " + ex.InnerException.Message);
            }


        }

        /// <summary>
        /// Update Book Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Update(Book entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Actualizar El Libro " + ex.InnerException.Message);
            }
        }
    }

}
