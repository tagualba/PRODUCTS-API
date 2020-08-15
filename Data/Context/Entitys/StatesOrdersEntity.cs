using System;
using System.Collections.Generic;

namespace ProductsAPI.Data.Context.Entitys
{
    public partial class StatesOrdersEntity
    {
        public int IdStateOrder { get; set; }
        public int IdOrder { get; set; }
        public int IdState { get; set; }
    }
}
