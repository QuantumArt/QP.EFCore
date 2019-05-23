dotnet pack /p:NuspecFile=NugetPackage.nuspec
dotnet nuget push bin\Debug\QP8.EntityFrameworkCore.1.1.2.nupkg -s file://mscbuild02.artq.com/Packages/
