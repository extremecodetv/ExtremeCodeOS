open System

//Драйвер для обработки ввода с клавиатуры

[<EntryPoint>]
let main argv =
    while true do
        Console.ReadKey() |> ignore
    0