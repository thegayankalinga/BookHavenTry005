using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(50)]
        public required string Author { get; set; }

        [Required]
        public required BookGenres BookGenre { get; set; }

   
        [StringLength(50)]
        public string? Isbn { get; set; }
        public decimal? DiscountPct { get; set; }

        [Required]
        public required decimal SellingPrice { get; set; }
        
        [Required]
        public required int StockQuantity { get; set; }

        public DateOnly LastRestockDate { get; set; }

        public int QuantitySold { get; set; }

        //One to many relationship (one side of the relationship)
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();


    }
}
