module HomeWork4.Parser

open System

let TryParseArg (arg:string)=
    try
        arg |> int
    with
    | _ -> raise (NullReferenceException "You have null value")
            
