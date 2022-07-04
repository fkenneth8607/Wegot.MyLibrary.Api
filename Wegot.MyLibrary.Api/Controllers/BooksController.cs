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
        private readonly IBookService _bookService;

        public BooksController( IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet()]
        public async Task<List<BookDTO>> GetAll()
        {
            return await _bookService.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<BookDTO> Get(int Id)
        {
            return await _bookService.Get(Id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] BookDTO bookAdd)
        {

            try
            {
                await _bookService.Insert(bookAdd);
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
                await _bookService.Update(bookEdit);
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
                await _bookService.Delete(Id);
            }
            catch (Exception exx)
            {

                return Conflict(exx.Message);

            }

            return Ok();

        }
    }
}
