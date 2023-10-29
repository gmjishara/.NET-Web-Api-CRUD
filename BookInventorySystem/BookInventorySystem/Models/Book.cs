using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookInventorySystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }
        public string Year { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}
