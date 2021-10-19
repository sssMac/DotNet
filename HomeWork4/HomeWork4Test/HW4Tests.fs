module HW4Tests

open System
open System
open HomeWork4
open Xunit

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
let ``CalculatorNullResultTests`` () =
    let actual() =
        let res = Program.main [|"20";null;"a"|]
        printfn ""
    Assert.Throws<NullReferenceException>(Action actual )
    
[<Fact>]
let ``CalculatorArg1NullResultTests`` () =
    let actual() =
        let res = Program.main [|null;"/";"5"|]
        printfn ""
    Assert.Throws<NullReferenceException>(Action actual )
    
[<Fact>]
let ``rror_5_divide_0_DivideByZeroException_Returned`` () =
    let actual() =
        let res = Program.main [|"20";"/";"0"|]
        printfn ""
    Assert.Throws<DivideByZeroException>(Action actual )
    
[<Fact>]
let ``ArgumentExeption`` () =
    let actual() =
        let res = Program.main [|"20";"?";"0"|]
        printfn ""
    Assert.Throws<ArgumentException>(Action actual )
    

  
    
    
