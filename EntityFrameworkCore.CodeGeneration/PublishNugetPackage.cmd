dotnet pack /p:NuspecFile=NugetPackage.nuspec
dotnet nuget push bin\Debug\QP8.EntityFrameworkCore.1.1.8.nupkg -s file://mscdev02.artq.com/Packages/
