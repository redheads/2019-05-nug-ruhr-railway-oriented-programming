module Tests

open System
open Xunit
open FsUnit.Xunit

[<Fact>]
let ``My test`` () =
    Assert.True(true)

//[<Fact>]
//let ``Valid customer name returns Ok object`` () =
//    let s = "valid"
//    create s
//    |> ResultTestHelper.isOkAndEquals get s |> should be true