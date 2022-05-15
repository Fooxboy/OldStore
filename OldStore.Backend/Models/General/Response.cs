using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Models.General
{
    public class Response<T>
    {
        public T? Result { get; set; }

        public ResponseError Error { get; set; }
        public bool Success { get; set; }
    }
}
