using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Wegot.MyLibrary.Api.ApplicationCore.DTOs;
using Wegot.MyLibrary.Api.ApplicationCore.Interfaces.Services;
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
            var okResult = await _controller.GetAll() as List<BookDTO>;
            // Assert
            var items = Assert.IsType<List<BookDTO>>(okResult);
            Assert.Equal(3, items.Count);
        }
    }
}
