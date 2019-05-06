module Tests

open System
open Xunit
open FsUnit.Xunit

type CustomerName = private CustomerName of string

let create s = 
    match String.IsNullOrWhiteSpace(s) with
    | true -> Error [ "String must not be empty" ]
    | false -> Ok(CustomerName s)

let get (CustomerName cn) = cn

type Customer = {
    CustomerName : CustomerName
}



[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Valid customer name returns Ok object`` () =
    let s = "valid"
    create s
    |> ResultTestHelper.isOkAndEquals get s |> should be true