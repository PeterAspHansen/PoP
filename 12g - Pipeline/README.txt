Shatin Nguyen (hlv332)
Peter Asp Hansen (glt832)
Oliver Fontaine Raaschou (vns328)

Opgave A 
Den største overvejelse til Opgave A har været implementationen af GeneralSum. 
Vi har valgt at implementere den ved brug af operator modulet men man kunne alternativt have et if statement der tjekkede om 
det var * eller + og agerede efter det.

Opgave B
I vores implementation af Map skal apply() inputtet være noget der er iterable som en liste eller lignende.

Opgave C
Til denne opgave skulle vi finde en god må de at lægge alle descriptions og steps fra tidligere steps ind.
Vi har valgt at concatenate alle stringsne sammen og returnere det til sidst med format.

Opgave D 
I opgave D har den eneste overvejelse været om man skulle importere det med csv reader og derefter lave det til en liste
eller blot bruge dictreader.
I vores implementation har vi valgt at bruge dictreader

Opgave E 
Til denne opgave har vi valgt funktionerne README og Cube. README læser en textfil og returnerer indholdet.
Cube returnerer inputtet ^3 (x^3)


Final remarks:
Please note that some of the functions raise an error in the doctest but work when you do like such:
test = SumNum()
print(test.apply([3,2,1,4,5]))
po = ProductNum()
print(po.apply([1,2,3,4,5]))
>>> 15
