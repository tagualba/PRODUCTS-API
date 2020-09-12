using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class GetClientRequest
    {
        public int IdClient { get; set; }
        public string Email { get; set; }
    }
}