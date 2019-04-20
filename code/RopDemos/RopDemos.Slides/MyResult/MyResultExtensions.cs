namespace RopDemos.Slides.MyResult
{
    internal static class MyResultExtensions
    {
        public static MyResult<TS, TE> Success<TS, TE>(this TS success)
            where TS : class
            where TE : class
        {
            return new MySuccess<TS, TE>(success);
        }

        public static MyResult<TS, TE> Failure<TS, TE>(this TE error)
            where TS : class
            where TE : class
        {
            return new MyFailure<TS, TE>(error);
        }
    }
}