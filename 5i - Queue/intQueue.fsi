module IntQueue
//definer queue som en heltals liste
type queue = int list 
//definer elementerne i queue som heltal 
type element = int
// Den tomme kø
val emptyQueue: queue
// Tilføj et element i slutningen af køen
val enqueue: element -> queue -> queue
// Fjern og returner elementet foran køen 
// precondition: input i køen må ikke være tom
val dequeue: queue -> element * queue
// Tjek om køen er tom
val isEmpty: queue -> bool
