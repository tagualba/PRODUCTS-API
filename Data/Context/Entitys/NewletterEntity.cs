using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context.Entitys
{
    public partial class NewsletterEntity
    {
        public int IdNewsletter { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}