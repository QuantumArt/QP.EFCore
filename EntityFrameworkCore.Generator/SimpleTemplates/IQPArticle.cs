using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates;

internal static class IQPArticle
{
    public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return @$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Collections;

namespace {ns};

public interface IQPArticle
{{
    int Id {{ get; set; }}
    int StatusTypeId {{ get; set; }}
    bool Visible {{ get; set; }}
    bool Archive {{ get; set; }}
    DateTime Created {{ get; set; }}
    DateTime Modified {{ get; set; }}
    int LastModifiedBy {{ get; set; }}
    StatusType StatusType {{ get; set; }}

    Hashtable Pack(IQPFormService context, params string[] propertyNames);
}}";
    }
}