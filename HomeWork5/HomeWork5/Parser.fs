module HomeWork5.Parser

type ErrorTypes =
    | WrongArgFormat = 1
    | WrongArgLen = 2
    | WrongOperationFormat = 3
    | DivideByZero = 4

type Operation =
    | Add
    | Subtract
    | Multiply
    | Divide
    | None


type MaybeBuilder() =
    member b.Bind(x, foo) =
        match x with
        | Ok y -> foo y
        | Error error -> Error error
    member b.Return x = Ok x
let maybeBuilder = MaybeBuilder()

let ParseOperation (args:string[]) =
    maybeBuilder{
        let! operationResult=
            match args.[1] with 
            | "+" -> Ok Operation.Add
            | "-" -> Ok Operation.Subtract
            | "*" -> Ok Operation.Multiply
            | "/" -> Ok Operation.Divide
            | _ -> Error ErrorTypes.WrongOperationFormat
    
        return args.[0], operationResult, args.[2]
    }
let CheckArgLength (args: string[]) =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error ErrorTypes.WrongArgLen

let ParseArgs (arg1:string, operation:Operation, arg2:string) =
    try
        Ok (arg1 |> decimal, operation, arg2 |> decimal)
    with
        | _ -> Error ErrorTypes.WrongArgFormat

let CheckDivideByZero (args: string[]) =
    if args.[1]="/" & args.[2]="0" 
    then Error ErrorTypes.DivideByZero
    else Ok args

let Parse (args:string[]) =
    maybeBuilder{
        let! First = CheckArgLength args
        let! Second = CheckDivideByZero First
        let! Third = ParseOperation Second
        let! Fourth = ParseArgs Third 
        return Fourth
    }
    

