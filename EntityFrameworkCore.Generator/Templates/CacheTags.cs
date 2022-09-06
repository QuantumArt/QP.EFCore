using System.Collections.Generic;
using System.Text;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
    internal static class CacheTags
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var sb = new StringBuilder();
            sb.Append(@$"{context.Settings.GeneratedCodePrefix}
using System.Linq;
using QA.DotNetCore.Caching.Interfaces;
using QA.DotNetCore.Engine.Persistent.Interfaces.Settings;

namespace {ns}");

            sb.AppendLine("{");

            AppendQPContentClass(sb);
            AppendCacheTagsClass(sb, context.Model.Contents, context.Model.Schema.SiteId);
            AppendCacheTagUtilitiesClass(sb);

            sb.AppendLine("}");
            return sb.ToString();
        }

        private static void AppendQPContentClass(StringBuilder sb)
        {
            sb.AppendLine($@"
public class QPContent
{{
    public int Id {{ get; set; }}
    public int SiteId {{ get; set; }}
    public string Name {{ get; set; }}
    public string NetName {{ get; set; }}
}}");
        }

        private static void AppendCacheTagsClass(StringBuilder sb, IEnumerable<ContentInfo> contents, string siteId)
        {
            sb.AppendLine($@"
/// <summary>
/// Контентные версионные теги
/// </summary>
public static partial class CacheTags");
            sb.AppendLine("{");

            foreach (var content in contents)
            {
                sb.AppendLine($@"
/// <summary>
/// {content.Name}
/// </summary>
public static QPContent {content.MappedName} = new QPContent {{ Id = {content.Id}, SiteId = {siteId}, Name = ""{content.Name}"", NetName = ""{content.MappedName}""}};");
            }

            sb.AppendLine("}");
        }

        private static void AppendCacheTagUtilitiesClass(StringBuilder sb)
        {
            sb.AppendLine($@"
/// <summary>
/// Утилиты для работы с кештегами
/// </summary>
public class CacheTagUtilities
{{
    readonly IQpContentCacheTagNamingProvider _qpContentCacheTagNamingProvider;
    readonly QpSettings _qpSettings;

    public CacheTagUtilities(IQpContentCacheTagNamingProvider qpContentCacheTagNamingProvider, QpSettings qpSettings)
    {{
        _qpContentCacheTagNamingProvider = qpContentCacheTagNamingProvider;
        _qpSettings = qpSettings;
    }}
    
    /// <summary>
    /// Преобразование тегов в массив
    /// </summary>
    public string[] Merge(params QPContent[] tags)
    {{
        return tags.Select(c => _qpContentCacheTagNamingProvider.Get(c.Name, c.SiteId, _qpSettings.IsStage)).Where(t => t != null).ToArray();
    }}
}}");
        }
    }
}