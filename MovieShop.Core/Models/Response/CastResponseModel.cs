using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class CastResponseModel
    {
        public int CastId { get; set; }
        public string ProfileUrl { get; set; }
        public string  CastName { get; set; }
        public string Character { get; set; }
    }
}
