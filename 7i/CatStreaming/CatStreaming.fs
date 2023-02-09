module CatStreaming
open System.IO

//bemærkning: flere af funktionerne er inspireret af kode vist til studiecafeen 

let readBytes (count:int) (buffer:byte[]) (fs:FileStream) : int =
    fs.Read(buffer,0,count)

let writeBytes (count:int) (buffer:byte[]) (fs:FileStream) : unit =
    fs.Write(buffer,0,count)
    fs.Flush()

let readAndWriteBytes (buffersize:int) (buffer:byte[]) (ifs:FileStream) (ofs:FileStream) =
    let mutable x = -1;
    while not (x = 0) do 
        let readSize = readBytes buffersize buffer ifs
        writeBytes x buffer ofs

let openFileRead (filename:string) : FileStream =
    File.OpenRead filename

let openFilesRead (filenames : string list) : FileStream option list =
    let getFileOption file =
        try Some (openFileRead file)
        with ex -> 
            eprintfn "Filen %A eksisterer ikke, er ikke læselig eller kan ikke skrives i" file
            None 
    List.map (getFileOption) filenames

let openFileWrite (filename:string) : FileStream option =
    try  Some (File.Open (filename, FileMode.Create,FileAccess.Write))
    with ex -> None

let catWithBufferSize (buffersize:int) (filenames:string[]) : int =
    let Buffer = Array.create buffersize 0uy
    let Files = openFilesRead (Array.toList filenames[0..filenames.Length-2])
    let Count = List.fold(fun(c:int)(fs: FileStream option)-> if fs.IsNone then c+1 else c) 0 Files
    if (filenames.Length = 0) then 
        eprintfn "cat: Ingen option fil"
        255
    else if not (Count = 0) then
        min 254 Count
    else 
        let outFile = openFileWrite filenames[filenames.Length-1]
        if (outFile.IsNone) then 
            eprintfn "cat: Output filen kunne ikke læses eller oprettes"
            255
        else
            ignore <| List.map
                            (fun (inF: FileStream option) -> 
                                 (readAndWriteBytes buffersize Buffer (inF.Value) outFile.Value))
                            Files
            0

let cat : (string[] -> int) = fun(s:string[])->(catWithBufferSize 64 s)

