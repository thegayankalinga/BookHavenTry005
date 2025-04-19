using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Enumz
{
    public enum UserRoleType
    {
        [EnumMember(Value = "Admin")]
        Admin = 0,

        [EnumMember(Value = "Clerk")]
        Clerk = 1,

        [EnumMember(Value = "Sales")]
        Sales = 2
    }
}

