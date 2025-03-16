using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Dtos.Supplier
{
    public class SupplierRequestDto
    {
        public required string SupplierName { get; set; }

        public string? ContactPersonName { get; set; }

        public required string PhoneNumber { get; set; }

        public required SupplierTypes SupplierType { get; set; }
    }
}
