using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;
using Wegot.MyLibrary.Api.ApplicationCore.Entities;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Repositories;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;

namespace Wegot.MyLibrary.Api.ApplicationCore.Services
{
    public class BookService : IBookService
    {

        private readonly ILogger<BookService> logger;
        private readonly IMapper mapper;
        private readonly IBookRepository bookRepository;
  
        public BookService(ILogger<BookService> logger, IMapper mapper, IBookRepository bookRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.bookRepository = bookRepository;
 
        }

        /// <summary>
        /// Delete Entity Book By Id, in this Section we Apply Logic if is Necesary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var result = await bookRepository.Get(id).ConfigureAwait(false);
            await bookRepository.Delete(result);
            
        }

        /// <summary>
        /// Get Element book by Id , in this Section we Apply Logic if is Necesary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookDTO> Get(int id)
        {
            var result = await bookRepository.Get(id).ConfigureAwait(false);
            return mapper.Map<BookDTO>(result);
        }

        /// <summary>
        /// Get All Items Books , in this Section we Apply Logic if is Necesary
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookDTO>> GetAll()
        {
            var result = await bookRepository.GetAll().ConfigureAwait(false);
            return mapper.Map<List<BookDTO>>(result);
        }

        /// <summary>
        /// Insert Item Book , in this Section we Apply Logic if is Necesary
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Insert(BookDTO entity)
        {
            await bookRepository.Insert(mapper.Map<Book>(entity)).ConfigureAwait(false);
        }

        /// <summary>
        /// Update Entity Book , in this Section we Apply Logic if is Necesary
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(BookDTO entity)
        {
            await bookRepository.Update(mapper.Map<Book>(entity)).ConfigureAwait(false);
        }
    }
}
