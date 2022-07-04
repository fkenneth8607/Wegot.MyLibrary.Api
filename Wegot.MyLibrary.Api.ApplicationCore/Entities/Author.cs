using System;
using System.Collections.Generic;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.Entities
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
