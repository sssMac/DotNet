namespace HomeWork5

open System
open Parser
open Calculator

module Program =
   
    [<EntryPoint>]
    let main argv =
        let calculate = res {
                      let! val1 = TryParseArguments argv.[0]
                      let! op = TryParseOperation argv.[1]
                      let! val2 = TryParseArguments argv.[2]
                      let! calculate = Calculate val1 op val2
                      return! calculate
        }
        match calculate with
        | Success result -> printf $"{calculate}"
        | Failure error -> printf $"{error}"
        0
        
