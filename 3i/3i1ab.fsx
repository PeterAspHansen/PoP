#r "nuget:diku.canvas , 1.0.1"
open Canvas


///<summary> tree tager en int vaerdi og rekursivt generere en liste. </summary>    
///<param name="sz"> int vaerdi som definere størrelsen af traeet.</param>
///<returns> output er en turtleCmd list. </returns>
let rec tree (sz: int) : Canvas.turtleCmd list =
    if sz < 5 then
        [Move sz; PenUp; Move (-sz); PenDown]
    else
    [Move (sz/3); Turn -30]
        @ tree (sz*2/3)
        @ [Turn 30; Move (sz/6); Turn 25]
        @ tree (sz/2)
        @ [Turn -25; Move (sz/3); Turn 25]
        @ tree (sz/2)
        @ [Turn -25; Move (sz/6)]
        @ [PenUp; Move (-sz/3); Move (-sz/6); Move (-sz/3)]
        @ [Move (-sz/6); PenDown]

//Vi definerer variabler til turtleDraw
let w = 600
let h = w
let sz = 100

//turtleDraw tager listen fra tree og tegner et træ i Canvas. 
turtleDraw (w,h) "Tree" (tree sz) 


let rnd = System.Random ()
///<summary> randomTree tager en int vaerdi og rekursivt generere en liste. </summary>    
///<param name="sz"> int vaerdi som definere stoerrelsen af traeet.</param>
///<returns> output er en turtleCmd list. </returns>
let randomTree (sz:int): Canvas.turtleCmd list= 
    let (dist:int) = rnd.Next 300
    let (dir:int) = rnd.Next 360
    [PenUp; Turn(dir); Move(dist); Turn(-dir); PenDown]
    @tree sz
    @[PenUp; Turn(180+dir); Move(dist); Turn(-dir+180); PenDown]

//turtleDraw tager listen fra randomTree og et trae i Canvas hvor placeringen er tilfaeldig. 
turtleDraw (w,h) "randomTree" (randomTree sz) 

///<summary> forest tager to int vaerdier og rekursivt generere en liste. </summary>    
///<param name="sz"> int vaerdi som definere stoerrelsen af et trae.</param>
///<param name="n"> int vaerdi som definere antallet af traeer. </param>
///<returns> output er en turtleCmd list. </returns>
let rec forest (sz:int) (n:int):Canvas.turtleCmd list =  
    match n with
    0 -> []
    |_-> randomTree sz
        @forest sz (n-1)

let n=50
//turtleDraw tager listen fra forest og tegner n traeer i Canvas. 
turtleDraw (w,h) "forest" (forest sz n)

 





