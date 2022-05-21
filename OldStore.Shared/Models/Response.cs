using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class Response<T>
    {
        [JsonPropertyName("result")]
        public T? Result { get; set; }
        [JsonPropertyName("error")]

        public ResponseError Error { get; set; }
        [JsonPropertyName("success")]

        public bool Success { get; set; }
    }
}
