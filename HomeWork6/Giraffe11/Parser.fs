module Giraffe11.Parser

open Input;

type CalculatorOperation =
    | Plus = 1
    | Minus = 2
    | Multiply = 3
    | Divide = 4

let TryParseOperationInput (problem:Input) =
    match problem.Operation with
    | "Plus" -> Ok CalculatorOperation.Plus
    | "Multiply" -> Ok CalculatorOperation.Multiply
    | "Minus" -> Ok CalculatorOperation.Minus
    | "Divide" -> Ok CalculatorOperation.Divide
    | _ -> Error "Wrong operation."  

