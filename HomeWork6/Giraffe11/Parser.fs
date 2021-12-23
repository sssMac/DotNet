module Giraffe11.Parser


type ResBuilder() =
    member b.Bind(x, foo) =
        match x with
        | Ok y -> foo y
        | Error error -> Error error
    member b.Return x = Ok x
let resBuilder = ResBuilder()

let TryParseOperation arg2  =
        resBuilder{
        let! operationResult =
            match arg2 with  
            | "+" -> Ok "+"
            | "-" -> Ok "-"
            | "*" -> Ok "*"
            | "/" -> Ok "/"
            | _ -> Error "Wrong operation"
        return operationResult
        }

