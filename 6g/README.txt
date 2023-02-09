Shatin Nguyen, Oliver Fontaine-Lopez Raaschou og Peter Asp Hansen


Beskrivelse af hvordan man kører koden:

Opret et bibliotek kaldet 6g ved at indtaste følgende i terminalen 

	dotnet new console -lang "F#" -o 6g

Tilføjer filerne 6g0Lib.fsi, 6g0Lib.fs og 6g0App.fsx til mappen 6g. Og skriv følgende under filen 6g.fsproj:
	
	<ItemGroup>
	<Compile Include= "6g0Lib.fsi" />
	<Compile Include= "6g0Lib.fs" />
	<Compile Include= "6g0App.fsx" />
	<ItemGroup> 

	<ItemGroup>
    	<PackageReference Include="DIKU.Canvas" Version="1.0.1" />
  	</ItemGroup>

Går tilbage til terminal og skriv: cd 6g
Koden køres ved at indtaste: dotnet run 

