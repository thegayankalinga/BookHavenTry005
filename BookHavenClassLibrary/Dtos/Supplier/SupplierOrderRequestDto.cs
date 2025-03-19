using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Dtos.Supplier
{
    public class SupplierOrderRequestDto
    {
        public required int SupplierId { get; set; }
        public required DateOnly OrderDate { get; set; }
        public required OrderStatuses OrderStatuses { get; set; }

        //Mapped to foreign key relationships while creating.
        //public List<SupplierOrderItemRequestDto> OrderItems { get; set; }
    }
}
