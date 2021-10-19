module HW4Tests

open System
open System
open HomeWork5
open Xunit
open Parser
open Calculator

[<Fact>]
let ``Sum_20_Plus_5_25_Returned`` () =
    let actual = Program.main [|"20";"+";"5"|]
    Assert.Equal(actual,0)
    
[<Fact>]
let ``Dif_20_Minus_5_15_Returned`` () =
    let actual = Program.main [|"20";"-";"5"|]
    Assert.Equal(actual,0)
    
[<Fact>]
let ``Prod_20_Multi_5_100_Returned`` () =
    let actual = Program.main [|"20";"*";"5"|]
    Assert.Equal(actual,0)
 
[<Fact>]
let ``Priv_20_Divide_5_4_Returned`` () =
    let actual = Program.main [|"20";"/";"5"|]
    Assert.Equal(actual,0)
       
[<Fact>]

[<Theory>]
[<InlineData("20", null, "5")>]
let ``NullArgumentException`` (arg1, op, arg2) =
    let res = Calculate arg1 op arg2
    Assert.Equal(Failure "Invalid operation", res)
    
[<Theory>]
[<InlineData(null, "/", "4")>]
let ``NullReferenceException`` (arg1, op, arg2) =
    let res = Calculate arg1 op arg2
    Assert.Equal(Failure "Invalid argument", res)

[<Theory>]
[<InlineData("20", "/", "0")>]
let ``DivideByZeroException`` (arg1, op, arg2) =
    let res = Calculate arg1 op arg2
    Assert.Equal(Failure "You can't divide by zero", res)
    
[<Theory>]
[<InlineData("7", "?", "5")>]
let ``Argument Exception`` (arg1, op, arg2) =
    let res = Calculate arg1 op arg2
    Assert.Equal(Failure "Invalid argument", res)
    

  
    
    
