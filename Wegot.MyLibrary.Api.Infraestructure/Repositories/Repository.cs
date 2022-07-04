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
        public async Task<IEnumerable<T>> GetAll()
        {
            return entities.AsEnumerable();
        }
        public async Task<T> Get(int id)
        {
            return entities.FirstOrDefault(s => s.Id == id);
        }
        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
          
            await context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            await context.SaveChangesAsync();
        }
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
