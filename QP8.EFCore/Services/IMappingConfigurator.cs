using Quantumart.QP8.CoreCodeGeneration.Services;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Quantumart.QP8.EFCore.Services
{
    public interface IMappingConfigurator
    {
        MappingInfo GetMappingInfo(DbConnection connection);
        void OnModelCreating(ModelBuilder modelBuilder);
    }

    public class MappingInfo
    {
        public IModel DbCompiledModel { get; private set; }
        public ModelReader Schema { get; private set; }

        public MappingInfo(IModel dbCompiledModel, ModelReader schema)
        {
            DbCompiledModel = dbCompiledModel;
            Schema = schema;
        }
    }
    public enum ContentAccess
    {
        /// <summary>
        /// Published articles
        /// </summary>
        Live = 0,
        /// <summary>
        /// Splitted versions of articles
        /// </summary>
        Stage = 1,
        /// <summary>
        /// Splitted versions of articles including invisible and archived (overrides useDefaultFiltration content setting)
        /// </summary>
        StageNoDefaultFiltration = 2
    }
}