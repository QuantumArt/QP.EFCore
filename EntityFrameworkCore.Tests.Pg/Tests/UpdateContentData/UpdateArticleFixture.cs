using EntityFrameworkCore.Tests.Pg.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.SqlClient;
using Npgsql;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData
{
    [TestFixture]
    public class UpdateArticleFixture : DataContextFixtureBase
    {
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_Article_IsInserted([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var status = context.StatusTypes.FirstOrDefault(s => s.StatusTypeName == "Published");
                Assert.That(status, Is.Not.Null);

                var title = Guid.NewGuid().ToString();
                var item = new ItemForInsert() { Title = title, StatusType = status };
                var id = item.Id;
                var created = item.Created;
                var modified = item.Modified;


                context.ItemsForInsert.Add(item);
                context.SaveChanges();

                Assert.That(item.Id, Is.Not.EqualTo(id));
                Assert.That(item.Title, Is.EqualTo(title));
                Assert.That(item.Created, Is.Not.EqualTo(created));
                Assert.That(item.Modified, Is.Not.EqualTo(modified));

                var insertedItem = context.ItemsForInsert.FirstOrDefault(itm => itm.Id == item.Id);

                Assert.That(insertedItem, Is.Not.Null);
                Assert.That(insertedItem.Id, Is.EqualTo(item.Id));
                Assert.That(insertedItem.Title, Is.EqualTo(item.Title));
                Assert.That(insertedItem.Created, Is.EqualTo(item.Created));
                Assert.That(insertedItem.Modified, Is.EqualTo(item.Modified));
            }
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_Article_Status_IsUpdated([Values(ContentAccess.Live)] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var none = context.StatusTypes.FirstOrDefault(s => s.SiteId == context.SiteId && s.StatusTypeName == "None");
                var published = context.StatusTypes.FirstOrDefault(s => s.SiteId == context.SiteId && s.StatusTypeName == "Published");
                
                Assert.That(published, Is.Not.Null);
                Assert.That(none, Is.Not.Null);

                var item = context.ItemsForUpdate.FirstOrDefault();
                Assert.That(item, Is.Not.Null);

                foreach (var status in new[] { none, published })
                {
                    item.StatusType = published;
                    context.SaveChanges();

                    var updatedItem = context.ItemsForUpdate.Where(itm => itm.Id == item.Id).FirstOrDefault();
                    Assert.That(updatedItem, Is.Not.Null);
                    Assert.That(updatedItem.StatusTypeId, Is.EqualTo(published.Id));
                }
            }
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_Article_IsUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var item = context.ItemsForUpdate.FirstOrDefault();
                Assert.That(item, Is.Not.Null);

                var id = item.Id;
                var title = Guid.NewGuid().ToString();
                var modified = item.Modified;

                item.Title = title;

                context.SaveChanges();

                Assert.That(item.Id, Is.EqualTo(id));
                Assert.That(item.Title, Is.EqualTo(title));
                Assert.That(item.Modified, Is.Not.EqualTo(modified));

                var updatedItem = context.ItemsForUpdate.FirstOrDefault(itm => itm.Id == id);

                Assert.That(updatedItem, Is.Not.Null);
                Assert.That(updatedItem.Id, Is.EqualTo(id));
                Assert.That(updatedItem.Title, Is.EqualTo(title));
                Assert.That(updatedItem.Modified, Is.EqualTo(item.Modified));
            }
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_Article_IsDeleted([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {

            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Cnn.ExternalTransaction = transaction.GetDbTransaction();
                    var status = context.StatusTypes.FirstOrDefault(s => s.StatusTypeName == "Published");
                    Assert.That(status, Is.Not.Null);

                    var title = Guid.NewGuid().ToString();
                    var item = new ItemForInsert() { Title = title, StatusType = status };

                    context.ItemsForInsert.Add(item);
                    context.SaveChanges();
                    Assert.True(context.ItemsForInsert.Count(x => x.Id == item.Id) > 0);

                    context.ItemsForInsert.Remove(item);
                    context.SaveChanges();

                    var deletedItem = context.ItemsForInsert.FirstOrDefault(itm => itm.Id == item.Id);
                    Assert.That(deletedItem, Is.Null);
                }
            }

        }

        /*
        [Test]
        public void Check_That_MassUpdateIsCalledTwice_With2TranactionsWorks_Works()
        {

            //using (var context = GetDataContext(ContentAccess.Live, Mapping.DatabaseDefaultMapping))
            {
                var values1 = new Dictionary<string, string>() { {"CONTENT_ITEM_ID", "163955" }, { "StringValueField", "1"}};
                var v1 = new List<Dictionary<string, string>>() { values1 };
                var values2 = new Dictionary<string, string>() { { "CONTENT_ITEM_ID", "163955" }, { "StringValueField", "2" }};
                var v2 = new List<Dictionary<string, string>>() { values1 };
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Cnn.ExternalTransaction = transaction.GetDbTransaction();
                    context.Cnn.MassUpdate(622, v1, 1);
                    transaction.Commit();
                    context.Cnn.ExternalTransaction = null;
                }

                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Cnn.ExternalTransaction = transaction.GetDbTransaction();
                    context.Cnn.MassUpdate(622, v2, 1);
                    transaction.Commit();
                    context.Cnn.ExternalTransaction = null;
                }
            }

            
        } */
    }
}
