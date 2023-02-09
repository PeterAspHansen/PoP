#r "nuget:DIKU.Canvas, 1.0"
open Canvas

type state = int

let draw w h (s:state)=
    let C = create w h
    let l = w / 4
    let r = 3*l
    do setFillBox C black (l+s, l) (r+s,r)
    do setLine C lightgrey (0,0)(l+s,l)
    do setLine C lightgrey (w,0)(r+s,l)
    do setLine C lightgrey (0,w)(l+s,r)
    do setLine C lightgrey (w,w)(r+s,r)
    C

let react (s:state)(k:key) : state option =
    match getKey k with
    LeftArrow -> Some (s-5)
    | RightArrow -> Some (s+5)
    | _ -> None

do runApp "ColorBoxes" 600 600 draw react 0
