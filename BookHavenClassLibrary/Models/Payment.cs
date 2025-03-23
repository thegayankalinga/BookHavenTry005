using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int SaleId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        
        public PaymentStatuses PaymentStatus { get; set; }

        // Navigation property
        public Sales? Sale { get; set; }
    }
}
