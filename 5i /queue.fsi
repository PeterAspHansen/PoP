module Queue

type queue<'a> = 'a list 
type element<'a> = 'a
// check if a queue is empty
val isEmpty: queue<'a> -> bool
// the empty queue
val emptyQueue: queue<'a>
// add an element at the end of a queue
val enqueue: element<'a> -> queue<'a> -> queue<'a>
// remove and return the element at the front of a queue
val dequeue: queue<'a> -> (element<'a> option)*queue<'a>