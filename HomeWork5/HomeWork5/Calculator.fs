module HomeWork5.Calculator

open Parser

    let Calculate (arg1 : decimal) operation (arg2 : decimal) =
        if arg2 = (decimal) 0 && operation = "/"
            then Failure "You can't divide by zero"
        else
            let res = 
                match operation with
                | "+" -> arg1 + arg2
                | "-" -> arg1 - arg2
                | "*" -> arg1 * arg2
                | "/" -> arg1 / arg2
            Success res
        
