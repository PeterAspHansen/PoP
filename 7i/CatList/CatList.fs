module CatList
open DiffList

type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist

let nil: 'a catlist = Empty
let single (elm:'a) : 'a catlist = Single elm
let append (xs : 'a catlist) (ys : 'a catlist) : 'a catlist = Append (xs, ys)
let cons (elm : 'a) (xs : 'a catlist) : 'a catlist = Append (Single elm, xs)
let snoc (xs : 'a catlist) (elm : 'a) : 'a catlist = Append (xs, Single elm)

let rec fold ((folder:'a->'a->'a),(initVal:'a))(funVal:'b->'a)(xs:'b catlist): 'a=
        match xs with 
            Empty -> initVal
            |Single v -> funVal v 
            |Append (l,r)-> folder (fold (folder,initVal) funVal l)(fold(folder,initVal)funVal r)
    
let length xs: int = fold ((+),0)(fun _ -> 1) xs

let rec fromCatList (x: 'a catlist): 'a list =
    match x with
        Empty -> []
        |Single l -> [l]
        |Append (ys, zs) -> (fromCatList ys)@(fromCatList zs)

let fromCatList' (xs : 'a catlist) : 'a list = DiffList.fromDiffList (fold(DiffList.append,DiffList.nil) DiffList.single xs)
   
let rec toCatList (y: 'a list): 'a catlist = 
    match y with
    []-> Empty
    |[l]-> Single l 
    |y::z -> Append(toCatList [y],toCatList z)

let toCatList' (xs : 'a list) : 'a catlist = List.foldBack cons xs nil

let item (i:int)(xs: 'a catlist):'a=
    let rec f i' (xs:'a catlist)=
        match xs with
            Empty -> failwith "empty"
            |Single x when i'=0 -> x
            |Append (ys,zs) -> 
                let len = length ys
                match (len>i') with
                    |true -> f i' ys
                    |false -> f (i'-len) zs
            |_ -> failwith "elements"
    f i xs 

//test 
printfn "%A" (item 2 (Append(Append(Single 1, Single 2),Single 3)))

let insert (i:int) (elm:'a) (xs:'a catlist) : 'a catlist =
    let rec f i' (xs:'a catlist)=
        match xs with
            Empty -> single elm
            |Single x -> append (single elm)(single x)
            |Append (ys,zs) -> 
                let len = (length ys)
                match len with
                    |len when (len > i') -> append (f i' ys) zs
                    |_-> append ys (f (i'-(length ys)) zs)
    f i xs

//test
printfn "%A" (insert 0 3 (Append (Append(Single 1,Single 2),Single 4)))

let delete (i:int) (xs:'a catlist) : 'a catlist =
    let rec f i' xs = 
        match xs with 
            |Empty -> nil
            |Single x -> nil
            |Append (ys,zs) -> 
                let len = length ys
                match len with
                    |len when (len >i') -> append (f i' ys) zs
                    |_-> append ys (f (i'-(length ys)) zs)
    f i xs

//test
printfn "%A" (delete 1 (Append(Single 1,Single 2)))

