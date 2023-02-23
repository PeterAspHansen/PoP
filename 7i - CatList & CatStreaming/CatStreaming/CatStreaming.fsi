module CatStreaming

open System.IO

/// <summary>
/// Indlæser bytes fra en filestream til en buffer. Funktionen læser en bestemt mængde bytes af gang defineret af inputtet "count". 
/// Input buffer antages som værende "count" længden. Bytes læses vha. FileStream.Read() funktionen. 
/// </summary>
/// <param name="count"> Mængden af bytes der læses </param>
/// <param name="buffer"> Bufferen hvor de læste bytes gemmes</param>
/// <param name="fs"> FileStream hvor bytes læses fra </param>
/// <returns> Når der ikke er flere bytes at læse, returneres 0. Ellers returneres int > 0.</returns>
val readBytes: int -> byte[] -> FileStream -> int


/// <summary>
/// skriver bytes fra en buffer til en filestream. 
/// funktionen læser en bestemt mængde bytes af gang defineret af inputtet "count".
/// input buffer antages som værende "count" længden.
/// </summary>
/// <param name="count"> Mængden af bytes der læses </param>
/// <param name="buffer"> Bufferen hvor bytes læses bytes fra</param>
/// <param name="fs"> FileStream hvor bytes skrives </param>
///<returns> Return () </returns>
val writeBytes: int -> byte[] -> FileStream -> unit

/// <summary>
/// denne funktion læser indholdet i input filestream, og skriver dette i en output filestream. 
/// den læser kun en specificeret mængde bytes af gangen, defineret vha "buffersize". 
/// </summary>
/// <param name="buffersize"> Mængden af bytes der læseses og skrives af gangen. Størrelsen af den brugte buffer. </param>
/// <param name="buffer"> Bufferen hvor bytes læses og gemmes, og hvor de læste bytes skrives fra. </param>
/// <param name="ifs"> En enkelt FileStream fra input filen. Der hvor bytes læses. </param>
/// <param name="ofs"> En enkelt FileStream tilhørende output filen. Der hvor bytes skrives.</param>
/// <returns> Returns () </returns>
val readAndWriteBytes: int -> byte[] -> FileStream -> FileStream -> unit

///<summary> en fil åbnes for læsning</summary>
///<param name=filename> en string, som er navnet på filen der læses</param>
///<returns> en FileStream </returns>
val openFileRead: string -> FileStream

///<summary> en liste af filer åbnes for læsning </summary>
///<param name=filenames> en string list, som indeholder navnene på alle filer </param>
///<returns> en FileStream option. Ellers returneres None </returns>
val openFilesRead: string list -> FileStream option list

///<summary> en fil åbnes og skrives i </summary>
///<param name=filename> en string, som er navnet på filen der læses </param>
///<returns> en FileStream option </returns>
val openFileWrite: string -> FileStream option

///<summary> Denne funktion gør det samme som cat fra øvelsesopgaverne med undtagelse af, at der kan defineres en buffersize</summary>
/// <param name="buffersize"> mængden af bytes der læseses og skrives af gangen. Størrelsen af den brugte buffer. </param>
///<param name=filenames> </param>
///<returns> indholdet af alle filer concateneres, på nær den sidste fil i og samles i den fil hvis navn er output.</returns>
val catWithBufferSize: int -> string[] -> int

///<summary> denne funktion kalder catWithBufferSize hvor buffersize er sat til 64 bytes </summary>
///<param name= filenames> en string som er navnene på filene </param>
///<returns> det sidste filnavn i vores string.  </returns>
val cat: (string[] -> int)



