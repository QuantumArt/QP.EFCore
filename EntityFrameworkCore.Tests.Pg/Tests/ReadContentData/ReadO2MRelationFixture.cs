﻿using EntityFrameworkCore.Tests.Pg.Infrastructure;
using NUnit.Framework;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.ReadContentData
{
    [TestFixture]
    public class ReadO2MRelationFixture :DataContextFixtureBase
    {
        [Test]
        [Category("ReadContentData")]
        public void Check_That_o2m_Relation_Field_toMapped_IsLoaded([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var item = context.OtMItemsForMapping.FirstOrDefault();
                var related = context.OtMRelatedItemsWithMapping.FirstOrDefault();
                Assert.That(item, Is.Not.Null);
                Assert.That(related, Is.Not.Null);
                Assert.AreEqual(item.OtMReferenceMapping_ID, related.Id);
                Assert.AreEqual(item.OtMReferenceMapping.Id, related.Id);
            }
        }

        [Test]
        [Category("ReadContentData")]
        public void Check_That_o2m_Relation_Field_toNotMapped_IsLoaded([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var item = context.OtMItemsToContentWithoutMapping.FirstOrDefault();
                Assert.That(item, Is.Not.Null);
                Assert.That(item.OtMReferenceMapping_ID, Is.Not.Null);
            }
        }
        
        [Test]
        [Category("ReadContentData")]
        public void Check_That_o2m_Relation_Field_toMapped_IsIncluded([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
            {
                var item = context.OtMItemsForMapping.Include("OtMReferenceMapping").FirstOrDefault();
                Assert.That(item, Is.Not.Null);
                Assert.That(item.OtMReferenceMapping, Is.Not.Null);
                Assert.That(item.OtMReferenceMapping_ID, Is.Not.Null);
            }
        }
    }
}
