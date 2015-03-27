namespace BATSExchangeApi.Library.Models.Common
{
    public class SuccessOperationResult<T> : OperationResult<T>
    {
        public SuccessOperationResult(T data)
            : base(true, string.Empty, data)
        {
            Data = data;
        }
    }

    public class FailedOperationResult<T> : OperationResult<T>
    {
        public FailedOperationResult(string errorMessage)
            : base(false, errorMessage, default(T))
        {
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Data;

        public OperationResult(bool success, string errorMessage, T data) : base(success, errorMessage)
        {
            Data = data;
        }
    }

    public class OperationResult
    {
        protected OperationResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}
