module HomeWork4.Calculator

open System
open System
let Calculate arg1 operation arg2 =
    if arg2 = 0 && operation = "/" then raise (DivideByZeroException $"You can't divide by zero")
    match operation with
    | "+" -> arg1 + arg2
    | "-" -> arg1 - arg2
    | "*" -> arg1 * arg2
    | "/" -> arg1 / arg2
    | _ -> raise (ArgumentException "You have invalid value")
        
        
