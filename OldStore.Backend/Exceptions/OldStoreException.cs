using OldStore.Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Exceptions
{
    public class OldStoreException:Exception
    {

        public string Message { get; set; }
        public ResponseErrorCode ErrorCode { get; set; }

        public OldStoreException(string message, ResponseErrorCode code) : base(message)
        {
            this.Message = message;
            this.ErrorCode = code;
        }
    }
}
