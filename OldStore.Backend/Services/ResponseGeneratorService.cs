using OldStore.Backend.Models.Enums;
using OldStore.Backend.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Backend.Services
{
    public static class ResponseGeneratorService
    {
        public static Response<T> GenerateData<T>(T data)
        {
            var response = new Response<T>();
            response.Result = data;
            response.Success = true;

            return response;
        }

        public static Response<T> Error<T>(ResponseErrorCode code, string message)
        {
            var response = new Response<T>();

            response.Success = false;
            response.Result = default(T);
            response.Error = new ResponseError
            {
                Code = code,
                Message = message
            };

            return response;
        }
    }
}
