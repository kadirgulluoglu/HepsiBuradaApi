using System;
using Newtonsoft.Json;

namespace HepsiBuradaApi.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public string Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class ErrorStatusCode
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
    }
}
