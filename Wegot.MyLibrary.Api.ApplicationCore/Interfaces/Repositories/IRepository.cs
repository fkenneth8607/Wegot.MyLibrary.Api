using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.Entities;

namespace Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
