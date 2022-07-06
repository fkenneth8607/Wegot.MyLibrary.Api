using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;
using Wegot.MyLibrary.Api.ApplicationCore.Profiles.DTOs;
using Wegot.MyLibrary.Api.Controllers;
using WeGot.MyLibrary.Api.UnitTest.Services;
using Xunit;

namespace WeGot.MyLibrary.Api.UnitTest
{
    public class BooksControllerFake
    {
        private readonly BooksController _controller;
        private readonly IBookService _service;
        public BooksControllerFake()
        {
            _service = new BookServiceFake();
            _controller = new BooksController(_service);
        }
 
        [Fact]
        public async void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = await _controller.GetAll() as ResponseData;
            // Assert
            var items = Assert.IsType<List<BookDTO>>(okResult.Data);
            Assert.Equal(3, items.Count);
        }

        [Theory]
        [InlineData(0)]
        public async void GetById_WithNonBook_ThenBadRequest_Test(int id)
        {
            var result = await _controller.Get(id) as ResponseData;

            Assert.Equal(409, result.Status);
            Assert.Equal("Record not found!", result.Message);
        }

        [Theory]
        [InlineData(1)]
        public async void GetById_WithNonBook_ThenSuccess_Test(int id)
        {
            var result = await _controller.Get(id) as ResponseData;

            Assert.Equal(200, result.Status); 
        }
        [Theory]
        [InlineData(0)]
        public async void Delete_WithNonBook_ThenBadRequest_Test(int id)
        {
            var result = await _controller.Delete(id) as ResponseData;

            Assert.Equal(409, result.Status); 
        }

        [Fact]
        public async void Insert_WithNonBook_success()
        {

            BookDTO newItem = new BookDTO()
            {
                Id = 1,
                Title = "TItle 1",
                Author = "Autho 1",
                PagesNumber = 5,
                Editorial = "Editorial 1",
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ISBN = "BOOK01"
            };
            // Act
            var okResult = await _controller.Post(newItem) as ResponseData;
            // Assert 
            Assert.Equal(200, okResult.Status);
        }
        [Fact]
        public async void Insert_WithNonBook_failed()
        {

            BookDTO newItem = new BookDTO()
            {
                Id =4,
                Title = "TItle 1",
                Author = "",
                PagesNumber = 5,
                Editorial = "Editorial 1",
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ISBN = "BOOK01"
            };
            // Act
            var okResult = await _controller.Post(newItem) as ResponseData;
            // Assert 
            Assert.Equal(409, okResult.Status);
        }
        [Fact]
        public async void Update_WithNonBook_failed()
        {

            BookDTO newItem = new BookDTO()
            {
                Id = 5745,
                Title = "TItle 1",
                Author = "",
                PagesNumber = 5,
                Editorial = "Editorial 1",
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ISBN = "BOOK01"
            };
            // Act
            var okResult = await _controller.Post(newItem) as ResponseData;
            // Assert 
            Assert.Equal(409, okResult.Status);
        }


        [Fact]
        public async void Update_WithNonBook_success()
        {

            BookDTO newItem = new BookDTO()
            {
                Id = 1,
                Title = "TItle 1",
                Author = "Autho 1",
                PagesNumber = 5,
                Editorial = "Editorial 1",
                CreatedDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ISBN = "BOOK01"
            };
            // Act
            var okResult = await _controller.Post(newItem) as ResponseData;
            // Assert 
            Assert.Equal(200, okResult.Status);
        }
    }

}
