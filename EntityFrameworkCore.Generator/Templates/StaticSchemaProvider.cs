﻿using System.Collections.Generic;
using System.Text;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
    internal static class StaticSchemaProvider
    {
	    public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
	    {
		    cancellationToken.ThrowIfCancellationRequested();
		    var sb = new StringBuilder();
		    sb.AppendLine(@$"{context.Settings.GeneratedCodePrefix}
using System.Collections.Generic;
using System.Linq;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;
using QP.ConfigurationService.Models;
{context.Settings.Usings}

namespace {ns}
{{
    public class StaticSchemaProvider : ISchemaProvider
    {{
       public StaticSchemaProvider(){{}}

        #region ISchemaProvider implementation
        public ModelReader GetSchema()
        {{
            var schema = new ModelReader();

            schema.Schema.SiteName = ""{context.Model.Schema.SiteName ?? string.Empty}"";
            schema.Schema.ReplaceUrls = {context.Model.Schema.ReplaceUrls.ToString().ToLower()};
            schema.Schema.DBType = Quantumart.QP8.EntityFrameworkCore.Generator.Models.DatabaseType.{context.Model.Schema.DBType};

            schema.Attributes = new List<AttributeInfo>
            {{");

		    IncludeAttributes(sb, context.Model.Attributes);

		    sb.AppendLine(@"};

            var attributesLookup = schema.Attributes.ToLookup(a => a.ContentId, a => a);

            schema.Contents = new List<ContentInfo>
            {");

		    IncludeContents(sb, context.Model.Contents);

		    sb.AppendLine(@"};

            schema.Contents.ForEach(c => c.Attributes.ForEach(a => a.Content = c));

            return schema;
        }

        public object GetCacheKey()
        {
            return null;
        }
        #endregion
    }
}");
		    return sb.ToString();
	    }

	    private static void IncludeAttributes(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
        {
	        foreach (var attribute in attributes)
	        {
		        sb.AppendLine($@"
				new AttributeInfo
                {{
			        Id = {attribute.Id},
					ContentId = {attribute.ContentId},
					Name = ""{attribute.Name}"",
					MappedName = ""{attribute.MappedName}"",
					LinkId = {attribute.LinkId},
					Type = ""{attribute.Type}""
				}},");
	        }
        }

        private static void IncludeContents(StringBuilder sb, IEnumerable<ContentInfo> contents)
        {
	        foreach (var content in contents)
	        {
		        sb.AppendLine($@"
					new ContentInfo
			        {{
				        Id = {content.Id},
				        MappedName = ""{content.MappedName}"",
				        UseDefaultFiltration = {content.UseDefaultFiltration.ToString().ToLower()},
				        Attributes = new List<AttributeInfo>(attributesLookup[{content.Id}]),
				        IsVirtual = {content.IsVirtual.ToString().ToLower()}
			        }},");
	        }
        }
    }
}