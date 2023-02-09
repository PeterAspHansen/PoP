type pos = int*int //Position som består af 2 int.

///<summary> dist tager to positioner og returnere afstanden imellem dem </summary>
///<param name="p1"> Første position </param>
///<param name="p2"> Anden position </param>
///<returns> Afstand mellem de to positioner
let dist (p1:pos) (p2:pos) : int =
   let (x1,y1) = p1
   let (x2,y2) = p2
   (pown (x2-x1) 2) + (pown (y2-y1) 2)

///<summary> candidates2 tager en source position og en target position, og returnere alle nabo positionerne til source, hvor afstanden er mindre end afstanden
/// til target </summary>
///<param name="src"> source position </param>
///<param name="tg"> target position </param>
///<returns> Returnere de nabo afstande hvori afstanden er mindre hvor afstanden er mindre end afstanden til target
let candidates2 (src:pos) (tg:pos) : pos list = 
     let (x,y) = src
     let a = dist src tg
     let lst = [(x+1,y);(x-1,y);(x,y+1);(x,y-1);]
     let lst2 = [(x+1,y+1);(x+1,y-1);(x-1,y+1);(x-1,y-1)]
     let lst3 = lst@lst2
     List.filter (fun i -> (dist i tg) < a) lst3

///<summary> routes2 tager en source position og en target position returnere en liste af de korteste ruter </summary>
///<param name="src"> source position </param >
///<param name="tg"> target position </param >
///<returns > En liste med korteste liste.
let rec routes2 (src:pos) (tg:pos): pos list list =
    match src with
        k when src=tg -> [[tg]]
        |_->
            let cand = candidates2 src tg
            let y = List.map(fun i->List.map(fun j->src::j)(routes2 i tg))cand|>List.concat
            let a = List.length (List.min (y))
            List.filter (fun (i:pos list) -> (List.length i) = a) y
//Eksempel
printfn "routes2: %A" (routes2 (4,3) (1,1))