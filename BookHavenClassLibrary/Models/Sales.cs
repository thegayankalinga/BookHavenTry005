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
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesId { get; set; }

        // Customer Relationship (Required)
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.Sales))]
        public Customer Customer { get; set; } = null!;

        // User Relationship (Required, assuming AppUser is your custom user model)
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; } = null!;

        // Optional: SaleItem - but logically this should be a collection
        public List<SaleItem> SaleItems { get; set; } = new();

        public DeliveryMethods DeliveryMethod { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;


    }
}
