module Tetris
open Canvas

type Color = Yellow | Cyan | Blue | Orange | Red | Green | Purple

type position = int*int

let color (c:Color option) : Canvas.color =
    match c with
        | None -> white
        | Some Yellow -> yellow
        | Some Cyan -> fromRgb(0,255,255)
        | Some Blue -> blue
        | Some Orange -> fromRgb(255,164,0)                                                                                                     
        | Some Red -> fromRgb(255,0,0) 
        | Some Green -> green
        | Some Purple -> fromRgb(255,0,255)
        
type tetromino (a:bool[,], c:Color, o:position) =
    let mutable _image = a
    let mutable _color = c
    let mutable _offset = o

    member this.image
        with get() = _image
        and set (a) = _image <- a
    member this.col = _color
    member this.offset  
        with get() = _offset
        and set (a) = _offset <- a

    member this.height = Array2D.length2 this.image
    member this.width = Array2D.length1 this.image
    member this.rotateRight() = 
        let h = this.height
        let w = this.width
        Array2D.init this.height this.width (fun j i -> this.image[w-1-j,i])
    
    override this.ToString() = sprintf "%A" (this.image)

type square() =
    inherit tetromino((Array2D.create 2 2 true),Yellow,(4,0))

type straight() =
    inherit tetromino((Array2D.create 4 1 true), Cyan, (3,0))

type t1()=
    inherit tetromino((Array2D.create 3 2 true), Red, (4,1))
    do
        base.image[0,0] <- false
        base.image[2,0] <- false

type l(mirror:bool) =
    inherit tetromino((Array2D.create 3 2 true),(if mirror then Orange else Blue),(3,0))
    do
        if mirror then
            do
                base.image[0,0] <- false
                base.image[1,0] <- false
        else
            do
                base.image[1,0] <- false
                base.image[2,0] <- false

type z (mirror:bool) =
    inherit tetromino((Array2D.create 3 2 true),(if mirror then Green else Red),(3,0))
    do
        if mirror then
            do
                base.image[0,0] <- false
                base.image[2,1] <- false
        else
            do
                base.image[2,0] <- false
                base.image[0,1] <- false


type board (w:int, h:int) =
    let _board = Array2D.create w h None
    let mutable (t:tetromino option) = None

    let isOccupied(t:tetromino, newo) : bool =
        let (x,y) = newo
        let mutable occupied = false
        for i = x to (Array2D.length1(t.image)-1+x) do
            for j = y to (Array2D.length2(t.image)-1+y) do
                if (t.image[i-x,j-y]=true) && _board[i,j].IsSome then
                    occupied <- true
        occupied

    member this.width = w

    member this.height = h

    member this.board : Color option[,] = _board

    member this.newPiece() : tetromino option = 
        let rnd = System.Random()
        let piece = 
            match rnd.Next(6) with 
                |0 -> (straight()):> tetromino
                |1 -> (square()) :> tetromino
                |2 -> (t1()) :> tetromino
                |3 -> (l(true)):> tetromino
                |4 -> (l(false)):> tetromino
                |5 -> (z(true)):> tetromino
                |_ -> (z(false)):> tetromino
        Some piece

    member this.current
        with get()= t 
        and set(a) = t <- a

    
    member this.put (t:tetromino) : bool =
        let (a,b) = t.offset
        Array2D.iteri (fun i j image -> if (_board[i,j].IsSome) then () elif image = true then _board[a+i,b+j] <- Some t.col) t.image
        this.current <- Some t 
        true

    member this.take() : tetromino option = // Tager en brik og undersøger, hvordan en prik kan placeres
        let mutable a = Option.get(this.current)
        let (x,y) = a.offset
        Array2D.iteri (fun i j image -> if image=true then _board[x+i,y+j] <- None) a.image
        Some a
    
    member this.isValid(t:tetromino,move:position): bool =
        let (x,y) = t.offset
        let mutable valid = false
        let newo = (x+(fst move),y+(snd move))
        if  (w - t.width + 1 > (fst newo)) && (h - t.height + 1 > (snd newo)) && ((fst newo) >= 0) && ((snd newo)>= 0)  then
            if isOccupied(t,newo) then 
                valid <- false
            else    
                valid <- true  
        else
            valid <- false
        valid

type state = board
let draw (w: int) (h: int) (s: state) =
    let C = Canvas.create w h
    let y = h/s.height
    let x = w/s.width
    s.board |> Array2D.iteri (fun x' y' e -> if e.IsSome then do setFillBox C (color e) (x*x',y*y') (x*(x'+1),y*(y'+1)))
    C

let react (s:state) (k:Canvas.key) : state option =
    let checkIsDead(x) =
        if (s.isValid(x,(1,1))) || (s.isValid(x,(-1,1))) || (s.isValid(x,(0,1))) then 
            false
        else 
            true
    
    let mutable isDead = false
    let endPiece(x:bool) =
        if x=true then 
            s.newPiece() |> Option.get |> s.put |> ignore
            Some s
        else 
            Some s    
    let x = Option.get(s.take())
    match getKey k with
        |LeftArrow ->
            let (x1,y1) = x.offset
            if s.isValid(x,(-1,1)) then
                x.offset <- (x1-1,y1+1)
                isDead <- checkIsDead(x)
                s.put(x)
            else 
                isDead <- checkIsDead(x)
                s.put(x)
            endPiece(isDead)
        | RightArrow ->
            let (x1,y1) = x.offset
            if s.isValid(x,(1,1)) then
                x.offset <- (x1+1,y1+1)
                isDead <- checkIsDead(x)
                s.put(x)
            else 
                isDead <- checkIsDead(x)
                s.put(x)
            endPiece(isDead)

        | UpArrow ->
            x.image <- x.rotateRight()
            s.put(x)
            checkIsDead(x)
            Some s
            
        | DownArrow ->  
            let (x1,y1) = x.offset
            if s.isValid(x,(0,1)) then
                x.offset <- (x1,y1+1)
                isDead <- checkIsDead(x)
                s.put(x)
            else 
                isDead <- checkIsDead(x)
                s.put(x)
            endPiece(isDead)
        |_-> None

let b = board(10,20)
b.newPiece()|> Option.get |> b.put
runApp "Tetris" 300 600 draw react b
