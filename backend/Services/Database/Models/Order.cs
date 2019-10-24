using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BrainShark.Api.Services.Database;

namespace BrainShark.Api.Services.Database
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int Id { get; set; }

        [MaxLength(128)]
        [Column("description")]
        public string Description { get; set; }


        [Column("company_id")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [InverseProperty("Order")]
        public List<OrderProduct> Items { get; set; }
    }
}
