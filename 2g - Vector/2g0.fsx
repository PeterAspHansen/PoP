type vec = float*float

///<summary> add tager to vektorer og lægger dem sammen </summary>
/// <param name="a"> vektor. </param>
/// <param name="b"> vektor. </param>
/// <returns> resultatet af de to vektorer i form af en ny vektor </returns>
let add (a:vec)(b:vec): vec = 
    let x1,y1 = a
    let x2,y2 = b
    ((x1+x2),(y1+y2))

let vec1:vec = (1.0,2.0)
printfn "Den første vektor er: %A" vec1 
let vec2:vec = (2.0,3.0)
printfn "Den anden vektor er: %A" vec2
printfn "Summen af de to vektorer er: %A" (add vec1 vec2)

///<summary> mul tager én vektor og ganger den med konstanten k  </summary>
///<param name="a"> vektor. </param>
///<param name="k"> konstant. </param>
///<returns> en ny vektor som er k større end a. </returns> 
let mul (a:vec)(k:float): vec =
    let x,y = a
    ((x*k),(y*k))

printfn "Den første vektor ganget med 5 er: %A" (mul vec1 5) //vektoren ganges med konstanten 5 og printes

///<summary> rot tager én vektor og roterer den med vinklen a </summary>
///<param name="b"> vektor. </param>
///<param name="a"> en konstant vinkel. </param>
///<returns> den roterede vektor med vinklen a </returns>
let rot (b:vec)(a:float):vec =
    let x,y = b
    ((x*System.Math.Cos(a)-y*System.Math.Sin(a)),(x*System.Math.Sin(a)+y*System.Math.Cos(a)))

printfn "Den første vektor roteret med pi er: %A" (rot vec1 System.Math.PI) //vektoren roteres med pi og printes 




