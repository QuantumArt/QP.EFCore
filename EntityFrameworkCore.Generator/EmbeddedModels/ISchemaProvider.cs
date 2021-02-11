
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.EmbeddedModels
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}