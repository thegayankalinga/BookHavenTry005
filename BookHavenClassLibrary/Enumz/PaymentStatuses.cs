﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Enumz
{
    public enum PaymentStatuses
    {
        [EnumMember(Value = "Pending")]
        Pending = 0,

        [EnumMember(Value = "Paid")]
        Paid = 1,

        [EnumMember(Value = "Failed")]
        Failed = 2
    }
}
