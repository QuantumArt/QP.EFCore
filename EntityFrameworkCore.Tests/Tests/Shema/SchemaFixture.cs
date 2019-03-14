using EntityFrameworkCore.Tests.Infrastructure;
using NUnit.Framework;
using Quantumart.QP8.EFCore.Services;

namespace EntityFrameworkCore.Tests.Shema
{
    [TestFixture]
    public class SchemaFixture : DataContextFixtureBase
    {
        [Test, Combinatorial]
        [Category("Shema")]
        public void DataContext_Schema_GetContentInfo([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
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
            using (var context = GetDataContext(access, mapping))
            {
                var attributeId = context.GetInfo<Schema>(a => a.Title).Id;
                var expectedattributeId = ValuesHelper.GetSchemaTitleFieldId(mapping);

                Assert.That(attributeId, Is.EqualTo(expectedattributeId));
            }
        }
    }
}
