dotnet pack /p:NuspecFile=NugetPackage.nuspec
dotnet nuget push bin\Debug\QP8.EntityFrameworkCore.1.0.5.nupkg -s file://mscbuild02.artq.com/Packages/
