using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates;

internal static class ISchemaProvider
{
    public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return @$"{context.Settings.GeneratedCodePrefix}

using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace {ns};

public interface ISchemaProvider
{{
    ModelReader GetSchema();
    object GetCacheKey();
}}";
    }
}