namespace HomeWork5


open Parser
open Calculator

module Program =
   
    [<EntryPoint>]
    let main argv =
        let result = maybeBuilder{
            let! Parsed = Parser.Parse argv
            let res = Calculator.Calculate Parsed
            return res
        }
        match result with
        | Ok b ->
            printf $"{b}"
            0
        | Error error -> int error
