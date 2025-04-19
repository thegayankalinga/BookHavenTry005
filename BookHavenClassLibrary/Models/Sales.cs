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

        //One to many relationship
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }//Navigation Property

        public int? SaleItemId { get; set; }
        public SaleItem? SaleItem { get; set; }//Navigation Property    

        public int UserId { get; set; }
        public AppUser? User { get; set; }//Navigation Property

        public DeliveryMethods DeliveryMethod { get; set; }
        

    }
}
