open Game2048
open Canvas

let rnd = System.Random()

let start (c:value) (s:state) : state = 
    let k = (empty s)[rnd.Next((empty s).Length)]
    [c,k]
let board = (start Red [])@(start Blue [])

do runApp "2048" 600 600 draw react board