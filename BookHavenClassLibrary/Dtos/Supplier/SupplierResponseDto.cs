using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenClassLibrary.Enumz;

namespace BookHavenClassLibrary.Dtos.Supplier
{
    public class SupplierResponseDto
    {
        public int SupplierId { get; set; }

        public required string SupplierName { get; set; }

        public string? ContactPersonName { get; set; }

        public required string PhoneNumber { get; set; }

        public required SupplierTypes SupplierType { get; set; }
    }
}
