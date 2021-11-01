open System
open System.Runtime.CompilerServices

[<MethodImpl(MethodImplOptions.AggressiveInlining)>]
let a = [ 'a' .. 'z' ]

let (%&*+-./<=>?@^|!%@./&*+@^|!>?@^./&*+) d a =
    let i = a |> List.findIndex(fun v->d=v) |> (+) 1
    match i with
    | n when n < a.Length -> a.[i]
    | _ -> d

[<EntryPoint>]
let mn _ =
    let rec m i a = 
        match a with
        | h::t -> 
            if h.ToString() = i 
            then h %&*+-./<=>?@^|!%@./&*+@^|!>?@^./&*+ a
            else m i t
        | [] -> failwith "не вводить слишком сложные строки"

    while true do
        let i = Console.ReadLine()
        printfn "%c" (m i a)
    0
