using EntityFrameworkCore.Tests.Infrastructure;
using NUnit.Framework;
using Quantumart.QP8.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkCore.Tests.UpdateContentData
{
    [TestFixture]
    public class UpdateMtMFieldFixture : DataContextFixtureBase
    {
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_MtM_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var items = context.MtMItemsForUpdate.Take(2).ToArray();
                var dict = context.MtMDictionaryForUpdate.Take(2).ToArray();

                foreach (var item in items)
                {
                    item.Title = $"{nameof(Check_That_MtM_Field_isUpdated)}_{Guid.NewGuid()}";

                    foreach (var d in dict)
                    {
                        item.Reference.Add(
                            new MtMItemForUpdate2MtMDictionaryForUpdateForReference() { MtMItemForUpdateItem = item, MtMDictionaryForUpdateLinkedItem = d  });
                    }
                }

                context.SaveChanges();
            }
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_MtM_Field_isCreated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var item = new MtMItemForUpdate() { Title = $"{nameof(Check_That_MtM_Field_isCreated)}_{Guid.NewGuid()}" };

                var dict = context.MtMDictionaryForUpdate.Take(2).ToArray();

                foreach (var d in dict)
                {
                    item.Reference.Add(
                        new MtMItemForUpdate2MtMDictionaryForUpdateForReference() { MtMItemForUpdateItem = item, MtMDictionaryForUpdateLinkedItem = d });
                }

                context.MtMItemsForUpdate.Add(item);

                context.SaveChanges();
            }
        }
    }
}
