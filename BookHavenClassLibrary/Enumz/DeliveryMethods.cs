using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Enumz
{
    public enum DeliveryMethods
    {
        [EnumMember(Value = "Pickup")]
        Pickup = 0,
        [EnumMember(Value = "Deliver")]
        Deliver = 1,
    }
}
