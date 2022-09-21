using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;
using Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates;
using Quantumart.QP8.EntityFrameworkCore.Generator.Templates;
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator
{
    [Generator]
    public class QPDataContextGenerator : IIncrementalGenerator
    {
        private static readonly string QPDataContextGeneratorSettingsFilePath =
            Path.DirectorySeparatorChar + "QPDataContextGenerator.settings.xml";

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            //System.Diagnostics.Debugger.Launch();
            var settingsFileProvider = context.AdditionalTextsProvider
                .Where(x => x.Path.EndsWith(QPDataContextGeneratorSettingsFilePath))
                .Select((x, _) => (x.Path, EDMXSettings.Parse(x.Path)));

            var changedFilesProvider = context.AdditionalTextsProvider
                .Where(x => x.Path.EndsWith(".xml"));

            var provider = changedFilesProvider.Combine(settingsFileProvider.Collect()).Collect();

            context.RegisterSourceOutput(provider, TryGenerateEfContexts);
            context.RegisterSourceOutput(provider, TryGenerateCacheTags);
        }

        private static void TryGenerateEfContexts(SourceProductionContext context,
            ImmutableArray<(AdditionalText, ImmutableArray<(string, EDMXSettings)>)> data)
        {
            try
            {
                if (!TryGetSettings(data, out var settingsPath, out var settings))
                    return;

                if (!WereQpSettingsChanged(settingsPath, settings, data))
                    return;

                GenerateQpDataContext(context, new GenerationContext(settingsPath));
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message} {ex.StackTrace}".Replace(Environment.NewLine, string.Empty);

                context.ReportDiagnostic(Diagnostic.Create(
                    new DiagnosticDescriptor(
                        "QA0000",
                        "An exception was thrown by the QP8.EntityFrameworkCore generator. Generate EF Context",
                        "An exception was thrown by the QP8.EntityFrameworkCore generator. Generate EF Context: '{0}'",
                        "QP8.EntityFrameworkCore Generator",
                        DiagnosticSeverity.Error,
                        isEnabledByDefault: true),
                    Location.None,
                    msg));
            }
        }

        private static void TryGenerateCacheTags(SourceProductionContext context,
            ImmutableArray<(AdditionalText, ImmutableArray<(string, EDMXSettings)>)> data)
        {
            try
            {
                if (!TryGetSettings(data, out var settingsPath, out var settings))
                    return;

                if (!WereQpSettingsChanged(settingsPath, settings, data))
                    return;

                GenerateCacheTags(context, new GenerationContext(settingsPath));
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message} {ex.StackTrace}".Replace(Environment.NewLine, string.Empty);

                context.ReportDiagnostic(Diagnostic.Create(
                    new DiagnosticDescriptor(
                        "QA0000",
                        "An exception was thrown by the QP8.EntityFrameworkCore generator. Generate cache tags",
                        "An exception was thrown by the QP8.EntityFrameworkCore generator. Generate cache tags: '{0}'",
                        "QP8.EntityFrameworkCore Generator",
                        DiagnosticSeverity.Error,
                        isEnabledByDefault: true),
                    Location.None,
                    msg));
            }
        }

        private static bool TryGetSettings(ImmutableArray<(AdditionalText, ImmutableArray<(string, EDMXSettings)>)> data,
            out string settingsPath, out EDMXSettings settings)
        {
            if (!data.Any())
            {
                settingsPath = null;
                settings = null;
                return false;
            }

            var (_, settingsArr) = data.First();
            (settingsPath, settings) = settingsArr.SingleOrDefault();

            return !string.IsNullOrEmpty(settingsPath) && settings != null;
        }

        /// <summary>
        /// Были ли изменены файлы маппингов QP
        /// </summary>
        /// <param name="settingsPath"></param>
        /// <param name="settings"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool WereQpSettingsChanged(string settingsPath, EDMXSettings settings,
            ImmutableArray<(AdditionalText, ImmutableArray<(string, EDMXSettings)>)> data)
        {
            return settings != null &&
                   !string.IsNullOrEmpty(settingsPath) &&
                   data.Any(x =>
                       IsSameFile(x.Item1.Path, settingsPath) ||
                       IsSameFile(x.Item1.Path, settings.QPContextMappingResultPath));
        }

        private static void GenerateQpDataContext(SourceProductionContext executionContext, GenerationContext context)
        {
            var className = context.Model.Schema.ClassName;
            var ns = context.Model.Schema.NamespaceName;

            #region SimpleTemplates

            AddSource(nameof(DatabaseSchemaProvider), DatabaseSchemaProvider.GetTemplate);
            AddSource(nameof(MappingResolver), MappingResolver.GetTemplate);
            AddSource(nameof(FileSchemaProvider), FileSchemaProvider.GetTemplate);
            AddSource(nameof(IQPArticle), IQPArticle.GetTemplate);
            AddSource(nameof(IQPLink), IQPLink.GetTemplate);
            AddSource(nameof(IQPLibraryService), IQPLibraryService.GetTemplate);
            AddSource(nameof(IQPFormService), IQPFormService.GetTemplate);
            AddSource(nameof(IQPSchema), IQPSchema.GetTemplate);
            AddSource(nameof(IMappingConfigurator), IMappingConfigurator.GetTemplate);
            AddSource(nameof(ISchemaProvider), ISchemaProvider.GetTemplate);
            AddSource(nameof(MappingConfiguratorBase), MappingConfiguratorBase.GetTemplate);
            AddSource(nameof(StatusType), StatusType.GetTemplate);
            AddSource(nameof(User), User.GetTemplate);
            AddSource(nameof(UserGroup), UserGroup.GetTemplate);
            AddSource(nameof(UserGroupBind), UserGroupBind.GetTemplate);

            #endregion

            #region Templates

            AddSource(className, ModelDbContext.GetTemplate);
            AddSource(className + "Extensions.cs", ModelDbContextExtensions.GetTemplate);
            AddSource(className + "ConnectionScope.cs", ConnectionScope.GetTemplate);
            AddSource(className + ".Contents.Extensions.cs", ContentsClassExtensions.GetTemplate);
            AddSource(className + ".QPEntityBase.cs", BaseM2MClasses.GetTemplate);
            AddSource("MappingConfigurator.cs", MappingConfigurator.GetTemplate);
            AddSource("StaticSchemaProvider.cs", StaticSchemaProvider.GetTemplate);

            #endregion

            foreach (var content in context.Model.Contents)
            {
                executionContext.AddSource(
                    content.MappedName + ".cs",
                    SourceText.From(
                        ContentClass.GetTemplate(ns, context, content, executionContext.CancellationToken),
                        Encoding.UTF8));
            }

            foreach (var content in context.Model.Contents)
            {
                foreach (var attribute in content.Attributes.Where(x => x.IsM2M && x.IsSource == true))
                {
                    executionContext.AddSource(
                        attribute.M2MClassName + ".cs",
                        SourceText.From(
                            ContentClassesM2M.GetTemplate(ns, context, content, attribute,
                                executionContext.CancellationToken),
                            Encoding.UTF8));
                }
            }

            void AddSource(string hint, Func<string, GenerationContext, CancellationToken, string> templateFactory)
            {
                var sourceText = SourceText.From(
                    templateFactory(ns, context, executionContext.CancellationToken),
                    Encoding.UTF8);

                executionContext.AddSource(hint, sourceText);
            }
        }

        private static void GenerateCacheTags(SourceProductionContext executionContext, GenerationContext context)
        {
            var ns = context.Model.Schema.NamespaceName;

            executionContext.AddSource(nameof(CacheTags),
                SourceText.From(
                    CacheTags.GetTemplate(ns, context, executionContext.CancellationToken),
                    Encoding.UTF8));
        }

        private static bool IsSameFile(string firstFilePath, string secondFilePath)
        {
            var firstFileName = firstFilePath.Split(Path.DirectorySeparatorChar).LastOrDefault();
            if (string.IsNullOrEmpty(firstFileName))
                return false;

            var secondFileName = secondFilePath.Split(Path.DirectorySeparatorChar).LastOrDefault();
            return firstFileName.Equals(secondFileName, StringComparison.OrdinalIgnoreCase);
        }
    }
}