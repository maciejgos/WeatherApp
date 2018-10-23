using System;
namespace WeatherApp.Models
{
    public class OperationResult<TResult>
    {
        public bool Success { get; private set; }
        public TResult Result { get; private set; }

        internal static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true, Result = result };
        }
    }
}
