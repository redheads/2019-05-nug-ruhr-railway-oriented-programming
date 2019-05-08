module Tests

open System
open Xunit
open FsUnit.Xunit

// Example from https://fsharpforfunandprofit.com/posts/recipe-part2/
// and https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/results

type Request = {name:string; email:string}

let validate1 input =
    if input.name = "" then Error "Name must not be blank"
    else Ok input

let validate2 input =
    if input.name.Length > 50 then Error "Name must not be longer than 50 chars"
    else Ok input

let validate3 input =
    if input.email = "" then Error "Email must not be blank"
    else Ok input


let bind switchFunction twoTrackInput = 
    match twoTrackInput with
    | Ok s -> switchFunction s
    | Error f -> Error f

[<Fact>]
let ``railway demo 1`` () =

    /// glue the three validation functions together
    let combinedValidation = 
        // convert from switch to two-track input
        let validate2' = bind validate2
        let validate3' = bind validate3
        // connect the two-tracks together
        validate1 >> validate2' >> validate3' 

    // test 1
    let input1 = {name=""; email=""}
    let result = combinedValidation input1 
    match result with
    | Ok req -> Assert.Equal(req, {name=""; email=""})
    | Error error -> Assert.Equal(error, "Name must not be blank")

    result |> printfn "Result=%A"

    // test 2
    let input2 = {name="Alice"; email=""}
    let result2 = combinedValidation input2
    match result2 with
    | Ok req -> Assert.Equal(req, {name=""; email=""})
    | Error error -> Assert.Equal(error, "Email must not be blank")

    result2 |> printfn "Result=%A"

    // test 3
    let input3 = {name="Alice"; email="good"}
    let result3 = combinedValidation input3
    match result3 with
    | Ok req -> Assert.Equal(req, {name="Alice"; email="good"})
    | Error error -> Assert.Equal(error, "")

    result3 |> printfn "Result=%A"

[<Fact>]
let ``railway demo 2`` () =

    let combinedValidation = 
        validate1 
        >> bind validate2 
        >> bind validate3

    // test 1
    let input1 = {name=""; email=""}
    let result = combinedValidation input1 
    match result with
    | Ok req -> Assert.Equal(req, {name=""; email=""})
    | Error error -> Assert.Equal(error, "Name must not be blank")
    
    result |> printfn "Result=%A"
    
    // test 2
    let input2 = {name="Alice"; email=""}
    let result2 = combinedValidation input2
    match result2 with
    | Ok req -> Assert.Equal(req, {name=""; email=""})
    | Error error -> Assert.Equal(error, "Email must not be blank")

    result2 |> printfn "Result=%A"

    // test 3
    let input3 = {name="Alice"; email="good"}
    let result3 = combinedValidation input3
    match result3 with
    | Ok req -> Assert.Equal(req, {name="Alice"; email="good"})
    | Error error -> Assert.Equal(error, "")

    result3 |> printfn "Result=%A"

[<Fact>]
let ``railway demo 3`` () =

    let (>>=) twoTrackInput switchFunction = 
        bind switchFunction twoTrackInput 

    let combinedValidation x = 
        x 
        |> validate1   // normal pipe because validate1 has a one-track input
                       // but validate1 results in a two track output...
        >>= validate2  // ... so use "bind pipe". Again the result is a two track output
        >>= validate3   // ... so use "bind pipe" again. 

    // test 1
    let input1 = {name=""; email=""}
    let result = combinedValidation input1 
    match result with
    | Ok req -> Assert.Equal(req, {name=""; email=""})
    | Error error -> Assert.Equal(error, "Name must not be blank")

    result |> printfn "Result=%A"

    // test 2
    let input2 = {name="Alice"; email=""}
    let result2 = combinedValidation input2
    match result2 with
    | Ok req -> Assert.Equal(req, {name=""; email=""})
    | Error error -> Assert.Equal(error, "Email must not be blank")

    result2 |> printfn "Result=%A"

    // test 3
    let input3 = {name="Alice"; email="good"}
    let result3 = combinedValidation input3
    match result3 with
    | Ok req -> Assert.Equal(req, {name="Alice"; email="good"})
    | Error error -> Assert.Equal(error, "")

    result3 |> printfn "Result=%A"

