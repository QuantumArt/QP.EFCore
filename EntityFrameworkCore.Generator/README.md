**Dont forget to increase package version in `NugetPackage.nuspec` and `QP8.EntityFrameworkCore.props`**

To generate version of `.nupkg` and push to nuget server just run tfs pipeline `Nuget.EFCore.Net5`

В папке Resources расположены служебные ресурсы:
- `QPDataContextGenerator.settings.xml` - настройки генерации
- `ModelMappingResult.xml` - данные маппинга, полученные из QP
- `QP8.EntityFrameworkCore.props`, `QP8.EntityFrameworkCore.targets` - необходим для 
  копирования `QPDataContextGenerator.settings.xml` и `ModelMappingResult.xml` в корень целевого проекта
- `NugetPackage.nuspec` - настройки нугет пакета

**ВАЖНО! При изменении версии нугет пакета НЕОБХОДИМО изменить путь в Resources/QP8.EntityFrameworkCore.props**

Проект собран с `TargetFramework=netstandard2.0`, но в `.Nuspec` требуется другая версия,
т.к. нагенеренные файлы зависимы от компонентов отличного от .netstandard,
а Visual Studio отказывается запускать Source Generators при указании другого значения.
