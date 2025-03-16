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
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(50)]
        public required string SupplierName { get; set; }

        [StringLength(50)]
        public string? ContactPersonName { get; set; }

        [StringLength(13)]
        public required string PhoneNumber { get; set; }

        [Required]
        public required SupplierTypes SupplierType { get; set; }

    }
}
