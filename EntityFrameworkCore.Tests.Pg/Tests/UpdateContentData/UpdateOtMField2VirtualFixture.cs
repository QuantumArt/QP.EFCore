﻿using EntityFrameworkCore.Tests.Pg.Infrastructure;
using NUnit.Framework;
using System;
using System.Linq;
using Npgsql;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData
{
    [TestFixture]
    public class UpdateOtMField2VirtualFixture : DataContextFixtureBase
    {
  
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_OtM_Field_ToVirual_isCreated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var item = new OtMItemForUpdateVirtual() { Title = $"{nameof(Check_That_OtM_Field_ToVirual_isCreated)}_{Guid.NewGuid()}" };
                var dict = context.FileFieldsItems.FirstOrDefault();

                Assert.That(dict, Is.Not.Null);

                item.Reference_ID = dict.Id;

                context.OtMItemForUpdateVirtuals.Add(item);
                context.SaveChanges();
            }
        }

    }
}
