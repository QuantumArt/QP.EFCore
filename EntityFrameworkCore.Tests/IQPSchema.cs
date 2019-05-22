using Quantumart.QP8.CoreCodeGeneration.Services;
using System;
using System.Linq.Expressions;

namespace EntityFrameworkCore.Tests
{
    public interface IQPSchema
    {
        SchemaInfo GetInfo();
        ContentInfo GetInfo<T>() where T : IQPArticle;
        AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector) where Tcontent : IQPArticle;
    }
}
