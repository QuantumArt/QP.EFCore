﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
    internal static class ContentsClassExtensions
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var sb = new StringBuilder(context.Settings.GeneratedCodePrefix);

            sb.AppendLine($@"
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace {ns}");
            sb.AppendLine("{");

            foreach (var content in context.Model.Contents)
            {
                IncludeTemplateForContent(sb, context.Model.Schema, content);
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        private static void IncludeTemplateForContent(StringBuilder sb, SchemaInfo schema, ContentInfo content)
        {
            sb.AppendLine($"public partial class {content.MappedName}: IQPArticle");
            sb.AppendLine("{");

            IncludeStaticMembers(sb, content, schema.ReplaceUrls);
            if (content.Attributes.Any(x => x.GenerateLibraryUrl || x.GenerateUploadPath || x.IsNullable))
            {
                IncludeGenaratedProperties(sb, content, schema.ClassName);
            }

            IncludeInterfaceImplementationPack(sb, content);

            sb.AppendLine("}");
        }

        private static void IncludeStaticMembers(StringBuilder sb, ContentInfo content, bool useUrlsReplace)
        {
            sb.AppendLine("#region Static members");
            sb.AppendLine(
                $"protected static readonly Dictionary<string, Func<{content.MappedName}, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<{content.MappedName},  IQPFormService, string>>");
            sb.AppendLine("{");

            foreach (var attribute in content.Attributes.Where(x => !x.IsM2O && !x.IsM2M))
            {
                IncludeDictionaryItem(sb, attribute, content.MappedName, useUrlsReplace);
            }

            sb.AppendLine("};");
            sb.AppendLine("#endregion");

            static void IncludeDictionaryItem(StringBuilder sb, AttributeInfo attribute, string contentName,
                bool useUrlsReplace)
            {
                sb.Append(" {");
                sb.Append(
                    $@"""{attribute.OriginalMappedName}"", new Func<{contentName}, IQPFormService, string>((self, ctx) => self.{attribute.OriginalMappedName} != null ? ");

                switch (attribute.Type)
                {
                    case "DateTime":
                    case "O2M":
                    case "Numeric":
                    case "Date":
                    case "Time":
                        sb.Append($" self.{attribute.OriginalMappedName}.ToString() ");
                        break;
                    case "Boolean":
                        sb.Append($@" self.{attribute.OriginalMappedName}.Value ? ""1"" : ""0"" ");
                        break;
                    default:
                    {
                        if (useUrlsReplace && attribute.CanContainPlaceholders)
                        {
                            sb.Append($" ctx.ReplacePlaceholders(self.{attribute.OriginalMappedName}) ");
                        }
                        else
                        {
                            sb.Append($@" self.{attribute.OriginalMappedName} ");
                        }

                        break;
                    }
                }

                sb.Append(" : null)");
                sb.AppendLine("},");
            }
        }

        private static void IncludeGenaratedProperties(StringBuilder sb, ContentInfo content, string className)
        {
            sb.AppendLine("#region Genarated properties");
            IncludeUrlProperties(sb,
                content.Attributes.Where(x => x.GenerateLibraryUrl), className,
                content.MappedName);

            IncludeUploadPathProperties(sb,
                content.Attributes.Where(x => x.GenerateUploadPath), className,
                content.MappedName);

            IncludeIsNullableProperties(sb, content.Attributes.Where(x => x.IsNullable));

            sb.AppendLine("#endregion");

            static void IncludeUrlProperties(StringBuilder sb, IEnumerable<AttributeInfo> attributes, string className,
                string contentName)
            {
                foreach (var attribute in attributes)
                {
                    sb.AppendLine($@"
        public string {attribute.MappedName}Url 
		{{
            get {{ return {className}.Current.GetUrl(this.{attribute.MappedName}, ""{contentName}"", ""{attribute.MappedName}""); }}
        }}");
                }
            }

            static void IncludeUploadPathProperties(StringBuilder sb, IEnumerable<AttributeInfo> attributes,
                string className,
                string contentName)
            {
                foreach (var attribute in attributes)
                {
                    sb.AppendLine($@"
        public string {attribute.MappedName}UploadPath 
		{{
            get {{ return {className}.Current.GetUploadPath(this.{attribute.MappedName}, ""{contentName}"", ""{attribute.MappedName}""); }}
        }}");
                }
            }

            static void IncludeIsNullableProperties(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
            {
                foreach (var attribute in attributes)
                {
                    sb.AppendLine($@"
        public {attribute.ExactType} {attribute.MappedName}Exact 
        {{
            get {{ return this.{attribute.MappedName} == null ? default({attribute.ExactType}) : this.{attribute.MappedName}.Value; }} 
        }}");
                }
            }
        }

        private static void IncludeInterfaceImplementationPack(StringBuilder sb, ContentInfo content)
        {
            sb.AppendLine($@"

        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {{
                Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {{
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames(""{content.MappedName}"", x.Key), y => y.Value(this, context)));
            }}
            else
            {{
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {{
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }}
            }}

            return table;
                }}");
        }
    }
}