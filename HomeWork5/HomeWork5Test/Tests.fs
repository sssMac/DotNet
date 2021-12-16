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
       



  
    
    
