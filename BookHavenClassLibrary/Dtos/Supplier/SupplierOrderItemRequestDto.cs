using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Dtos.Supplier
{
    public class SupplierOrderItemRequestDto
    {
        public required int BookId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
    }
}
