module CatList

type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist
    
val nil : 'a catlist
val single : 'a -> 'a catlist
val append : 'a catlist -> 'a catlist -> 'a catlist
val cons : 'a -> 'a catlist -> 'a catlist
val snoc : 'a catlist -> 'a -> 'a catlist
val fold : (('a -> 'a -> 'a) * 'a) -> ('b -> 'a) -> 'b catlist -> 'a

///<summary> Denne funktion konverterer en 'a catlist til en 'a list </summary>
///<param name=x> en 'a catlist </param>
///<returns> en 'a list </returns>
val fromCatList : 'a catlist -> 'a list

///<summary> Denne funktion konverterer en 'a list til en 'a catlist </summary>
///<param name=y> en 'a list </param>
///<returns> en 'a list </returns>
val toCatList : 'a list -> 'a catlist
 
///<summary> Denne funktion returnerer det (i+1)'ne element i 'a catlist </summary> 
///<param name=i> en int værdi som definerer hvilket element der returneres </param>
///<param name=xs> en 'a catlist </param>
///<returns> et element 'a  </returns> 
val item : int -> 'a catlist -> 'a

///<summary> Denne funktion placerer en 'a catlist på den (i+1)'ne plads </summary> 
///<param name=i> en int værdi som definerer placeringen af elm i 'a catlist </param>
///<param name=elm> et element 'a </param>
///<param name=xs> en 'a catlist </param>
///<returns> en ny 'a catlist med et ekstra element </returns> 
val insert : int -> 'a -> 'a catlist -> 'a catlist

///<summary> Denne funktion fjerner det element fra 'a catlist som er på plads i+1 </summary> 
///<param name=i> en int værdi som definerer hvilket element som fjernes fra 'a catlist </param>
///<param name=xs> en 'a catlist </param>
///<returns> en ny 'a catlist hvor et element er fjernet </returns> 
val delete : int -> 'a catlist -> 'a catlist
