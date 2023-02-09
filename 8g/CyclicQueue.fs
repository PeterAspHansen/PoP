module CyclicQueue

type Value = int
let mutable first : Value Option = None
let mutable last : Value Option = None
let mutable queue : Value Option [] = [||]

let create (n: int) : unit =
    if n <= 0 then 
        // printfn "Invalid input. n needs to be greater than 0" // Bruges til test
        ()
    else
        queue <- Array.create n None
        // printfn "Qeueue succesfully created" // Bruges til test

let isEmpty () : bool =
    if first.IsNone then
        // printfn "Is queue empty? True" // Bruges til test
        true
    else
        // printfn  "Is queue empty?: False" // Bruges til test
        false

let length () : int =
    let a = queue.Length
    let b = queue |> Array.filter (fun i -> i = None) |> Array.length
    let c = a - b
    // printfn "Queue length is: %A" c
    c

let enqueue (e: Value) : bool =
    let len = length()
    if first.IsNone then
        first <- Some 0 
        last <- Some 0
        queue.[0] <- Some e
        printfn "%A" queue //Bruges til test
        true
    elif (queue.Length = length()) then
        // printfn "Cannot enqueue on full queue" //Bruges til test
        false
    else
        if (last.Value = queue.Length-1) then
            last <- Some (0)
            queue.[last.Value] <- Some e
            // printfn "%A" queue //Bruges til test
            true
        else
            last <- Some (last.Value + 1)
            queue.[last.Value] <- Some e
            // printfn "%A" queue //Bruges til test
            true

let dequeue () : Value option =
    if first.IsNone then
        // printfn "Cannot dequeue on empty queue" //Bruges til test
        None
    else
        if (first.Value = queue.Length-1) then
            printfn "%A" queue.[first.Value]
            queue.[first.Value] <- None
            first <- Some (0)
            // printfn "%A" queue //Bruges til test
            None
        else
            printfn "%A" queue.[first.Value]
            queue.[first.Value] <- None
            first <- Some (first.Value + 1)
            // printfn "%A" queue //Bruges til test
            None

let toString () : string =
    let c = queue |> Array.choose id
    let a = c |> Array.length
    let mutable b = ""
    for i = 0 to (a-1) do 
        b <- b + (string(c[i])) + " "
    printfn "%A" b
    b