using EntityFrameworkCore.Tests.Pg.Infrastructure;
using Npgsql;
using NUnit.Framework;
using System.Linq;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.Shema
{
    [TestFixture]
    public class SchemaFixture : DataContextFixtureBase
    {
        [Test, Combinatorial]
        [Category("Shema")]
        public void DataContext_Schema_GetContentInfo([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var contentId = context.GetInfo<Schema>().Id;
                int expectedContentId = ValuesHelper.GetSchemaContentId(mapping);

                Assert.That(contentId, Is.EqualTo(expectedContentId));
            }
        }

        [Test, Combinatorial]
        [Category("Shema")]
        public void DataContext_Schema_GetAttributeInfo([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var attributeId = context.GetInfo<Schema>(a => a.Title).Id;
                var expectedattributeId = ValuesHelper.GetSchemaTitleFieldId(mapping);

                Assert.That(attributeId, Is.EqualTo(expectedattributeId));
            }
        }

        [Test, Combinatorial]
        [Category("Shema")]
        public void DataContext_Schema_CheckBackwadFieldIsLoaded([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var content = context.GetInfo<MtMDictionaryForUpdate>();

                Assert.True(content.Attributes
                    .Count(x => x.MappedName == "BackwardForReference_MtMItemForUpdate") > 0);
            }
        }
    }
}
