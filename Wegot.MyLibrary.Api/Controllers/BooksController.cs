using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;
using Wegot.MyLibrary.Api.ApplicationCore.Profiles.DTOs;

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
        public async Task<ResponseData> GetAll()
        {
            try
            {
                var oData = await _bookService.GetAll();
                return new ResponseData() { Data = oData, Success = true, Status = 200, Message = "" };

            }
            catch (Exception exx)
            {
                return new ResponseData() { Data = null, Success = false, Status = 409, Message = exx.Message };
            }
        }

        [HttpGet("{Id}")]
        public async Task<ResponseData> Get(int Id)
        {

            try
            {
                var oData = await _bookService.Get(Id);
                return new ResponseData() { Data = oData, Success = true, Status = 200, Message = "" };

            }
            catch (Exception exx)
            {
                return new ResponseData() { Data = null, Success = false, Status = 409, Message = exx.Message };
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<ResponseData>  Post([FromBody] BookDTO bookAdd)
        {
            try
            {
                await _bookService.Insert(bookAdd);
                return new ResponseData() { Data = null, Success = true, Status = 200, Message = "Registro Exitoso!" };

            }
            catch (Exception exx)
            {
                return new ResponseData() { Data = null, Success = false, Status = 409, Message = exx.Message };
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<ResponseData> Put([FromBody] BookDTO bookEdit)
        {
            try
            {
                await _bookService.Update(bookEdit);
                return new ResponseData() { Data = null, Success = true, Status = 200, Message = "Actualizacion Exitosa!" };

            }
            catch (Exception exx)
            {
                return new ResponseData() { Data = null, Success = false, Status = 409, Message = exx.Message };
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<ResponseData>  Delete(int Id)
        {
            try
            {
                await _bookService.Delete(Id);
                return new ResponseData() { Data = null, Success = true, Status = 200, Message = "Eliminacion Exitosa!" };

            }
            catch (Exception exx)
            {
                return new ResponseData() { Data = null, Success = false, Status = 409, Message = exx.Message };
            }

        }
    }
}
