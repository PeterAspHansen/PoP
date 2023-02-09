let rec readNonZeroValue () =
    let (a:string) = System.Console.ReadLine ()
    match a with
        "fsharp" ->
            printfn "fsharp is cool" 
            printfn "Please enter a programming language:"
            readNonZeroValue ()
        |"quit" -> 
            ()   
        |_ -> 
            printfn "I don't know %A" a
            printfn "Please enter a programming language:"
            readNonZeroValue ()
printfn "Please enter a programming language:"
let b = readNonZeroValue ()
b
