using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class StatusType
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System;

namespace {ns}
{{
    public partial class StatusType
    {{
        public Int32 Id {{ get; set; }}
        public string StatusTypeName {{ get; set; }}
        public int Weight {{ get; set; }}
        public Int32 SiteId {{ get; set; }}
    }}
}}";
        }
    }
}