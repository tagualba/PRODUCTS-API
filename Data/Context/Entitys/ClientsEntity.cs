using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context.Entitys
{
    public partial class ClientsEntity
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public int IdTypeIdentification { get; set; }
        public string HomeStreet { get; set; }
        public int? HomeHeigth { get; set; }
        public string HomeDetails { get; set; }
        public string Departament { get; set; }
        public string Region { get; set; }
        public int? IdPostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AdicionalInfo { get; set; }
    }
}
