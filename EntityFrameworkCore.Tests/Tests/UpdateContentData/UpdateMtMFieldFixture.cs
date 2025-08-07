using System;
using System.Linq;
using EntityFrameworkCore.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.UpdateContentData;

[TestFixture]
public class UpdateMtMFieldFixture : DataContextFixtureBase
{
    [Test, Combinatorial]
    [Category("UpdateContentData")]
    public void Check_That_MtM_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        int itemId;
        MtMDictionaryForUpdate[] dictionaryForUpdate;
        
        using (var context = GetDataContext(access, mapping))
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Cnn.ExternalTransaction = transaction.GetDbTransaction();

                int PublishedStatusId = context.StatusTypes.OrderByDescending(x => x.Weight).FirstOrDefault().Id;
                var item = new MtMItemForUpdate() { Title = $"{nameof(Check_That_MtM_Field_isUpdated)}_{Guid.NewGuid()}", StatusTypeId = PublishedStatusId };
                context.MtMItemsForUpdate.Add(item);

                context.SaveChanges();
                itemId = item.Id;
                item = context.MtMItemsForUpdate.FirstOrDefault(itm => itm.Id == item.Id);

                var dict = context.MtMDictionaryForUpdate.Take(2).ToArray();
                if (dict.Length == 0)
                {
                    dict = AddDictionaryPublishedItems(context, PublishedStatusId);
                }

                dictionaryForUpdate = dict;
                item.Title = $"{nameof(Check_That_MtM_Field_isUpdated)}_{Guid.NewGuid()}";
                foreach (var d in dict)
                {
                    item.Reference.Add(d);
                    //d.BackwardForReference_MtMItemForUpdate.Add(item);
                }

                context.SaveChanges();
                transaction.Commit();
            }
       
        }

        using (var context = GetDataContext(access, mapping))
        {
            var updatedItem = context.MtMItemsForUpdate.Include(x=>x.Reference).FirstOrDefault(itm => itm.Id == itemId);
            Assert.That(updatedItem != null);

            foreach (var d in dictionaryForUpdate)
            {
                Assert.That(updatedItem.Reference.Any(x => x.Id == d.Id));
            }
        }
    }

    [Test, Combinatorial]
    [Category("UpdateContentData")]
    public void Check_That_MtM_Field_isCreated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        int itemId = 0;
        using (var context = GetDataContext(access, mapping))
        {
            int PublishedStatusId = context.StatusTypes.OrderByDescending(x => x.Weight).FirstOrDefault().Id;
            var item = new MtMItemForUpdate() { Title = $"{nameof(Check_That_MtM_Field_isCreated)}_{Guid.NewGuid()}", StatusTypeId = PublishedStatusId };

            var dict = context.MtMDictionaryForUpdate.Take(2).ToArray();
            if (dict.Length == 0)
            {
                dict = AddDictionaryPublishedItems(context, PublishedStatusId);
            }

            foreach (var d in dict)
            {
                item.Reference.Add(d);
            }

            context.MtMItemsForUpdate.Add(item);

            context.SaveChanges();
            itemId = item.Id;
            var updatedItem = context.MtMItemsForUpdate.FirstOrDefault(itm => itm.Id == item.Id);
            Assert.That(updatedItem != null);

            foreach (var d in dict)
            {
                Assert.That(updatedItem.Reference.Any(x => x.Id == d.Id));
            }
        }
        using (var context = GetDataContext(access, mapping))
        {
            var item = context.MtMItemsForUpdate.Include(i => i.Reference).Where(x => x.Id == itemId)
                .FirstOrDefault();

            Assert.IsNotNull(item);
            item.Title = $"{nameof(Check_That_MtM_Field_isCreated)}_{Guid.NewGuid()}";
            item.Reference.Clear();
            context.SaveChanges();
        }

        using (var context = GetDataContext(access, mapping))
        {
            var item = context.MtMItemsForUpdate.Include(i => i.Reference).Where(x=>x.Id == itemId)
                .FirstOrDefault();

            Assert.IsNotNull(item);
            Assert.IsEmpty(item.Reference);
        }
    }

    
    private static MtMDictionaryForUpdate[] AddDictionaryPublishedItems(EFCoreModel context, int PublishedStatusId)
    {
        MtMDictionaryForUpdate[] dict;
        context.MtMDictionaryForUpdate.Add(new MtMDictionaryForUpdate()
        {
            Title = $"{nameof(Check_That_MtM_Field_isUpdated)}_{Guid.NewGuid()}",
            StatusTypeId = PublishedStatusId
        });
        context.MtMDictionaryForUpdate.Add(new MtMDictionaryForUpdate()
        {
            Title = $"{nameof(Check_That_MtM_Field_isUpdated)}_{Guid.NewGuid()}",
            StatusTypeId = PublishedStatusId
        });
        dict = context.MtMDictionaryForUpdate.Take(2).ToArray();
        return dict;
    }
}