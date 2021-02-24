using EntityFrameworkCore.Tests.Pg.Infrastructure;
using NUnit.Framework;
using System;
using System.Linq;
using Npgsql;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData
{
    [TestFixture]
    public class UpdateOtMFieldFixture : DataContextFixtureBase
    {
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_OtM_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var items = context.OtMItemsForUpdate.Take(5).ToArray();
                var dict = context.OtMDictionaryForUpdate.FirstOrDefault();
                Assert.That(dict, Is.Not.Null);

                foreach (var item in items)
                {
                    item.Title = $"{nameof(Check_That_OtM_Field_isUpdated)}_{Guid.NewGuid()}";
                    item.Reference = dict;
                }

                context.SaveChanges();
            }
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_OtM_Field_isCreated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var item = new OtMItemForUpdate() { Title = $"{nameof(Check_That_OtM_Field_isCreated)}_{Guid.NewGuid()}" };
                var dict = context.OtMDictionaryForUpdate.FirstOrDefault();

                Assert.That(dict, Is.Not.Null);

                item.Reference = dict;

                context.OtMItemsForUpdate.Add(item);
                context.SaveChanges();
            }
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_OtM_Field_And_Dict_isCreated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var item = new OtMItemForUpdate() { Title = $"{nameof(Check_That_OtM_Field_And_Dict_isCreated)}_{Guid.NewGuid()}" };
                var dict = new OtMDictionaryForUpdate() { Title = $"{nameof(Check_That_OtM_Field_And_Dict_isCreated)}_{Guid.NewGuid()}" };

                item.Reference = dict;

                context.OtMItemsForUpdate.Add(item);
                context.OtMDictionaryForUpdate.Add(dict);

                context.SaveChanges();
            }
        }
    }
}
