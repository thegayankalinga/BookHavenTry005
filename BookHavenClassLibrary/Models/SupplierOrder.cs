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
    public class SupplierOrder
    {
        //One to many relationship one side of the relationship

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierOrderId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public required DateOnly OrderDate { get; set; }

        [Required]
        public required OrderStatuses OrderStatuses { get; set; }

        public List<SupplierOrderItem> SupplierOrderItems { get; set; } = new List<SupplierOrderItem>();
    }
}
