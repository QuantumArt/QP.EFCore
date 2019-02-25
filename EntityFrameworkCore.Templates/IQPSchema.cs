using Quantumart.QP8.CoreCodeGeneration.Services;
using Quantumart.QP8.EFCore.Models;
using System;
using System.Linq.Expressions;

namespace EntityFrameworkCore.Templates
{
    public interface IQPSchema
    {
        SchemaInfo GetInfo();
        ContentInfo GetInfo<T>() where T : IQPArticle;
        AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector) where Tcontent : IQPArticle;
    }
}
