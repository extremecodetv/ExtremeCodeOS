//легаси

open System

//Драйвер для обработки ввода с клавиатуры

let (|``String is "a"``|_|) s = if s = "a" then Some s else None
let (|``String is "aa"``|_|) s = if s = "aa" then Some s else None
let (|``String is "aaa"``|_|) s = if s = "aaa" then Some s else None
let (|``String is "b"``|_|) s = if s = "b" then Some s else None
let (|``String is "c"``|_|) s = if s = "c" then Some s else None
// TODO: Написать через 16 релизов модуль ОС для генерации кода для всех строк

let main argv =
    while true do
        let input = Console.ReadLine()
        match input with
        | ``String is "a"`` s -> s |> ignore
        | ``String is "aa"`` s -> s |> ignore
        | ``String is "aaa"`` s -> s |> ignore
        | ``String is "b"`` s -> s |> ignore
        | ``String is "c"`` s -> s |> ignore
        | _ -> raise (NotSupportedException("не вводить слишком сложные строки"))
    0
