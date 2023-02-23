module SafeIntQueue

type queue = int list 
type element = int

///<summary> emptyQueue definerer en tom kø </summary>
///<returns> en tom liste </returns> 
let emptyQueue: queue = []

///<summary> enqueue tager et element og en liste og concatenator dem sammen</summary>
///<param name="a"> et element med som har en heltalsværdi </param>
///<param name="lst"> en liste bestående af heltal </param>
///<returns> en liste hvor a er tilføjet til sidst </returns>
let enqueue (a:element) (lst: queue): queue = lst@[a]

///<summary> isEmpty tager lst og vurderer om den er tom</summary>
///<param name="lst"> en liste bestående af heltal </param>
///<returns> True eller False </returns>
let isEmpty (lst:queue) = lst.IsEmpty 

///<summary> dequeue tager en liste og skiller det første element og de resterende elementer fra hinanden </summary>
///<param name="lst"> en liste bestående af heltal </param>
///<returns> det først element som et heltal og en heltalsliste</returns>
let dequeue (lst:queue): (element option)*queue =
    match lst with
        [] -> None, lst
        |_-> Some lst.Head,lst.Tail






