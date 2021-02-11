using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Quantumart.QP8.EntityFrameworkCore.Generator
{
	[Generator]
	public class QPDataContextGenerator : ISourceGenerator
	{
		private const string QPDataContextGeneratorSettingsFilePath = "\\QPDataContextGenerator.tt.settings.xml";


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
			if (generationSettings == null)
				throw new FileNotFoundException($"Could not find settings file \"{QPDataContextGeneratorSettingsFilePath}\" in {nameof(executionContext.AdditionalFiles)}");

			// Копируем типы как ресурсы, что не было ошибок компиляции этого проекта из-за отсутствующих зависимостей
			executionContext.AddEmbeddedResource("EmbeddedModels.MappingResolver.cs", "MappingResolver");
			executionContext.AddEmbeddedResource("EmbeddedModels.FileSchemaProvider.cs", "FileSchemaProvider");
			executionContext.AddEmbeddedResource("EmbeddedModels.DatabaseSchemaProvider.cs", "DatabaseSchemaProvider");
			executionContext.AddEmbeddedResource("EmbeddedModels.IQPArticle.cs", "IQPArticle");
			executionContext.AddEmbeddedResource("EmbeddedModels.IQPLink.cs", "IQPLink");
			executionContext.AddEmbeddedResource("EmbeddedModels.IQPLibraryService.cs", "IQPLibraryService");
			executionContext.AddEmbeddedResource("EmbeddedModels.IQPFormService.cs", "IQPFormService");
			executionContext.AddEmbeddedResource("EmbeddedModels.IQPSchema.cs", "IQPSchema");
			executionContext.AddEmbeddedResource("EmbeddedModels.IMappingConfigurator.cs", "IMappingConfigurator");
			executionContext.AddEmbeddedResource("EmbeddedModels.ISchemaProvider.cs", "ISchemaProvider");
			executionContext.AddEmbeddedResource("EmbeddedModels.MappingConfiguratorBase.cs", "MappingConfiguratorBase");
			executionContext.AddEmbeddedResource("EmbeddedModels.StatusType.cs", "StatusType");
			executionContext.AddEmbeddedResource("EmbeddedModels.User.cs", "User");
			executionContext.AddEmbeddedResource("EmbeddedModels.UserGroup.cs", "UserGroup");
			executionContext.AddEmbeddedResource("EmbeddedModels.UserGroupBind.cs", "UserGroupBind");

			var context = new GenerationContext(generationSettings.Path);

			var className = context.Model.Schema.ClassName;
			var ns = executionContext.Compilation.AssemblyName;


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
		}
	}
}