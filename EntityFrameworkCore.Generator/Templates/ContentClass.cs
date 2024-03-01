using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
	internal static class ContentClass
	{
		public static string GetTemplate(string ns, GenerationContext context, ContentInfo content, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			var sb = new StringBuilder();

			sb.AppendLine(@$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace {ns}
{{
	public partial class {content.MappedName}: IQPArticle
	{{
        ");
			IncludeContructor(sb, content);
			
			sb.AppendLine(@"

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }");

			IncludeBaseAttibutes(sb,
				content.Attributes.Where(x => !x.IsM2M && !x.IsM2O && !x.IsO2M),
				context.Model.Schema.ReplaceUrls,
				context.Model.Schema.ClassName
			);
			IncludeAttibutesIsO2MRelatedContent(sb, content.Attributes.Where(x => x.IsO2M));

			IncludeAttibutesIsO2MOriginalMappedName(sb, content.Attributes.Where(x => x.IsO2M));

			IncludeAttibutesIsM2O(
				sb, content.Attributes.Where(x => x.IsM2O),
				context.Settings.ProxyCreationEnabled
			);

			IncludeAttibutesIsM2M(
				sb, content.Attributes.Where(x => x.IsM2M),
				context.Settings.ProxyCreationEnabled, content.SplitArticles);
			
			sb.AppendLine(@"}
}");
			return sb.ToString();
		}

		private static void IncludeContructor(StringBuilder sb, ContentInfo content)
		{
			sb.AppendLine($"public {content.MappedName}()");
			sb.AppendLine("		{");

			foreach (var attribute in content.Attributes.Where(x => x.IsM2O))
			{
				sb.AppendLine(@$"			{attribute.MappedName} = new HashSet<{attribute.RelatedContent.MappedName}>();");
			}

			foreach (var attribute in content.Attributes.Where(x => x.IsM2M))
			{
				sb.AppendLine(@$"			{attribute.MappedName} = new HashSet<{attribute.RelatedContent.MappedName}>();");
			}

			sb.AppendLine("		}");
		}

		private static void IncludeBaseAttibutes(StringBuilder sb, IEnumerable<AttributeInfo> attributes, bool useUrlsReplace,
			string className)
		{
			foreach (var attribute in attributes)
			{
				if (useUrlsReplace && attribute.CanContainPlaceholders)
				{
					sb.AppendLine($@"
		private {attribute.NetType} _internal{attribute.MappedName};
		public virtual {attribute.NetType} {attribute.MappedName} 
		{{ 
            get {{ return _internal{attribute.MappedName}; }}
            set {{ _internal{attribute.MappedName} = {className}.Current?.ReplacePlaceholders(value) ?? value;}}
        }}");
				}
				else
				{
					sb.AppendLine(@$"		public virtual {attribute.NetType} {attribute.MappedName} {{ get; set; }}");
				}
			}
		}

		private static void IncludeAttibutesIsO2MRelatedContent(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
		{
			foreach (var attribute in attributes)
			{
				sb.AppendLine($@"
        /// <summary>
		/// {attribute.Description ?? string.Empty}
		/// </summary>			
		public virtual {attribute.RelatedContent.MappedName} {attribute.MappedName} {{ get; set; }}");
			}
		}

		private static void IncludeAttibutesIsO2MOriginalMappedName(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
		{
			foreach (var attribute in attributes)
			{
				sb.AppendLine($@"
        /// <summary>
		/// {attribute.Description ?? string.Empty}
		/// </summary>
		public virtual Int32? {attribute.OriginalMappedName} {{ get; set; }}");
			}
		}

		private static void IncludeAttibutesIsM2O(StringBuilder sb, IEnumerable<AttributeInfo> attributes, bool useVirtualModifier)
		{
			foreach (var attribute in attributes)
			{
				sb.AppendLine($@"
		/// <summary>
		/// {attribute.Description ?? string.Empty}
		/// </summary>");
				sb.Append("		public ");

				if (useVirtualModifier)
				{
					sb.Append("virtual ");
				}

				sb.AppendLine($"ICollection<{attribute.RelatedContent.MappedName}> {attribute.MappedName} {{ get; set; }}");
			}
		}

		private static void IncludeAttibutesIsM2M(StringBuilder sb, IEnumerable<AttributeInfo> attributes, bool useVirtualModifier, 
			bool splitArticles)
		{
			foreach (var attribute in attributes)
			{
				sb.AppendLine($@"
		/// <summary>
		/// {attribute.Description ?? string.Empty}
		/// </summary>");
				sb.Append("		public ");
				if (useVirtualModifier)
				{
					sb.Append("virtual ");
				}

				sb.AppendLine(@$"ICollection<{attribute.RelatedContent.MappedName}> {attribute.MappedName} {{ get; set; }}");
				if (splitArticles)
				{
					sb.AppendLine($@"
		/// <summary>
		/// Only for internal usage !!! (do not use directly) {attribute.Description ?? string.Empty}
		/// </summary>");
					sb.Append("		internal ");
					if (useVirtualModifier)
					{
						sb.Append("virtual ");
					}

					sb.AppendLine(@$"ICollection<{attribute.RelatedContent.MappedName}> {attribute.MappedName}Reverse {{ get; set; }}");
				}
            }
		}

	}
}