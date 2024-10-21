using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class StatusType
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}

namespace {ns}
{{
    public partial class StatusType
    {{
        public int Id {{ get; set; }}
        public string StatusTypeName {{ get; set; }}
        public int Weight {{ get; set; }}
        public int SiteId {{ get; set; }}
    }}
}}";
        }
    }
}