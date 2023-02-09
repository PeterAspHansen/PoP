type vec = float*float

///<summary> toInt tager float elementerne i en vektor og konverterer dem til int. </summary>
///<param name="a"> vektor. </param>
///<returns> vektor uden decimaler. </returns> 
let toInt (a:vec):int*int=
    let x,y = a
    (int(System.Math.Round(x,0)),(int(System.Math.Round(y,0))))

let vec1:vec = (1.0,2.5)    
printfn "Vektoren er: %A" vec1
printfn "Vektoren afrundet til int er: %A" (toInt vec1)

#r "nuget:DIKU.Canvas, 1.0"
open Canvas

let w = 400;
let h = 400; 
let C1 = create w h 
let p1:vec=(200.0,200.0)
let v1:vec=(200.0,0.0)
let c1 = black

///<summary> add tager to vektorer og lægger dem sammen </summary>
/// <param name="a"> vektor. </param>
/// <param name="b"> vektor. </param>
/// <returns> resultatet af de to vektorer i form af en ny vektor </returns>
let add (a:vec)(b:vec): vec = 
    let x1,y1 = a
    let x2,y2 = b
    ((x1+x2),(y1+y2))

///<summary> setVector tager fire argumenter, et canvas, en farve, en vektor og en position, og tegner et linje </summary>
/// <param name="C"> canvas. </param>
/// <param name="c"> farve. </param>
/// <param name="v"> vektor. </param>
/// <param name="p"> punkt. </param>
///<returns> En horisontal linje fra p til p+v. </returns> 
let setVector (C) (c) (v:vec) (p:vec) = 
    let pv:vec = add p v
    do setLine C c (toInt p) (toInt pv)
    

setVector C1 c1 v1 p1 //

///<summary> rot tager én vektor og roterer den med vinklen a </summary>
///<param name="b"> vektor. </param>
///<param name="a"> en konstant vinkel. </param>
///<returns> den roterede vektor med vinklen a </returns>
let rot (b:vec)(a:float):vec =
    let x,y = b
    ((x*System.Math.Cos(a)-y*System.Math.Sin(a)),(x*System.Math.Sin(a)+y*System.Math.Cos(a)))

///<summary> draw tager to argumenter w og h og danner et canvas vha et while loop </summary>
/// <param name="w"> bredde af canvas. </param>
/// <param name="h"> højden af canvas </param>
///<returns> 36 linjer som er roteret med 10 grader per gang.</returns> 
let n = 36
let j = (2.0*System.Math.PI)/float n
let C = create w h
let g = (0.0, float(h/2))
let draw (w: int) (h:int) = 
     let rec fan C col g j n =
         match n with 
            0 -> ()
            | _ -> 
                let v = rot g (float n*j)
                setVector C col v ((float w)/2.0,(float h)/2.0)
                fan C col g j (n-1) 
     fan C green g j n
     do show C "Canvas"

draw 400 400


