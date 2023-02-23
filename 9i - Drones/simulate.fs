type vec = int*int

///<summary> udregner længden mellem to vektorer </summary>
///<param name = "x y"> vektorer </param>
///<returns> en længden mellem vektorerne som int værdi </returns>
let vectorLength (x:vec)(y:vec): int = 
    let len = (pown (fst y - fst x) 2 + pown (snd y - snd x) 2)
    int(sqrt(float(len)+0.5))
    
///<summary> bestemmer en ny position baseret på hastighed og retningen fra a til b </summary>
///<param name = "a b"> vektorer </param>
///<param name = "s"> hastighed </param>
///<returns> en ny vektor</returns>
let addPosition (a:vec)(b:vec)(s:int): vec =
    let len = vectorLength a b
    let d = float(s)/float(len)
    let x = float(fst a) + float(d) * (float(fst b) - float(fst a))
    let y = float(snd a) + float(d) * (float(snd b) - float(snd a))
    (int(x+0.5),int(y+0.5))


type Drone (startpos:vec,dest:vec,speed:int,name:string) = 
    
    let mutable p = startpos
    let mutable d = dest
    let mutable s = speed
    let mutable landed = false
    let mutable crashed = false 

    ///<summary>Tjekker om dronen er styrtet </summary>
    ///<returns> en boolean der fortæller om dronen er styrtet </returns>
    member this.Crashed = crashed

    ///<summary> opdaterer værdien af crashed til true aka styrter dronen</summary>
    ///<param name="()"> unit nødvendig for at kalde metoden </param>
    ///<returns> true </returns>
    member this.Crash() = crashed <- true

    ///<summary> property der viser dronens position </summary>
    ///<returns> dronens position </returns> 
    member this.Position = p
    
    ///<summary> property der viser dronens hastighed </summary>
    ///<returns> dronenes hastighed </returns> 
    member this.Speed = s

    ///<summary> property der viser dronens destination </summary>
    ///<returns> dronens destination </returns>
    member this.Destination = d

    ///<summary> method der fortæller om dronen er landet </summary>
    ///<param name="()"> unit nødvendig for at kalde metoden </param>
    ///<returns> boolean værdi </returns> 
    member this.AtDestination():bool = landed

    ///<summary> Bevæger dronen til en ny position ud fra hastigheden </summary>
    ///<param name="()"> unit nødvendig for at kalde metoden </param>
    ///<returns> en opdateret værdi af p </returns> 
    member this.Fly () = 
        if (landed=true) || (crashed=true) then
            ()
        elif (vectorLength p d)<= s then
            landed <- true
            p <- d
        else 
            p <- addPosition p d s
    
    override this.ToString () = sprintf "%A" (p,name)

type Airspace() =
    let mutable drones : Drone list = []

    ///<summary> en property der viser listen af droner </summary>
    ///<returns> listen af droner </returns>
    member this.Drones = drones

    ///<summary> bestemmer afstanden mellem to drone positioner </summary>
    ///<param name="a b"> Dronerne vi tjekker afstanden mellem </param>
    ///<returns> returnerer afstand som int værdi </returns>
    member this.droneDist (d1: Drone)(d2:Drone) = 
        let pos1 = d1.Position
        let pos2 = d2.Position
        vectorLength pos1 pos2

    ///<summary> kalder Fly() på alle elementer i drone list </summary>
    ///<param name = "()"> unit nødvendig for at kalde metoden </param>
    ///<returns> en drone liste hvor positionerne af alle droner er opdateret position </returns> 
    member this.FlyDrones () =
        for i in [0..(drones.Length-1)] do
            drones.[i].Fly()

    ///<summary> tilføjer en ny drone til drone list </summary>
    ///<param name="drone"> en drone </param> 
    ///<returns> en drone liste </returns>
    member this.addDrone drone=
        drones <- drones@[drone] 

    ///<summary> dronerne sættes i bevægelse og der analyseres om de kollidere med hinanden </summary>
    ///<param name="t"> konstant der bestemmer hvor mange gange FlyDrones() kaldes. Kan tænkes som tid </param>
    ///<returns> en (Drone*Drone) liste bestående af de droner som er kollideret. Yderligere fjernes disse droner også fra drone list </returns>
    member this.Collide (t:int): (Drone*Drone) list = 
        let mutable collision: (Drone*Drone) list = []
        for x=0 to (t-1) do 
            this.FlyDrones()
            for i=0 to (drones.Length-1) do 
                for j=i+1 to (drones.Length-1) do 
                    if (this.droneDist (drones.[i])(drones.[j]) <= 5 && not ((drones.[i].AtDestination()) || drones.[j].AtDestination())) then
                        collision <- collision @ [drones.[i],drones.[j]]
                        drones.[i].Crash()
                        drones.[j].Crash()
                        ()
                    else 
                        ()
            drones <- List.filter (fun d -> not d.Crashed) drones 
        collision






