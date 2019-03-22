using System.Linq;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Tests.Infrastructure;
using Quantumart.QP8.EntityFrameworkCore;
using NUnit.Framework;

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
                    .ThenInclude(y=> y.ToSymmetricRelationAtricleLinkedItem)
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
                    .ThenInclude(y => y.ToSymmetricRelationAtricleLinkedItem)
                    .ThenInclude(y => y.ToSymmetricRelation)
                    .ThenInclude(z=>z.SymmetricRelationArticleLinkedItem)
                    .FirstOrDefault();
                if (firstItem.SymmetricRelation.Count == 0)
                {
                    Assert.Fail("SymmerticRelation field not filled");
                }
                else
                {
                    foreach (var item in firstItem.SymmetricRelation.Select(x=>x.ToSymmetricRelationAtricleLinkedItem))
                    {
                        if (item.ToSymmetricRelation.Count > 0)
                        {
                            var ids = item.ToSymmetricRelation.Select(s => s.SymmetricRelationArticleLinkedItemId).ToList();
                            if (!ids.Contains(firstItem.Id))
                            {
                                Assert.Fail("SymmerticRelation field not filled");
                            }
                        }
                        else Assert.Fail("SymmerticRelation field not filled");
                    }
                }
            }
        }
    }
}
