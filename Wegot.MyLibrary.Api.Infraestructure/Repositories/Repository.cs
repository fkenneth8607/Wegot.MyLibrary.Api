using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.Entities;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Repositories;
using WeGot.MyLibrary.Api.Infrastructure.Data;

namespace Wegot.MyLibrary.Api.Infraestructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyLibraryDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(MyLibraryDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        /// <summary>
        /// Generic get ALl Elements
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Generic get ById Element
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> Get(int id)
        {
            return await entities.FirstOrDefaultAsync(s => s.Id == id).ConfigureAwait(false);
        }

        /// <summary>
        /// Generic Insert Any Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
          
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Generic Update Any Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Generic Delete Any Item Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
             
        }
    }
}
