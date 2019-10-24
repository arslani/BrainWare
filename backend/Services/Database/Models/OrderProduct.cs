using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BrainShark.Api.Services.Database
{
    [Table("orderproduct")]
    public class OrderProduct
    {
       // [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }


       // [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }


        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
