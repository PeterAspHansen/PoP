module SafeIntQueue
type element = int
type queue = element list
// check if a queue is empty
val isEmpty: queue -> bool
// the empty queue
val emptyQueue: queue
// add an element at the end of a queue
val enqueue: element -> queue -> queue
// remove and return the element at the front of a queue
val dequeue: queue -> (element option)*queue
