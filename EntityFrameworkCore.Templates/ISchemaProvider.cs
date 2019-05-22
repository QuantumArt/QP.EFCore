
using Quantumart.QP8.CoreCodeGeneration.Services;

namespace EntityFrameworkCore.Templates
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}