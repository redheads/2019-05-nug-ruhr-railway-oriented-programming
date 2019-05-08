## F# #

### Record type

```fsharp
type Request = {name:string; email:string}
```

- Immutable by default
- Equality by value

----

## F# #

### Result

```fsharp
type Result<'T,'TError> = 
    | Ok of ResultValue:'T 
    | Error of ErrorValue:'TError
```

- Discriminated Union
- gibt es leider in C# nicht

----

## F# #

### Funktionen

```fsharp
let validate1 input =
    if input.name = "" then Error "Name must not be blank"
    else Ok input

let validate2 input =
    if input.name.Length > 50 then Error "Name must not be longer than 50 chars"
    else Ok input

let validate3 input =
    if input.email = "" then Error "Email must not be blank"
    else Ok input
```

----

## F# #

### Bind

```fsharp
let bind switchFunction twoTrackInput = 
    match twoTrackInput with
    | Ok s -> switchFunction s
    | Error f -> Error f
```

----

zur Erinnerung: C# Bind

```csharp
static class ResultExtensions
{
    static Result<TSuccess2, TError> OnSuccess
        (this Result<TSuccess, TError> result,
        Func<TSuccess, Result<TSuccess2, TError>> func)
    {
        if (result.IsSuccess)
            return func(result.Success)

        return result.Failure;
    }
})
```

----

### F# Railway Oriented Programming 
#### Version 1

```fsharp
let combinedValidation = 
    let validate2' = bind validate2
    let validate3' = bind validate3
    validate1 >> validate2' >> validate3' 

let input1 = {name=""; email=""}
let result = combinedValidation input1
result2 |> printfn "Result=%A"

// Result=Error "Name must not be blank"
```

----

### F# Railway Oriented Programming 
#### Version 2

```fsharp
let combinedValidation = 
    validate1 
    >> bind validate2 
    >> bind validate3

let input1 = {name=""; email=""}
let result = combinedValidation input1
result2 |> printfn "Result=%A"

// Result=Error "Name must not be blank"
```

----

### F# Railway Oriented Programming 
#### Version 3

```fsharp
let (>>=) twoTrackInput switchFunction = 
    bind switchFunction twoTrackInput 

let combinedValidation x = 
    x 
    |> validate1
    >>= validate2
    >>= validate3

let input1 = {name=""; email=""}
let result = combinedValidation input1
result2 |> printfn "Result=%A"

// Result=Error "Name must not be blank"
```

