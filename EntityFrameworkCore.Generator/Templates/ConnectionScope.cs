using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
    internal static class ConnectionScope
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Data.SqlClient;

namespace {ns}
{{
    public class {context.Model.Schema.ClassName}ConnectionScope
    {{}}
}}";
        }
    }
}