module Giraffe11.Calculator

open System
open Giraffe11
open Parser

let inline Calculate val1 operation val2 =
    match operation with
    | CalculatorOperation.Plus -> val1 + val2
    | CalculatorOperation.Multiply -> val1 * val2
    | CalculatorOperation.Minus -> val1 - val2
    | _ -> val1 / val2

