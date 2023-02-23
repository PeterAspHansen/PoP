module Tetris
open Canvas

type Color =
  | Yellow
  | Cyan
  | Blue
  | Orange
  | Red
  | Green
  | Purple
type position = int * int

///<summary> Konverterer vores type Color til en canvas farve</summary>
///<param name="c"> Color option </param>
///<returns> Canvas.color </returns>
val color: c: Color option -> color

type tetromino =
    new: a: bool[,] * c: Color * o: position -> tetromino
    override ToString: unit -> string
    
    ///<summary> skal rotere en tetromino med uret </summary> 
    ///<param> unit </param>
    ///<returns> et opdateret image, bool[,] </returns>
    member rotateRight: unit -> bool[,]

    ///<summary> skal fortælle hvilken farve en given tetromino er </summary> 
    ///<returns> Color </returns>
    member col: Color

    ///<summary> skal fortælle hvad højden af en given tetromino er</summary> 
    ///<returns> en integer værdi </returns>
    member height: int

    ///<summary> skal fortælle det nuværende koordinat for en given tetromino </summary>
    ///<returns> bool[,] </returns>
    member image: bool[,]

    ///<summary> skal fortælle hvad offset er for en given tetromino </summary>
    ///<returns> placeringen af offset som en position </returns>
    member offset: position

    ///<summary> skal fortælle hvad bredden af en given tetromino er </summary> 
    ///<returns> en integer værdi </returns>
    member width: int

type square =
    inherit tetromino
    new: unit -> square

type straight =
    inherit tetromino
    new: unit -> straight

type t1 =
    inherit tetromino
    new: unit -> t1

type l =
    inherit tetromino
    new: mirror: bool -> l

type z =
    inherit tetromino
    new: mirror: bool -> z

type board =
    new: w: int * h: int -> board

    ///<summary> fortæller om et givent træk for en given tetromino er validt </summary>
    ///<param name="t"> tetromino </param> 
    ///<param name="move"> tetrominoens position. </param>
    ///<returns> bool, der fortæller om trækket er validt.</returns>
    member isValid: t: tetromino * move: position -> bool

    ///<summary> generere en tilfælde tetromino option </summary>
    ///<param> unit </param> 
    ///<returns> en tetromino option </returns>
    member newPiece: unit -> tetromino option
    
    ///<summary> placere en ny tetromino og gør den til current </summary>
    ///<param name="t"> tetromino </param> 
    ///<returns> altid true </returns>
    member put: t: tetromino -> bool
    

    ///<summary> funktionen tager vores unit ud af spillet.</summary>
    ///<param> unit </param> 
    ///<returns> returnerer en tetrimino option </returns>
    member take: unit -> tetromino option

    ///<summary> Funktionen bruges til at opretholde og skabe overblik over vores board.  </summary>
    ///<param> unit </param> 
    ///<returns> den returnerer det nuværende board i et Color option liste format </returns>
    member board: Color option[,]

    ///<summary> denne metode viser den nuværende tetrimino så man har en måde at holde øje med den på</summary>
    ///<param>  </param> 
    ///<returns> Funktionen returnere en tetromino option </returns>
    member current: tetromino option

    ///<summary> højden af vores board</summary>
    ///<param>  </param> 
    ///<returns> returnerer højden på boardet som en integer </returns>
    member height: int

    ///<summary> bredden på vores board </summary>
    ///<param> </param>
    ///<returns> returnerer bredden på boardet som en integer </returns>
    member width: int

type state = board

///<summary> tegner vores board</summary>
///<param name="w"> breden af vores board </param>
///<param name="h"> højden af vores board </param>
///<param name="s"> state </param>
///<returns> et canvas med ternede felter </returns>
val draw: w: int -> h: int -> s: state -> canvas

///<summary> funktionen opdaterer board når piletasterne trykkes på </summary>
///<param name ="s"> state </param>
///<param name ="k"> den tast på tastaturet der trykkes på </param>
///<returns> returnerer en state option efter man har trykket på en key </returns>
val react: s: state -> k: key -> state option

