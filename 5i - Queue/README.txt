Peter Asp Hansen 

Projektet består af 
- implementation filer (.fs) 
Her defineres moduler der virker som biblioteker der indeholder værdier, funktioner m.m.
- signature filer (.fsi) 
Her dokumenteres input- og output typer af f.eks. funktionerne i .fs filen. Yderligere definerer vi også preconditions i denne fil. 
- En projekt fil (fs.proj)
Her kompileres henholdsvis signature- og den tilsvarende implementation filerne. I dette projekt kompileres følgende filer på følgende måde:
<ItemGroup>
    <Compile Include="intQueue.fsi" />
    <Compile Include="intQueue.fs" />
    <Compile Include="safeIntQueue.fsi" />
    <Compile Include="safeIntQueue.fs" />
    <Compile Include="queue.fsi"/>
    <Compile Include="queue.fs"/>
    <Compile Include="testQueues.fs" />
</ItemGroup>
Testen som er defineret i implementation filen testQueues.fs køres med kommandoen dotnet Run. 
