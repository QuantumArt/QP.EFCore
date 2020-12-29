dotnet pack /p:NuspecFile=NugetPackage.nuspec
dotnet nuget push bin\Debug\QP8.EntityFrameworkCore.2.0.0-beta2.nupkg -s file://mscdev02.artq.com/Packages/
