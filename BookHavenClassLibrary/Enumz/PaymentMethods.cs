using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Enumz
{
    public enum PaymentMethods
    {
        [EnumMember(Value = "Cash")]
        Cash = 0,

        [EnumMember(Value = "Card")]
        Card = 1,
    }
}
