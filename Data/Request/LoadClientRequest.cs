using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Request
{
    public class LoadClientRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public int IdTypeIdentification { get; set; }
        public string HomeStreet { get; set; }
        public int? HomeHeigth { get; set; }
        public int? IdPostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}