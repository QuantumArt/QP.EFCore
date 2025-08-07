using System;
using System.Linq;
using EntityFrameworkCore.Tests.Pg.Infrastructure;
using Npgsql;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData;

public class DataContextUpdateFixtureBase : DataContextFixtureBase
{
    protected void UpdateProperty<TArticle>(ContentAccess access, Mapping mapping, Action<TArticle> setField, Func<TArticle, object> getField)
       where TArticle : class, IQPArticle
    {
        using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
        using (var context = GetDataContext(access, mapping, connection))
        {
            var oldItem = context.Set<TArticle>().FirstOrDefault();
            Assert.That(oldItem, Is.Not.Null);

            setField(oldItem);
            context.SaveChanges();

            var newItem = context.Set<TArticle>().FirstOrDefault(n => n.Id == oldItem.Id);
            Assert.That(newItem, Is.Not.Null);

            Assert.That(getField(newItem), Is.EqualTo(getField(oldItem)));
        }
    }
}
