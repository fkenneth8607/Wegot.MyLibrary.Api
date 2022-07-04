using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.Entities
{
    [Table("libros", Schema = "masters")]
    public class Book : BaseEntity
    {

        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Editorial { get; set; }
        public string Author { get; set; }
      
    }
}
