using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.Profiles.Entities
{
    public class BookProfile : Profile
    {
        /// <summary>
        /// Make Mapper from DTO to Entity
        /// </summary>
        public BookProfile()
        {
            CreateMap<ApplicationCore.DTOs.BookDTO, ApplicationCore.Entities.Book>();
        }
    }
}
