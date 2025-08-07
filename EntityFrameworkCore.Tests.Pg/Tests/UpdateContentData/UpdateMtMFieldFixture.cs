using System;
using System.Linq;
using EntityFrameworkCore.Tests.Pg.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData;

[TestFixture]
public class UpdateMtMFieldFixture : DataContextFixtureBase
{
    [Test, Combinatorial]
    [Category("UpdateContentData")]
    public void Check_That_MtM_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
        using (var context = GetDataContext(access, mapping, connection))
        {
            int PublishedStatusId = context.StatusTypes.OrderByDescending(x => x.Weight).FirstOrDefault().Id;
            var item = new MtMItemForUpdate() { Title = $"{nameof(Check_That_MtM_Field_isUpdated)}_{Guid.NewGuid()}", StatusTypeId = PublishedStatusId };
            context.MtMItemsForUpdate.Add(item);
            
            context.SaveChanges();
            item = context.MtMItemsForUpdate.FirstOrDefault(itm => itm.Id == item.Id);

            var dict = context.MtMDictionaryForUpdate.Take(2).ToArray();
            if (dict.Length == 0)
            {
                dict = AddDictionaryPublishedItems(context, PublishedStatusId);
            }

            foreach (var d in dict)
            {
                item.Reference.Add(d);
            }

            context.SaveChanges();
          
            var updatedItem = context.MtMItemsForUpdate.FirstOrDefault(itm => itm.Id == item.Id);
            Assert.That(updatedItem != null);

            foreach (var d in dict)
            {
                Assert.That(updatedItem.Reference.Any(x => x.Id == d.Id));                    
            }
            updatedItem.Reference.Clear();
            updatedItem.Title = $"{nameof(Check_That_MtM_Field_isUpdated)}_{Guid.NewGuid()}";
            context.SaveChanges();

            var clearedItem = context.MtMItemsForUpdate.FirstOrDefault(itm => itm.Id == item.Id);
            Assert.That(clearedItem != null);
            Assert.That(clearedItem.Reference.Count() == 0);
        }
    }

    [Test, Combinatorial]
    [Category("UpdateContentData")]
    public void Check_That_MtM_Field_isCreated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
        using (var context = GetDataContext(access, mapping, connection))
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Cnn.ExternalTransaction = transaction.GetDbTransaction();

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

                var updatedItem = context.MtMItemsForUpdate.FirstOrDefault(itm => itm.Id == item.Id);
                Assert.That(updatedItem != null);

                foreach (var d in dict)
                {
                    Assert.That(updatedItem.Reference.Any(x => x.Id == d.Id));
                }
            }
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
