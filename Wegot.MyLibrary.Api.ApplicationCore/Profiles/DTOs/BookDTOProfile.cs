using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.Profiles.DTOs
{
    public class BookDTOProfile : Profile
    {
       /// <summary>
       /// Make Mapper from Entity to DTO
       /// </summary>
        public BookDTOProfile()
        {
            CreateMap<ApplicationCore.Entities.Book, ApplicationCore.DTOs.BookDTO>();
        }
    }
}
