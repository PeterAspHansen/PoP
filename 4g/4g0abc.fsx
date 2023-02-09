type pos = int*int //Position som består af 2 int.

///<summary> dist tager to positioner og returnere afstanden imellem dem </summary>
///<param name="p1"> Første position </param>
///<param name="p2"> Anden position </param>
///<returns> Afstand mellem de to positioner
let dist (p1:pos) (p2:pos) : int =
   let (x1,y1) = p1
   let (x2,y2) = p2
   (pown (x2-x1) 2) + (pown (y2-y1) 2)
//Example
printfn "dist: %A" (dist (1,1) (3,3))

///<summary> candidates tager en source position og en target position, og returnere de lodrette og vandrette nabo positionerne til source, hvor afstanden er mindre </summary>
///<param name="src"> source position </param>
///<param name="tg"> target position </param>
///<returns> Returnere de nabo afstande hvori afstanden er mindre hvor afstanden er mindre end afstanden til target
let candidates (src:pos) (tg:pos) : pos list = 
  let x,y = src
  let a = dist src tg
  let lst = [((x+1),y);((x-1),y);(x,(y+1));(x,(y-1))]
  List.filter (fun (x,y) -> (dist (x,y) tg) < a) lst
//Example
printfn "candidates: %A" (candidates (1,1) (3,3))

///<summary> routes tager en source position og en target position og danner en liste med alle mulige ruter </summary>
///<param name="src"> source position </param >
///<param name="tg"> target position </param >
///<returns > en liste af lister som
let rec routes (src:pos) (tg:pos): pos list list =
    match src with
        k when src=tg -> [[tg]]
        |_->
            let cand = candidates src tg
            List.map (fun i -> List.map (fun j -> src::j) (routes i tg)) cand |> List.concat
//Example
printfn "routes: %A" (routes (3,3) (1,1))