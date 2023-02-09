#r "nuget:diku.canvas, 1.0.1"
open Canvas
type move = int*int // a pair of turn and move
let lst = [(10, 30); (-5, 127); (20, 90)]

///<summary> fromMoveRec er en rekursiv funktion som laver en turtleCmd list </summary>
///<param name="lst"> En liste af tupler som er et par af turn og move </param>
///<returns> En turtleCmd liste med turtle kommandoerne Turn og Move </returns>
let rec fromMoveRec (lst:move list): Canvas.turtleCmd list=
    match lst with
    [] -> []
    |(dir,dist)::t -> Turn dir::Move dist::(fromMoveRec t)

do turtleDraw (500,500) "Rec" (fromMoveRec lst)

///<summary> fromMoveMap laver en turtleCmd list vha. List.map modulet </summary>
///<param name="lst"> En liste af tupler hvor tuplerne er par af turn og move </param>
///<returns> En turtleCmd liste med turtle kommandoerne Turn og Move </returns>

let fromMoveMap (lst:move list): Canvas.turtleCmd list =
    List.map(fun ((dir,dist):move) -> [Turn dir;Move dist]) lst |> List.concat

do turtleDraw (500,500) "map" (fromMoveMap lst)

///<summary> top1 er en funktion som benyttes i List.fold modulet </summary>
///<param name="acc"> En accumulator som defineres i List.fold modulet </param>
///<param name="(dir,dist)"> En tupel bestaaende af vores par af turn og move </param>
///<returns> vores accumulator concatenated med en liste af Turn og Move  <returns>
let top1 acc (dir,dist) = acc@[Turn dir;Move dist] 

///<summary> fromMoveFold laver en turtleCmd list vha. List.fold modulet </summary>
///<param name="lst"> En liste af tupler som er par af turn og move </param>
///<returns> En turtleCmd liste med turtle kommandoerne Turn og Move </returns>
let fromMoveFold (lst:move list): Canvas.turtleCmd list =
    List.fold top1 [] lst 

do turtleDraw (500,500) "Fold" (fromMoveFold lst)

///<summary> top2 er en funktion som benyttes i List.foldBack modulet </summary>
///<param name="(dir,dist)"> En tupel bestaaende af vores par af turn og move </param>
///<param name="acc"> En accumulator som defineres i List.foldBack modulet </param>
///<returns> en liste af Turn og Move concatenated med vores accumulator <returns>
let top2 (dir,dist) acc  = [Turn dir;Move dist]@acc

///<summary> fromMoveFoldBack laver en turtleCmd list vha. List.foldBack modulet </summary>
///<param name="lst"> En liste af tupler som er et par af turn og move </param>
///<returns> En turtleCmd liste med turtle kommandoerne Turn og Move </returns>
let fromMoveFoldBack (lst:move list): Canvas.turtleCmd list =
    List.foldBack top2 lst []

do turtleDraw (500,500) "foldBack" (fromMoveFoldBack lst)