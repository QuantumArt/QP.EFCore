﻿using System;
using System.Linq;
using EntityFrameworkCore.Tests.Pg.Infrastructure;
using Npgsql;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData
{
    [TestFixture]
    public class UpdateFixture : DataContextUpdateFixtureBase
    {
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void DataContext_AfiellFieldsItems_UpdateString([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.String = Guid.NewGuid().ToString(), a => a.String);
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void DataContext_AfiellFieldsItems_UpdateDateTime([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.DateTime = DateTime.Now, a => a.DateTime);
        }

        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void DataContext_AfiellFieldsItems_Insert([Values(ContentAccess.Stage)] ContentAccess access, [Values(Mapping.StaticMapping)] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var article = new AfiellFieldsItem()
                {
                    String = "str",
                    TextBox = "tbx",
                    DateTime = DateTime.Now,
                    Image = "users.gif",
                    Integer = 90,
                    Created = DateTime.Today
                };

                context.AfiellFieldsItems.Add(article);
                context.SaveChanges();

                Assert.That(article.Id, Is.Not.EqualTo(0));
                Assert.That(context.AfiellFieldsItems.Any(a => a.Id == article.Id), Is.True);
            }
        }
    }
}
