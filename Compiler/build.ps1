param(
     [Parameter()]
     [string]$FileName
 )

$file = Get-Item $FileName
$bn = $file.BaseName

Remove-Item -LiteralPath "obj" -Force -Recurse -ErrorAction Ignore

C:\Elan\bc.exe $FileName

Copy-Item "C:\Elan\Sandpit.Compiler.Lib.dll" -Destination "./obj/Sandpit.Compiler.Lib.dll"
dotnet build "obj\$bn.csproj"