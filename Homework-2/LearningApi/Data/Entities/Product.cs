using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
//Miguel Zaiter 2025-0928

namespace LearningApi.Data.Entities
{
    [Table("PRODUCT")]
    public class Product : DbContext
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
      



        public bool Stock { get; set; }   

        public DateTime DateReceived { get; set; }
    }
}



