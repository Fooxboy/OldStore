using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Models.Enums
{
    public enum ResponseErrorCode
    {
        Exception,

        UserBanned,

        UserNotFound,

        IncorrectPassword,

        GameNotFound
    }
}
