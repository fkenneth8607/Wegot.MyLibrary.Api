using System;
using System.Collections.Generic;
using System.Text;

namespace Wegot.MyLibrary.Api.ApplicationCore.Profiles.DTOs
{
    public class ResponseData
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public int Status { get; set; } // 200 - 409
        public string Message { get; set; }
    }
}
