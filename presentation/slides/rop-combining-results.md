## Combining Results

```csharp
class Result<TSuccess, TError> 
{
    //...
    
    static Result<TSuccess2, TError> Bind(
        Result<TSuccess, TError> result,
        Func<TSuccess, Result<TSuccess2, TError>> func)
    {
        if (result.IsSuccess)
            return func(result.Success)

        return result.Failure;
    }
}
```
