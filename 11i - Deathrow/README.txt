Peter Asp Hansen

Beskrivelse af koden
A) I denne opgave importeres filen 'tx_deathrow_full.csv'. Den eneste beslutning vedrører hvordan filen skal printes. Dette gøres med et for-loop. 

B) Her overvejede jeg hvordan man nemmest kunne pakke værdierne fra 'Height' og 'Weight' ud så der kan opereres på dem. Til sidste definere jeg en ny dictionary med de konverterede værdier. 


C) Denne opgave krævede meget omtanke da der f.eks. gennemløbes alle county. For hver ny county tilføjes denne som element i en dictionary og der tilknyttes en værdi. Hver gang der gennemløbes en allerede eksisterende county stiger værdien med en. Basisværdien er 1. 

Der er stort set ingen forskel mellem county_ statistics og native_statistics.

D) Her er den vigtigste overvejelse at vi ikke blot skal kunne søge på et ord men flere. Derfor skal vi gennemløbe alle ordene i words som jeg har gjort til en liste vha .split(). 



Test: Der bruges doctests til at teste funktionerne. I A testes der om antallet af elementer i get_data() passer. I B testes der om henholdsvis vægten og højden konverteres rigtigt for det første element i get_data(). I C tjekkes der f.eks. om antallet af dødsdømte fra Harris passer for funktionen county_statistic. 
 

Beskrivelse af hvordan man kører programmet:
Åben begge filer i VSCODE. Trykkes der på knappen 'Run Python File' burde der stå følgende i terminalen: 
sed: illegal option -- r
usage: sed script [-Ealn] [-i extension] [file ...]
       sed [-Ealn] [-i extension] [-e script] ... [-f script_file] ... [file ...]  
Dette betyder at der ikke var nogle fejl i testene.   
