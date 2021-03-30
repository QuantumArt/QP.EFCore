using System;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Quantumart.QP8.EntityFrameworkCore.Generator
{
	[Generator]
	public class QPDataContextGenerator : ISourceGenerator
	{
		private static readonly string QPDataContextGeneratorSettingsFilePath = Path.DirectorySeparatorChar + "QPDataContextGenerator.settings.xml";


		public void Initialize(GeneratorInitializationContext context)
		{
			//System.Diagnostics.Debugger.Launch();
		}

		public void Execute(GeneratorExecutionContext context)
		{
			try
			{
				GenerateQPDataContext(context);
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

		public bool TryReadAdditionalFilesOption(GeneratorExecutionContext context, AdditionalText additionalText,
			string property, out string value)
		{
			return context.AnalyzerConfigOptions.GetOptions(additionalText)
				.TryGetValue($"build_metadata.AdditionalFiles.{property}", out value);
		}


		private static void GenerateQPDataContext(GeneratorExecutionContext executionContext)
		{
			var generationSettings =
				executionContext.AdditionalFiles.FirstOrDefault(x =>
					x.Path.EndsWith(QPDataContextGeneratorSettingsFilePath));

			// Сюда попадают "не прямо связанные" проекты
			if (generationSettings == null)
				return;

			var context = new GenerationContext(generationSettings.Path);

			var className = context.Model.Schema.ClassName;
			var ns = context.Model.Schema.NamespaceName;

			#region SimpleTemplates
			executionContext.AddSource(nameof(SimpleTemplates.DatabaseSchemaProvider),
				SourceText.From(SimpleTemplates.DatabaseSchemaProvider.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.MappingResolver),
				SourceText.From(SimpleTemplates.MappingResolver.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.FileSchemaProvider),
				SourceText.From(SimpleTemplates.FileSchemaProvider.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPArticle),
				SourceText.From(SimpleTemplates.IQPArticle.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPLink),
				SourceText.From(SimpleTemplates.IQPLink.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPLibraryService),
				SourceText.From(SimpleTemplates.IQPLibraryService.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPFormService),
				SourceText.From(SimpleTemplates.IQPFormService.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IQPSchema),
				SourceText.From(SimpleTemplates.IQPSchema.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.IMappingConfigurator),
				SourceText.From(SimpleTemplates.IMappingConfigurator.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.ISchemaProvider),
				SourceText.From(SimpleTemplates.ISchemaProvider.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.MappingConfiguratorBase),
				SourceText.From(SimpleTemplates.MappingConfiguratorBase.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.StatusType),
				SourceText.From(SimpleTemplates.StatusType.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.User),
				SourceText.From(SimpleTemplates.User.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.UserGroup),
				SourceText.From(SimpleTemplates.UserGroup.GetTemplate(ns), Encoding.UTF8));

			executionContext.AddSource(nameof(SimpleTemplates.UserGroupBind),
				SourceText.From(SimpleTemplates.UserGroupBind.GetTemplate(ns), Encoding.UTF8));

			#endregion

			#region Templates
			executionContext.AddSource(className,
				SourceText.From(
					Templates.ModelDbContext.GetTemplate(ns, context),
					Encoding.UTF8));

			executionContext.AddSource(className + "Extensions.cs",
				SourceText.From(
					Templates.ModelDbContextExtensions.GetTemplate(ns, context),
					Encoding.UTF8));

			executionContext.AddSource(className + "ConnectionScope.cs",
				SourceText.From(
					Templates.ConnectionScope.GetTemplate(ns, context),
					Encoding.UTF8));

			executionContext.AddSource(className + ".Contents.Extensions.cs",
				SourceText.From(
					Templates.ContentsClassExtensions.GetTemplate(ns, context),
					Encoding.UTF8));

			executionContext.AddSource(className + ".QPEntityBase.cs",
				SourceText.From(
					Templates.BaseM2MClasses.GetTemplate(ns),
					Encoding.UTF8));

			executionContext.AddSource("MappingConfigurator.cs",
				SourceText.From(
					Templates.MappingConfigurator.GetTemplate(ns, context),
					Encoding.UTF8));

			executionContext.AddSource("StaticSchemaProvider.cs",
				SourceText.From(
					Templates.StaticSchemaProvider.GetTemplate(ns, context),
					Encoding.UTF8));

			foreach (var content in context.Model.Contents)
			{
				executionContext.AddSource(content.MappedName + ".cs",
					SourceText.From(
						Templates.ContentClass.GetTemplate(ns, context, content),
						Encoding.UTF8));
			}

			foreach (var content in context.Model.Contents)
				foreach (var attribute in content.Attributes.Where(x => x.IsM2M && x.IsSource == true))
				{
					executionContext.AddSource(attribute.M2MClassName + ".cs",
						SourceText.From(
							Templates.ContentClassesM2M.GetTemplate(ns, context, content, attribute),
							Encoding.UTF8));
				}
			#endregion
		}
	}
}