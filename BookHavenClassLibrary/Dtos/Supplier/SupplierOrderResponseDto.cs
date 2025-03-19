using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Dtos.Supplier
{
    public class SupplierOrderResponseDto
    {
        public int SupplierOrderId { get; set; }
        public required int SupplierId { get; set; }
        public required DateOnly OrderDate { get; set; }
        public required OrderStatuses OrderStatuses { get; set; }

        //Mapped properties from foreign key relationships
        public required List<SupplierOrderItemResponseDto> OrderItems { get; set; }

        //Calculated Fields
        public decimal TotalPrice => OrderItems.Sum(item => item.Quantity * item.UnitPrice);
    }
}
