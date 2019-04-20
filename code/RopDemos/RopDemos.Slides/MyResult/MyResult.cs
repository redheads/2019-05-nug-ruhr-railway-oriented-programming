namespace RopDemos.Slides.MyResult
{
    internal class MyResult<TSuccess, TError>
        where TSuccess : class
        where TError : class
    {
        internal MyResult(TSuccess success, TError error)
        {
            SuccessValue = success;
            FailureValue = error;
        }

        public TSuccess SuccessValue { get; }
        public TError FailureValue { get; }


        public bool IsSuccess => SuccessValue != null;
        public bool IsFailure => !IsSuccess;
    }
}