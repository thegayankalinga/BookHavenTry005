using BookHavenClassLibrary.Dtos.Supplier;
using BookHavenClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Mappers
{
    public class SupplierMapper
    {
        public static SupplierResponseDto? MapToSupplierReponseDto(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));

            return new SupplierResponseDto
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                ContactPersonName = supplier.ContactPersonName,
                PhoneNumber = supplier.PhoneNumber,
                SupplierType = supplier.SupplierType,
            };
        }

        public static Supplier MaptoSupplier(SupplierRequestDto supplierRequest)
        {
            return new Supplier
            {
                SupplierName = supplierRequest.SupplierName,
                ContactPersonName = supplierRequest.ContactPersonName,
                PhoneNumber = supplierRequest.PhoneNumber,
                SupplierType = supplierRequest.SupplierType

            };
        }
    }
}
