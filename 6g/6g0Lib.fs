module Game2048
open Canvas

type pos = int*int
type value = Red|Green|Blue|Yellow|Black
type piece = value*pos
type state = piece list

let rnd = System.Random()

let fromValue (v:value) : Canvas.color =
    match v with
        |Red -> Canvas.red
        |Green -> Canvas.green
        |Blue -> Canvas.blue
        |Yellow -> Canvas.yellow
        |Black -> Canvas.black

let nextColor (c:value) : value =
    match c with
        |Red -> Green
        |Green -> Blue
        |Blue -> Yellow
        |Yellow -> Black
        |Black -> Black

let filter (k:int) (s:state) : state =
    let func (k:int) (p:piece) : bool = 
        match p with
            |(c,(i,j)) when j = k -> true
            |_-> false
    List.filter (fun i -> func k i) (s)

let flipUD (s:state) : state =
    let func (p:piece) : piece =
        match p with 
            |(c,(i,j)) -> (c,(2-i,j))
    List.map func s

let transpose (s:state) : state = 
    let func (p:piece) : piece =
        match p with
            |(c,(i,j)) -> (c,(j,i))
    List.map func s

let empty (s:state) : pos list =
    let lst = [0..2] |> List.allPairs [0..2]
    let toPos = List.map (fun (c,(i,j)) -> (i,j)) s
    lst |> List.except toPos

let addRandom (c:value) (s:state) : state option = 
    match (empty s).Length with
        |0 -> None
        |_-> Some (s@[c,(empty s)[rnd.Next((empty s).Length)]])

let shiftLeft (s:state): state = 
    let rec merge (s:state) =
        match s with 
            |a::b::rst when fst a = fst b -> (nextColor (fst b),snd b) :: merge rst
            |a::rst -> a :: merge rst
            |[] -> []
    let shift i =
        s
        |> filter i
        |> List.sortBy (fun (c,(x,y)) -> x)
        |> merge
        |> List.mapi (fun n (c,(x,y)) -> (c,(n,y)))
    List.map shift [0..2] |> List.concat

let draw (w:int) (h:int) (s:state) : canvas = 
    let C = Canvas.create w h
    let rec func (s:state) : unit = 
        match s with
            [] -> ()
            |(c,(x,y)) :: rst -> 
                let vh = (10+(w/3)*x,10+(h/3)*y)
                let hh = ((w/3)*(1+x)-10,(h/3)*(1+y)-10)
                do setFillBox C (fromValue c) vh hh
                func (rst)
    func s
    C

let react (s:state) (k:key) : state option =
    match getKey k with
        |LeftArrow ->
            addRandom Red (shiftLeft s)
        | RightArrow -> 
             addRandom Red (flipUD s |> shiftLeft |> flipUD)
        | UpArrow -> 
            addRandom Red (transpose s |> shiftLeft |> transpose)
        | DownArrow -> 
            addRandom Red (transpose s |> flipUD |> shiftLeft |> flipUD |> transpose)