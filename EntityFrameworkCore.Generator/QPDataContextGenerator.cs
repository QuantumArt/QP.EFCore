using System;
using System.Collections.Immutable;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator
{
	[Generator]
	public class QPDataContextGenerator : IIncrementalGenerator
	{
		private static readonly string QPDataContextGeneratorSettingsFilePath = Path.DirectorySeparatorChar + "QPDataContextGenerator.settings.xml";

		public void Initialize(IncrementalGeneratorInitializationContext context)
		{
			//System.Diagnostics.Debugger.Launch();
			var settingsFileProvider = context.AdditionalTextsProvider
				.Where(x => x.Path.EndsWith(QPDataContextGeneratorSettingsFilePath))
				.Select((x, _) => (x.Path, EDMXSettings.Parse(x.Path)));

			var changedFilesProvider = context.AdditionalTextsProvider
				.Where(x => x.Path.EndsWith(".xml"));

			var provider = changedFilesProvider.Combine(settingsFileProvider.Collect());

			context.RegisterSourceOutput(provider.Collect(), TryGenerateEfContexts);
		}

		private void TryGenerateEfContexts(SourceProductionContext context,
			ImmutableArray<(AdditionalText, ImmutableArray<(string, EDMXSettings)>)> data)
		{
			var (_, settingsArr) = data.First();
			var (settingsPath, settings) = settingsArr.Single();

			if (data.Any(x =>
				    IsSettingsFileChanged(x.Item1.Path) ||
				    IsMappingFileChanged(x.Item1.Path)))
			{
				GenerateEfContexts(context, settingsPath);
			}

			bool IsSettingsFileChanged(string filePath)
			{
				return IsSameFile(filePath, settingsPath);
			}

			bool IsMappingFileChanged(string filePath)
			{
				return IsSameFile(filePath, settings.QPContextMappingResultPath);
			}
		}

		public void GenerateEfContexts(SourceProductionContext context, string settingsPath )
		{
			try
			{
				var generationContext = new GenerationContext(settingsPath);
				GenerateQpDataContext(context, generationContext);
			}
			catch (Exception ex)
			{
				var msg = $"{ex.Message} {ex.StackTrace}".Replace(Environment.NewLine, string.Empty);

				context.ReportDiagnostic(Diagnostic.Create(
					new DiagnosticDescriptor(
						"QA0000",
						"An exception was thrown by the QP8.EntityFrameworkCore generator",
						"An exception was thrown by the QP8.EntityFrameworkCore generator: '{0}'",
						"QP8.EntityFrameworkCore Generator",
						DiagnosticSeverity.Error,
						isEnabledByDefault: true),
					Location.None,
					msg));
			}
		}

		private static void GenerateQpDataContext(SourceProductionContext executionContext, GenerationContext context)
		{
			var className = context.Model.Schema.ClassName;
			var ns = context.Model.Schema.NamespaceName;

			#region SimpleTemplates

			executionContext.AddSource(nameof(SimpleTemplates.DatabaseSchemaProvider),
				SourceText.From(
					SimpleTemplates.DatabaseSchemaProvider.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.MappingResolver),
				SourceText.From(SimpleTemplates.MappingResolver.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.FileSchemaProvider),
				SourceText.From(SimpleTemplates.FileSchemaProvider.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPArticle),
				SourceText.From(SimpleTemplates.IQPArticle.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPLink),
				SourceText.From(SimpleTemplates.IQPLink.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPLibraryService),
				SourceText.From(SimpleTemplates.IQPLibraryService.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPFormService),
				SourceText.From(SimpleTemplates.IQPFormService.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPSchema),
				SourceText.From(SimpleTemplates.IQPSchema.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IMappingConfigurator),
				SourceText.From(
					SimpleTemplates.IMappingConfigurator.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.ISchemaProvider),
				SourceText.From(SimpleTemplates.ISchemaProvider.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.MappingConfiguratorBase),
				SourceText.From(
					SimpleTemplates.MappingConfiguratorBase.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.StatusType),
				SourceText.From(SimpleTemplates.StatusType.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.User),
				SourceText.From(SimpleTemplates.User.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.UserGroup),
				SourceText.From(SimpleTemplates.UserGroup.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.UserGroupBind),
				SourceText.From(SimpleTemplates.UserGroupBind.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			#endregion

			#region Templates

			executionContext.AddSource(className,
				SourceText.From(
					Templates.ModelDbContext.GetTemplate(ns, context, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(className + "Extensions.cs",
				SourceText.From(
					Templates.ModelDbContextExtensions.GetTemplate(ns, context, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(className + "ConnectionScope.cs",
				SourceText.From(
					Templates.ConnectionScope.GetTemplate(ns, context, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(className + ".Contents.Extensions.cs",
				SourceText.From(
					Templates.ContentsClassExtensions.GetTemplate(ns, context, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource(className + ".QPEntityBase.cs",
				SourceText.From(
					Templates.BaseM2MClasses.GetTemplate(ns, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource("MappingConfigurator.cs",
				SourceText.From(
					Templates.MappingConfigurator.GetTemplate(ns, context, executionContext.CancellationToken),
					Encoding.UTF8));

			executionContext.AddSource("StaticSchemaProvider.cs",
				SourceText.From(
					Templates.StaticSchemaProvider.GetTemplate(ns, context, executionContext.CancellationToken),
					Encoding.UTF8));

			foreach (var content in context.Model.Contents)
			{
				executionContext.AddSource(content.MappedName + ".cs",
					SourceText.From(
						Templates.ContentClass.GetTemplate(ns, context, content, executionContext.CancellationToken),
						Encoding.UTF8));
			}

			foreach (var content in context.Model.Contents)
			foreach (var attribute in content.Attributes.Where(x => x.IsM2M && x.IsSource == true))
			{
				executionContext.AddSource(attribute.M2MClassName + ".cs",
					SourceText.From(
						Templates.ContentClassesM2M.GetTemplate(ns, context, content, attribute,
							executionContext.CancellationToken),
						Encoding.UTF8));
			}

			#endregion
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