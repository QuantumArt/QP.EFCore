using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates;

internal static class IQPLibraryService
{
    public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return @$"{context.Settings.GeneratedCodePrefix}
namespace {ns};

public interface IQPLibraryService
{{
    string GetUrl(string input, string className, string propertyName);

    string GetUploadPath(string input, string className, string propertyName);

    string ReplacePlaceholders(string text);
}}";
    }
}