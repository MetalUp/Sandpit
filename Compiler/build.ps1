param(
     [Parameter()]
     [string]$FileName
 )

$file = Get-Item $FileName
$bn = $file.BaseName

Remove-Item -LiteralPath "obj" -Force -Recurse -ErrorAction Ignore

C:\Elan\bc.exe $FileName
dotnet build "obj\$bn.csproj"