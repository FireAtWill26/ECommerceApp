﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Model.Response
{
    public class ShoppingCartItemResponseModel
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }
    }
}
