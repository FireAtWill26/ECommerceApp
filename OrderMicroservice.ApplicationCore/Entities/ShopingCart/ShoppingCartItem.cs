using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities.ShopingCart
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        [Column("Cart_Id")]
        public int CartId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
        
        public int Qty { get; set; }

        public decimal Price { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
