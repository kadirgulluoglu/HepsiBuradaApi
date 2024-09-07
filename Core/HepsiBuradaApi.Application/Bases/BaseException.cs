using System;

namespace HepsiBuradaApi.Application.Bases
{
    public class BaseException : ApplicationException
    {
        protected BaseException()
        {
        }

        protected BaseException(string message) : base(message)
        {
        }
    }
}
