
using Quantumart.QP8.CoreCodeGeneration.Services;

namespace EntityFrameworkCore.Tests
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}