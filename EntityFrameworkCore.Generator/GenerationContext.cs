using System.Text;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;


namespace Quantumart.QP8.EntityFrameworkCore.Generator
{
	internal class GenerationContext
	{
		// Black hole logger
		public static readonly StringBuilder Logger = new();
		public EDMXSettings Settings { get; }
		public ModelReader Model { get; }
		public bool UsePartialUpdate { get; }
		public bool IsPostgres { get; }

		public GenerationContext(string settingsFile)
		{

			UsePartialUpdate = false;
			Settings = EDMXSettings.Parse(settingsFile);

			var directoryPath = GeFileDirectory(settingsFile);
			var mappingFile = System.IO.Path.Combine(directoryPath, Settings.QPContextMappingResultPath);

			Model = new ModelReader(mappingFile, text => Logger.AppendLine(text), true)
			{
				Schema =
				{
					LazyLoadingEnabled = Settings.LazyLoadingEnabled, IsStageMode = true
				}
			};
			Model.Schema.ConnectionStringName = Settings.UseContextNameAsConnectionString
				? Model.Schema.ClassName
				: Model.Schema.ConnectionStringName;
			IsPostgres = Model.Schema.DBType == DatabaseType.Postgres;

			Logger.AppendLine("ClassName:  " + Model.Schema.ClassName);
			Logger.AppendLine("ConnectionStringName:  " + Model.Schema.ConnectionStringName);
		}

		private static string GeFileDirectory(string filePath)
		{
			var lastSlashIndex = filePath.LastIndexOf("\\");
			return lastSlashIndex == -1
				? string.Empty
				: filePath.Substring(0, lastSlashIndex);
		}
	}
}