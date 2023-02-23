module Queue

type queue<'a> = 'a list 
type element<'a> = 'a

///<summary> emptyQueue definerer en tom kø </summary>
///<returns> en tom liste </returns> 
let emptyQueue: queue<'a> = []

///<summary> enqueue tager et element og en liste og concatenator dem sammen</summary>
///<param name="a"> et element med som har er typen <'a> </param>
///<param name="lst"> en liste bestående af <'a> </param>
///<returns> en liste hvor a er tilføjet til sidst </returns>
let enqueue (a:element<'a>) (lst: queue<'a>): queue<'a> = lst@[a]

///<summary> isEmpty tager lst og vurderer om den er tom</summary>
///<param name="lst"> en liste bestående af elementer af typen <'a></param>
///<returns> True eller False </returns>
let isEmpty (lst:queue<'a>) = lst.IsEmpty 

///<summary> dequeue tager en liste og skiller det første element og de resterende elementer fra hinanden </summary>
///<param name="lst"> en liste bestående af elementer af en given type <'a> </param>
///<returns> det først element og en liste</returns>
let dequeue (lst:queue<'a>): (element<'a> option)*queue<'a> =
    match lst with
        [] -> None, lst
        |_-> Some lst.Head,lst.Tail
