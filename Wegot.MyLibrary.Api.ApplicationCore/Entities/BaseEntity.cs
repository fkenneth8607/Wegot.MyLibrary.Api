using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("createddate")]
        public DateTime CreatedDate { get; set; }
        [Column("updateddate")]
        public DateTime UpdatedDate { get; set; }

    }
}
