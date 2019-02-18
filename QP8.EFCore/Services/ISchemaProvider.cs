using Quantumart.QP8.CoreCodeGeneration.Services;

namespace Quantumart.QP8.EFCore.Services
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}