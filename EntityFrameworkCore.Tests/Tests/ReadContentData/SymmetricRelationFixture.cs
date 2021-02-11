using System.Linq;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Tests.Infrastructure;
using NUnit.Framework;
using Quantumart.QP8.EntityFrameworkCore.Generator.EmbeddedModels;

namespace EntityFrameworkCore.Tests.ReadContentData
{
    [TestFixture]
    class SymmetricRelationFixture : DataContextFixtureBase
    {
        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_That_Symmetric_Relation_Field_isLoaded([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var items = context.SymmetricRelationArticles
                    .Include(x => x.SymmetricRelation)
                    .ThenInclude(y=> y.ToSymmetricRelation)
                    .FirstOrDefault();
                Assert.That(items.SymmetricRelation.Count, Is.Not.EqualTo(0));
            }
        }

        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_That_BackSymmetric_Relation_Field_isLoaded([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var firstItem = context.SymmetricRelationArticles
                    .Include(x => x.SymmetricRelation)
                    .ThenInclude(y => y.ToSymmetricRelation)
                    .ThenInclude(z=>z.SymmetricRelation)
                    .FirstOrDefault();
                if (firstItem.SymmetricRelation.Count == 0)
                {
                    Assert.Fail("SymmerticRelation field not filled");
                }
                else
                {
                    foreach (var item in firstItem.SymmetricRelation)
                    {
                       
                        var ids = item.ToSymmetricRelation.Select(x => x.Id);
                        if (!ids.Contains(firstItem.Id))
                        {
                            Assert.Fail("SymmerticRelation field not filled");
                        }
                       
                    }
                }
            }
        }
    }
}
