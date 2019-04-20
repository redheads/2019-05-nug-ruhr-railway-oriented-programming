namespace RopDemos.Slides.MyResult
{
    internal class MySuccess<TSuccess, TError> 
        : MyResult<TSuccess, TError>
            where TSuccess : class
            where TError : class
    {
        internal MySuccess(TSuccess success) 
            : base(success, default(TError)) {}
    }
}