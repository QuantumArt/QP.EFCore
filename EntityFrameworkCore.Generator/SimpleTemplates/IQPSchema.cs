﻿namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class IQPSchema
    {
        public static string GetTemplate(string ns)
        {
            return @$"
// Code generated by a source generator template
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;
using System;
using System.Linq.Expressions;

namespace {ns}
{{
    public interface IQPSchema
    {{
        SchemaInfo GetInfo();
        ContentInfo GetInfo<T>() where T : IQPArticle;
        AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector) where Tcontent : IQPArticle;
    }}
}}";
        }
    }
}