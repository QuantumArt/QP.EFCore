using Quantumart.QP8.EntityFrameworkCore.Generator.Models;
using System;
using System.Linq.Expressions;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.EmbeddedModels
{
    public interface IQPSchema
    {
        SchemaInfo GetInfo();
        ContentInfo GetInfo<T>() where T : IQPArticle;
        AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector) where Tcontent : IQPArticle;
    }
}
