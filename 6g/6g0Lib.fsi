module Game2048
open Canvas

type pos = int*int //Position af to int
type value = Red|Green|Blue|Yellow|Black //Farverne anvendt
type piece = value*pos //En farve og position
type state = piece list //En liste med pieces

///<summary> Funktionen tager en værdi v og laver det om til en farve.  </summary>
///<param name="v"> En value  </param name>
///<returns> returnerer en Canvas.color farve </returns>
val fromValue : v:value -> Canvas.color

///<summary>Funktionen tager et argument c (en farve) og returnere næste  farve i hierakiet fra ->
/// Red -> Green -> Blue -> Yellow -> Black </summary>
///<param name="c"> En farve </param name>
///<returns> En ny farve  </returns>
val nextColor : c:value -> value

///<summary> Funktionen tager et argument og returnerer alle værdierne som er i den kolonne    </summary>
///<param name="k"> hvilken kolonne vi vil have </param name>
///<returns> En ny liste fra kolonne k </returns>
val filter : k:int -> s:state -> state

///<summary> Funktionen ændrer x koordinatet med 2-x  </summary>
///<param name="s"> En state  </param name>
///<returns> returnere en ny position </returns>
val flipUD : s:state -> state

///<summary>Funktionen bytter om på koordinaterne fra vores pieces </summary>
///<param name="s"> En state  </param name>
///<returns> returnerer en ny position:  (i,j) = (j,i)  </returns>
val transpose : s:state -> state

///<summary> Funktionen giver os alle de mulige punkter på brættet  </summary>
///<param name="s"> En state  </param name>
///<returns> Returnerer en liste med mulige punkter  </returns>
val empty : s:state -> pos list

///<summary> Tilfældigt placere en ny piece på boardet i en bestemt farve </summary>
///<param name="c"> En farve </param name>
///<param name="s"> En state </param name>
///<returns> Tilfældigt placeret piece med farven c på boardet </returns>
val addRandom : c:value -> s:state -> state option

///<summary> Reducere x-koordinaten med 1 og lægger to value sammen de er ens </summary>
///<param name="s"> En state </param name>
///<returns> Rykker prikkerne x-1, og hvis value er ens, lægger dem sammen </returns>
val shiftLeft : s:state -> state

///<summary> Tegner firkanterne til spillet </summary>
///<param name="w"> Bredte på vinduet </param name>
///<param name="h"> Højre på vinduet </param name>
///<param name="s"> en state </param name>
///<returns> Tegner i canvas </returns>
val draw : w:int -> h:int -> s:state -> canvas

///<summary> Tager input fra bruger og tegner i canvas </summary>
///<param name="s"> En state  </param name>
///<param name="k"> Input fra piltasterne </param name>
///<returns> Tegner i canvas fra input </returns>
val react : s:state -> k:key -> state option