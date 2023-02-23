module testQueues

//test for intQueue
printfn "Test for IntQueue"
let intQueueTests () =
    let q0 = IntQueue.emptyQueue
    let emptyTestResult = IntQueue.isEmpty q0
    emptyTestResult
    |> printfn "An empty queue is empty: %A"
    
    let e1 ,e2 ,e3 = 1,2,3
    let q1 = q0 |> IntQueue.enqueue e1
                |> IntQueue.enqueue e2
                |> IntQueue.enqueue e3
    let nonEmptyTestResult = not (IntQueue.isEmpty q1)

    nonEmptyTestResult
    |> printfn "A queue with elements is not empty: %A"

    let (e,q2) = IntQueue.dequeue q1
    let dequeueTestResult = e = e1
    dequeueTestResult
    |> printfn "First in is first out: %A"

    let allTestResults =
        emptyTestResult &&
        nonEmptyTestResult &&
        dequeueTestResult

    allTestResults
    |> printfn "All IntQueue tests passed: %A
     "
    // Return the test results as a boolean
    allTestResults
// Run the IntQueue tests
let intQueueTestResults = intQueueTests ()

//test for safeIntQueue
printfn "Test for safeIntQueue"
let safeIntQueueTests () =
    let (q0:SafeIntQueue.queue) = SafeIntQueue.emptyQueue
    let emptyTestResult:bool = SafeIntQueue.isEmpty q0
    emptyTestResult
    |> printfn "An empty queue is empty: %A"
    
    let e1 ,e2 ,e3 = 1,2,3
    let q1 = q0 |> SafeIntQueue.enqueue e1
                |> SafeIntQueue.enqueue e2
                |> SafeIntQueue.enqueue e3
    let nonEmptyTestResult = not (SafeIntQueue.isEmpty q1)

    nonEmptyTestResult
    |> printfn "A queue with elements is not empty: %A"

    let (e,q2) = SafeIntQueue.dequeue q1
    let dequeueTestResult = e = Some e1
    dequeueTestResult
    |> printfn "First in is first out: %A"

    let allTestResults =
        emptyTestResult &&
        nonEmptyTestResult &&
        dequeueTestResult

    allTestResults
    |> printfn "All safeIntQueue tests passed: %A"
    // Return the test results as a boolean
    allTestResults
// Run the SafeIntQueue tests
let Testdequeue = SafeIntQueue.dequeue SafeIntQueue.emptyQueue = (None,[]) 
printfn "dequeue returns None with input []: %b" Testdequeue 
let SafeIntQueueTestResults = safeIntQueueTests ()



//test for Queue
let QueueTests a b c =
    let (q0:Queue.queue<'a>) = Queue.emptyQueue
    let emptyTestResult = Queue.isEmpty q0
    emptyTestResult
    |> printfn "An empty queue is empty: %A"
    
    let e1 ,e2 ,e3 = a,b,c
    let q1 = q0 |> Queue.enqueue e1
                |> Queue.enqueue e2
                |> Queue.enqueue e3
    let nonEmptyTestResult = not (Queue.isEmpty q1)

    nonEmptyTestResult
    |> printfn "A queue with elements is not empty: %A"

    let (e,q2) = Queue.dequeue q1
    let dequeueTestResult = e = Some e1
    dequeueTestResult
    |> printfn "First in is first out: %A"

    let allTestResults =
        emptyTestResult &&
        nonEmptyTestResult &&
        dequeueTestResult

    allTestResults
    |> printfn "All Queue tests passed: %A 
     "
    // Return the test results as a boolean
    allTestResults
// Run the Queue tests
printfn "
Test for Queue with int"
let QueueTestResultsInt = (QueueTests 1 2 3) 
printfn "
Test for Queue with float"
let QueueTestResultsFloat = (QueueTests 1.0 2.0 3.0)
printfn "
Test for Queue with string"
let QueueTestResultsString = (QueueTests "a" "b" "c")

