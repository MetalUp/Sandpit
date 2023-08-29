param(
     [Parameter()]
     [string]$FileName
 )

$file = Get-Item $FileName
$bn = $file.BaseName

C:\Elan\bc.exe $FileName
dotnet build "$bn.csproj"