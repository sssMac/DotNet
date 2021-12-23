namespace HomeWork4

open System


module Program =
   
    [<EntryPoint>]
    let main argv =
        let arg1 = Parser.TryParseArg argv.[0]
        let operation = argv.[1]
        let arg2 = Parser.TryParseArg argv.[2]
                
        let res = Calculator.Calculate arg1 operation arg2
        
        printfn $"{res}"
        
        0
        
