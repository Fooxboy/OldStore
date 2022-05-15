using OldStore.Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Models.General
{
    public class ResponseError
    {
        public ResponseErrorCode Code { get;set; }
        public string Message { get; set; }
    }
}
