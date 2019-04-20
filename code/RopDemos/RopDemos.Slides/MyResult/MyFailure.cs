namespace RopDemos.Slides.MyResult
{
    internal class MyFailure<TSuccess, TError> 
        : MyResult<TSuccess, TError>
            where TSuccess : class
            where TError : class
    {
        internal MyFailure(TError error) 
            : base(default(TSuccess), error) {}
    }
}