using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Enumz
{
    public enum OrderStatuses
    {

        [EnumMember(Value = "Pending")]
        Pending = 0,

        [EnumMember(Value = "Processing")]
        Processing = 1,

        [EnumMember(Value = "Shipped")]
        Shipped = 2,

        [EnumMember(Value = "Completed")]
        Completed = 3
    
    }
}
