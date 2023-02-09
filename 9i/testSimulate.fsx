type vec = int*int

let vectorLength (x:vec)(y:vec): int = 
    let len = (pown (fst y - fst x) 2 + pown (snd y - snd x) 2)
    int(sqrt(float(len)+0.5))

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

    member this.Crashed = crashed

    member this.Crash() = crashed <- true

    member this.Position = p
    
    member this.Speed = s

    member this.Destination = d

    member this.AtDestination():bool = landed

    member this.Fly () = 
        if (landed=true) || (crashed=true) then
            ()
        elif (vectorLength p d)<= s then
            landed <- true
            p <- d
        else 
            p <- addPosition p d s
    
    override this.ToString () = sprintf "%A" (p,name)

let d = Drone((15,40),(40,15),2,"d")
d.Fly()
printfn "%A" d.Position

type Airspace() =
    let mutable drones : Drone list = []

    member this.Drones = drones

    member this.droneDist (d1: Drone)(d2:Drone) = 
        let pos1 = d1.Position
        let pos2 = d2.Position
        vectorLength pos1 pos2

    member this.FlyDrones () =
        for i in [0..(drones.Length-1)] do
            drones.[i].Fly()

    member this.addDrone drone=
        drones <- drones@[drone] 

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

let AS = Airspace()
let d1 = Drone((0,40),(40,15),2,"d1")
let d2 = Drone((0,10),(0,40),2,"d2")
let d3 = Drone((0,20),(0,40),1,"d3")
AS.addDrone d1
AS.addDrone d2
AS.addDrone d3
printfn "%A" (AS.Drones)
printfn "%A" (AS.Collide 5)
printfn "%A" (AS.Drones)