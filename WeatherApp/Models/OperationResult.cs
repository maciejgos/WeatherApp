using System;

namespace WeatherApp.Models
{
    public class OperationResult<TResult>
    {
        public bool Success { get; private set; }
        public TResult Result { get; private set; }
        public Exception Exception { get; private set; }

        internal static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true, Result = result };
        }

        internal static OperationResult<TResult> CreateFailResult(Exception exception)
        {
            return new OperationResult<TResult> { Success = false, Exception = exception };
        }
    }
}
