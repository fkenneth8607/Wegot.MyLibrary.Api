using System;
using System.Collections.Generic;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Editorial { get; set; }
        public string Author { get; set; }
        public int PagesNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
