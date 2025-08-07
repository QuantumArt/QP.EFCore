using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates;

internal static class IQPLink
{
    public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return @$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Collections;

namespace {ns};

public interface IQPLink
{{
    int Id {{ get; set; }}
    int LinkedItemId {{ get; set; }}
    int LinkId {{ get; }}

    IQPArticle Item {{ get; }}
    IQPArticle LinkedItem {{ get; }}
}}";
    }
}