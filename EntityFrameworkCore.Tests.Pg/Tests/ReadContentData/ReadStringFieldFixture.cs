using System.Linq;
using EntityFrameworkCore.Tests.Pg.Infrastructure;
using Npgsql;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.ReadContentData;

[TestFixture]
public class ReadStringFieldFixture : DataContextFixtureBase
{
    [Test, Combinatorial]
    [Category("ReadContentData")]
    public void Check_That_StringItem_StringValue_NotEmpty([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
        using (var context = GetDataContext(access, mapping, connection))
        {
            var items = context.StringItems.ToArray();
            Assert.That(items, Is.Not.Null.And.Not.Empty);
            Assert.That(items, Is.All.Matches<StringItem>(itm => !string.IsNullOrEmpty(itm.StringValue)));
        }
    }
}