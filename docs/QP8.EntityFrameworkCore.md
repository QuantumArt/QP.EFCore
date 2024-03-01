# Nuget-пакет QP8.EntityFrameworkCore

## Назначение

Шаблоны и source-генераторы для получения EF.Core-классов, которые работают с базой QP.

## Репозиторий

* <https://nuget.qsupport.ru/packages/QP8.EntityFrameworkCore>

## История версий 6.x (для .NET 6.0)

### QP8.EntityFrameworkCore.6.0.15

* Отключена логика замены плейсхолдеров в строковых полях при невозможности получить контекст работы с БД
* Отключена логика замены плейсхолдеров при наличии контекста БД, но при не заданном MappingResolver-е

### QP8.EntityFrameworkCore.6.0.14

* Исправлена ошибка при построении Url-а для изображений в случаях, когда значение имени файла не задано

### QP8.EntityFrameworkCore.6.0.13

* Убрана зависимость от схемы public в PostgreSQL (#173717)
* Обновление Quantumart.AspNetCore до 6.0.13

### QP8.EntityFrameworkCore.6.0.12

* Добавлена отправка уведомлений

### QP8.EntityFrameworkCore.6.0.11

* Исправлена ошибка с очисткой M2M-связей

### QP8.EntityFrameworkCore.6.0.10

* Исправлена ошибка с сохранением M2M-связей

### QP8.EntityFrameworkCore.6.0.6

* Обновление зависимостей (`QA.DotNetCore.*` обновлена до версии 3.2.4)

### QP8.EntityFrameworkCore.6.0.5

* Обновление зависимостей

### QP8.EntityFrameworkCore.6.0.4

* Обновление зависимостей

### QP8.EntityFrameworkCore.6.0.3

* Исправлена ошибка обновления поля `StatusType`

### QP8.EntityFrameworkCore.6.0.2

* Версия QA.DotNetCore.Engine.CacheTags обновлена до 2.1.6, поддержка `disable nullable`

### QP8.EntityFrameworkCore.6.0.1

* Версия QA.DotNetCore.Engine.CacheTags обновлена до 2.1.5

### QP8.EntityFrameworkCore.6.0.0

* Инкрементальная версия source-генераторов для .NET 6.0

## История версий 3.x (для .NET 5.0)

### QP8.EntityFrameworkCore.3.0.5

* Добавлена генерация CacheTags

### QP8.EntityFrameworkCore.3.0.4

* Переход на инкрементальную версию source-генераторов

### QP8.EntityFrameworkCore.3.0.3

* Обновление nuget-пакетов ([Quantumart.AspNetCore](Quantumart) до 5.0.1)

### QP8.EntityFrameworkCore.3.0.2

* Исправлены разделители путей под Linux

### QP8.EntityFrameworkCore.3.0.1

* Исправлены проблемы с регистром под Linux

### QP8.EntityFrameworkCore.3.0.0

* Версия с использованием c#9 source generation вместо T4-шаблона для проектов на .NET 5

## История версий 1.x (для .NET Core 2.2 c переходом на 3.1)

### QP8.EntityFrameworkCore.1.3.5

* Добавлен readme по сборке в docker контейнер

### QP8.EntityFrameworkCore.1.3.4

* Обновлен список зависимостей

### QP8.EntityFrameworkCore.1.3.3

* Фикс билда на линуксовой машине

### QP8.EntityFrameworkCore.1.3.2

* Фикс регистра в названиях файлов

### QP8.EntityFrameworkCore.1.3.1

* Понизил зависимость от пакета `Microsoft.EntityFrameworkCore` c  версии *3.1.10* до *3.1.3*

### QP8.EntityFrameworkCore.1.3.0

* Версия с использованием `C#9 source generators` вместо T4-шаблона для проектов на `.netcoreapp3.1`

### QP8.EntityFrameworkCore.1.2.8

* Исправлена реализация OnSaveChangesAsync

### QP8.EntityFrameworkCore.1.2.7

* Добавлена поддержка OnSaveChangesAsync

### QP8.EntityFrameworkCore.1.2.4

* Исправлена опечатка при генерации M2M-полей

### QP8.EntityFrameworkCore.1.2.3

* Обновлена зависимость Quantumart.AspNetCore (4.0.5)

### QP8.EntityFrameworkCore.1.2.2

* Изменена автогенерация backward-полей для связей: добавилось имя контента для поддержки уникальности и избежания 1 в конце названия

### QP8.EntityFrameworkCore.1.2.1

* Исправлено сохранение ID в контексте после сохранения статьи

### QP8.EntityFrameworkCore.1.2.0

* Переход на .NET Core 3.1

### QP8.EntityFrameworkCore.1.1.10

* Исправлена некорректно собранная dll в пакете

### QP8.EntityFrameworkCore.1.1.9

* Изменена автогенерация backward-полей для связей: добавилось имя контента для поддержки уникальности и избежания 1 в конце названия

### QP8.EntityFrameworkCore.1.1.8

* Обновлена зависимость Quantumart.AspNetCore (4.0.2)

### QP8.EntityFrameworkCore.1.1.7

* Исправлена ошибка обновления статьи со ссылкой на виртуальный контент

### QP8.EntityFrameworkCore.1.1.6

* ThreadStatic исправлены на AsyncLocal

### QP8.EntityFrameworkCore.1.1.4

* Добавлена поддержка PostgreSQL

### QP8.EntityFrameworkCore.1.1.3

* Базовая версия (QP.Quantumart версии 3.3.3)
