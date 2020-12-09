
using Quantumart.QP8.CoreCodeGeneration.Services;

namespace EntityFrameworkCore.Data
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}