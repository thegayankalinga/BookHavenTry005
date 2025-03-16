using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Enumz
{
    public enum SupplierTypes
    {
        [EnumMember(Value = "Individual")]
        Individual = 0,

        [EnumMember(Value = "Company")]
        Company = 1
    }
}
