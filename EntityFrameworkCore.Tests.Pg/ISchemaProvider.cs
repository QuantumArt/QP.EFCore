
using Quantumart.QP8.CoreCodeGeneration.Services;

namespace EntityFrameworkCore.Tests.Pg
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}