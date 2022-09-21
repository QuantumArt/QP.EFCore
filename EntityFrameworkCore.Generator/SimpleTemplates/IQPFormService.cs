using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class IQPFormService
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
namespace {ns}
{{
    public interface IQPFormService
    {{
        string GetFormNameByNetNames(string netContentName, string netFieldName);
        string ReplacePlaceholders(string text);
    }}
}}";
        }
    }
}