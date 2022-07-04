using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.Entities
{
    [Table("book", Schema = "master")]
    public class Book : BaseEntity
    {

        [Column("isbn")]
        public string ISBN { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("editorial")]
        public string Editorial { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("pagesnumber")]
        public int PagesNumber { get; set; }
 

    }
}
