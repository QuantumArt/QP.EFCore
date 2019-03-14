using System.IO;
using NUnit.Framework;
using Quantumart.QP8.EFCore.Services;

namespace EntityFrameworkCore.Tests.Infrastructure
{
    public class DataContextFixtureBase
    {
        private const string DefaultSiteName = "original_site";
        private const string DynamicSiteName = "dynamic_site";
        private const string DefaultMappingResult = @"ModelMappingResult.xml";
        private const string DynamicMappingResult = @"DynamicMappingResult.xml";

        protected EFCoreModel GetDataContext(ContentAccess access, Mapping mapping)
        {

            switch (mapping)
            {
                case Mapping.StaticMapping:
                    return EFCoreModel.CreateWithStaticMapping(access);
                case Mapping.DatabaseDefaultMapping:
                    return EFCoreModel.CreateWithDatabaseMapping(access, DefaultSiteName);
                case Mapping.DatabaseDynamicMapping:
                    return EFCoreModel.CreateWithDatabaseMapping(access, DynamicSiteName);
                case Mapping.FileDefaultMapping:
                    return EFCoreModel.CreateWithFileMapping(access, GetPath(DefaultMappingResult));
                case Mapping.FileDynamicMapping:
                    return EFCoreModel.CreateWithFileMapping(access, GetPath(DynamicMappingResult));
                default:
                    return EFCoreModel.Create();
            }
        }

        protected string GetPath(string file)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, file);
        }
    }
}
