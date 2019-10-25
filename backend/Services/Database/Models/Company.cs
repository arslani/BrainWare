using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainShark.Api.Services.Database
{
    [Table("company")]
    public class Company
    {
        [Key]
        [Column("company_id")]
        public int Id { get; set; }

        [MaxLength(128)]
        [Column("name")]
        public string Name { get; set; }


        [InverseProperty("Company")]
        public List<Order> Orders { get; set; }
    }
}
