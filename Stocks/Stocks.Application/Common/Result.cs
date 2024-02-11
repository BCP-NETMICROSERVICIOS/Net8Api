using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Application.Common
{
    public interface IResult
    {
        bool HasSucceeded { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
    }


    public class SuccessResult : IResult
    {
        public SuccessResult()
        {
            HasSucceeded = true;
        }
        public bool HasSucceeded { get; private set; }
    }

    public class SuccessResult<T> : IResult<T>
    {
        public SuccessResult() => HasSucceeded = true;
        public SuccessResult(T value) : this() => Value = value;
        public T Value { get; }

        public bool HasSucceeded { get; }
    }
    public class FailureResult : IResult
    {
        public bool HasSucceeded { get; private set; }
    }

    public class FailureResult<T> : IResult<T> where T : class
    {
        public FailureResult()
        {
            HasSucceeded = false;
        }

        public FailureResult(T errors)
        {
            Value = errors;
        }

        public bool HasSucceeded { get; private set; }

        public T Value { get; set; }
    }

    public class DetailError
    {
        public string ErrorCode { get; }
        public string Message { get; }

        public DetailError(string errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
