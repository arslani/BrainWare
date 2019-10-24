using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainShark.Api.Services.Database
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [MaxLength(128)]
        [Column("name")]
        public string Name { get; set; }

        [Column("price", TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        //[InverseProperty("Product")]
        //public List<OrderProduct> Items { get; set; }
    }
}
