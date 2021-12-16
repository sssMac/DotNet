module HomeWork5.Parser


type Res<'a> =
| Success of 'a
| Failure of string

type ResBuilder() =
    let bind foo res =
        match res with
        | Success x -> foo x
        | Failure error -> Failure error
    member this.Return x = x
    member this.ReturnFrom x = Success x
    member this.Bind(x,foo) = bind foo x

let res = new ResBuilder()        
let TryParseArguments (arg : string) =            
        let parseArg x =
            try Success (x |> decimal) with
            | _ -> Failure "Invalid argument"
        parseArg arg

let TryParseOperation (arg : string) =
        let parseOp operation =
            match operation with
            | "+" -> Success "+"
            | "-" -> Success "-"
            | "*"  -> Success "*"
            | "/"  -> Success "/"
            | _ -> Failure "Invalid operation"
        parseOp arg 
    
