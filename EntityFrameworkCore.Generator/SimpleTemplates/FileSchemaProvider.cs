using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class FileSchemaProvider
    {
        public static string GetTemplate(string ns, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace {ns}
{{
    public class FileSchemaProvider : ISchemaProvider
    {{
        private readonly string _path;

        public FileSchemaProvider(string path)
        {{
            _path = path;
        }}

        #region ISchemaProvider implementation
        public ModelReader GetSchema()
        {{
            return new ModelReader(_path, _ => {{ }});
        }}

        public object GetCacheKey()
        {{
            return _path;
        }}
        #endregion
    }}
}}";
        }
    }
}