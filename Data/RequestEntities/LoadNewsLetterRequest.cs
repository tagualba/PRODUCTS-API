using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class LoadNewsLetterRequest
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}