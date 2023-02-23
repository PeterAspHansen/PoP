open CyclicQueue

[<EntryPoint>]
let main _ =
    // Test af create på et negativt tal, nul og et højt tal.
    // CyclicQueue.create -1 |> ignore //Test om queue virker -1
    // CyclicQueue.create 0 |> ignore //Test om queue virker på 0
    // CyclicQueue.create 1000 |> ignore //Test om queue virker på et højt tal

    CyclicQueue.create 4 |> ignore //Qeuee til at teste de andre funktioner
    CyclicQueue.isEmpty() |> ignore //Tester om Qeuee er tom. Forventer True, da der ingen elementer er i den
    CyclicQueue.enqueue 1 |> ignore
    CyclicQueue.isEmpty() |> ignore 

//Test af enqueue og dequeue
    CyclicQueue.enqueue 2 |> ignore
    CyclicQueue.enqueue 3 |> ignore
    CyclicQueue.enqueue 4 |> ignore
    CyclicQueue.enqueue 5 |> ignore //Forventer fejl fra denne enqueue, da queue er fuld

    // //Dequeue af de 3 foreste elementer. 
    CyclicQueue.dequeue() |> ignore //Forventer Some 1
    CyclicQueue.dequeue() |> ignore //Forventer Some 2
    CyclicQueue.dequeue() |> ignore //Forventer Some 3

    CyclicQueue.enqueue 6 |> ignore
    CyclicQueue.enqueue 7 |> ignore
    CyclicQueue.enqueue 8 |> ignore

    CyclicQueue.dequeue() |> ignore
    CyclicQueue.dequeue() |> ignore
    CyclicQueue.length() |> ignore
    CyclicQueue.toString() |> ignore
    0
