using EntityFrameworkCore.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.Linq;
using Quantumart.QP8.EntityFrameworkCore.Generator.EmbeddedModels;

namespace EntityFrameworkCore.Tests.UpdateContentData
{
    public class DataContextUpdateFixtureBase : DataContextFixtureBase
    {
        protected void UpdateProperty<TArticle>(ContentAccess access, Mapping mapping, Action<TArticle> setField, Func<TArticle, object> getField)
           where TArticle : class
        {
            using (var context = GetDataContext(access, mapping))
            {
                var oldItem = context.Set<TArticle>().FirstOrDefault();
                Assert.That(oldItem, Is.Not.Null);

                setField(oldItem);
                context.SaveChanges();

                var newItem = context.Set<TArticle>().FirstOrDefault();
                Assert.That(newItem, Is.Not.Null);

                Assert.That(getField(newItem), Is.EqualTo(getField(oldItem)));
            }
        }
    }
}
