using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;

namespace Wegot.MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {

        private readonly ILogger<BooksController> logger;
        private readonly IBookService bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            this.logger = logger;
            this.bookService = bookService;
        }

        [HttpGet()]
        public async Task<List<BookDTO>> GetAll()
        {
            return await bookService.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<BookDTO> Get(int Id)
        {
            return await bookService.Get(Id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] BookDTO bookAdd)
        {

            try
            {
                await bookService.Insert(bookAdd);
            }
            catch (Exception exx)
            {

                return Conflict(exx.Message);

            }

            return Ok();

        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] BookDTO bookEdit)
        {
            try
            {
                await bookService.Update(bookEdit);
            }
            catch (Exception exx)
            {

                return Conflict(exx.Message);

            }

            return Ok();


        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await bookService.Delete(Id);
            }
            catch (Exception exx)
            {

                return Conflict(exx.Message);

            }

            return Ok();

        }
    }
}
