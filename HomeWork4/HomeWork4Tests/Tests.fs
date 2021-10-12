namespace HomeWork4Tests

open HomeWork4
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =
    
    [<TestMethod>]
    let Sum_20and5_25_returned ()=
        let result = Program.main [|"20";"+";"5"|]
        Assert.Equals(result,0)
