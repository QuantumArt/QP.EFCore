* Dont forget to increase package version in .nuspec

To generate version of .nupkg just run command
> dotnet pack EntityFrameworkCore.Generator.csproj -p:NuspecFile=NugetPackage.nuspec -c Release

To push to nuget repository
> dotnet nuget push QP8.EntityFrameworkCore.3.0.0-beta1.nupkg -k QA_TFS_Build -s http://spbdev01.artq.com:7777

* В папке Resources расположены служебные ресурсы:
- QPDataContextGenerator.tt.settings.xml - настройки генерации
- ModelMappingResult.xml - данные маппинга, полученные из QP
- QP8.EntityFrameworkCore.props, QP8.EntityFrameworkCore.targets - необходим для копирования QPDataContextGenerator.tt.settings.xml и ModelMappingResult.xml в корень целевого проекта
- NugetPackage.nuspec - настройки нагет пакета

*ВАЖНО! При изменении версии нагет пакета НЕОБХОДИМО изменить путь в Resources/QP8.EntityFrameworkCore.props

* Проект собран с TargetFramework=netstandard2.0, но в .Nuspec трубуется net5.0, т.к. нагенеренные файлы завясимы от компонентов .net5.0, а Visual Studio отказывается запускать Source Generators при указании другого значения.