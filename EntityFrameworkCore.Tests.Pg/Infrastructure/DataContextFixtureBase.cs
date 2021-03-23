using System.Data.Common;
using System.IO;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.Infrastructure
{
    public class DataContextFixtureBase
    {
        private const string DefaultSiteName = "original_site";
        private const string DynamicSiteName = "dynamic_site";
        private const string DefaultMappingResult = @"ModelMappingResult.xml";
        private const string DynamicMappingResult = @"DynamicMappingResult.xml";

        protected EFCoreModel GetDataContext(ContentAccess access, Mapping mapping, DbConnection connection)
        {

            switch (mapping)
            {
                case Mapping.StaticMapping:
                    return EFCoreModel.CreateWithStaticMapping(access, connection);
                case Mapping.DatabaseDefaultMapping:
                    return EFCoreModel.CreateWithDatabaseMapping(access, DefaultSiteName, connection);
                case Mapping.DatabaseDynamicMapping:
                    return EFCoreModel.CreateWithDatabaseMapping(access, DynamicSiteName, connection);
                case Mapping.FileDefaultMapping:
                    return EFCoreModel.CreateWithFileMapping(access, GetPath(DefaultMappingResult), connection);
                case Mapping.FileDynamicMapping:
                    return EFCoreModel.CreateWithFileMapping(access, GetPath(DynamicMappingResult), connection);
                default:
                    return EFCoreModel.Create(connection);
            }
        }

        protected string GetPath(string file)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, file);
        }
    }
}
