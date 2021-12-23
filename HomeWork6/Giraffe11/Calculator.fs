module Giraffe11.Calculator

open System
open Giraffe11
open Parser

    let inline Calculate (arg1:decimal) operation (arg2:decimal)  =
            if arg2 = 0.0m && operation = "/" then raise (DivideByZeroException $"You can't divide by zero")
            match operation with
            | "+" -> arg1 + arg2
            | "-" -> arg1 - arg2
            | "*" -> arg1 * arg2
            | "/" -> arg1 / arg2
