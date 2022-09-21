using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class IMappingConfigurator
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace {ns}
{{
    public interface IMappingConfigurator
    {{
        MappingInfo GetMappingInfo();
        void OnModelCreating(ModelBuilder modelBuilder);
		ModelReader GetSchema();
    }}

    public class MappingInfo
    {{
        public IModel DbCompiledModel {{ get; private set; }}
        public ModelReader Schema {{ get; private set; }}

        public MappingInfo(IModel dbCompiledModel, ModelReader schema)
        {{
            DbCompiledModel = dbCompiledModel;
            Schema = schema;
        }}
    }}
}}";
        }
    }
}