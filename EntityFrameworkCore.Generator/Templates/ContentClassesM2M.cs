using System.Text;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates;

internal static class ContentClassesM2M
{
	public static string GetTemplate(string ns, GenerationContext context, ContentInfo content,
		AttributeInfo attribute, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var sb = new StringBuilder(context.Settings.GeneratedCodePrefix);

		sb.AppendLine($@"
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace {ns};

");
		
		IncludeM2MClass(sb, content, attribute);
        if (attribute.RelatedContent.SplitArticles)
		{
            IncludeM2MReverseClass(sb, content, attribute);
		}

		return sb.ToString();
	}

	private static void IncludeM2MClass(StringBuilder sb, ContentInfo content, AttributeInfo attribute)
	{
		sb.AppendLine(@$"
    public partial class {attribute.M2MClassName}: IQPLink
    {{
		public {content.MappedName} {attribute.M2MPropertyName} {{ get; set; }}		
		public {attribute.RelatedContent.MappedName} {attribute.M2MRelatedPropertyName} {{ get; set; }}

		public int {attribute.M2MPropertyName}Id {{ get; set; }}
		public int {attribute.M2MRelatedPropertyName}Id {{ get; set; }}

		public int LinkId
		{{
            get {{ return {attribute.LinkId}; }}
        }}

		public int Id 
		{{
            get {{ return {attribute.M2MPropertyName}Id; }} 
            set {{ {attribute.M2MPropertyName}Id = value; }}
        }}
        public int LinkedItemId 
		{{ 
            get {{ return {attribute.M2MRelatedPropertyName}Id; }}
            set {{ {attribute.M2MRelatedPropertyName}Id = value; }}
        }}
		public IQPArticle Item {{ get {{ return {attribute.M2MPropertyName}; }} }}		
		public IQPArticle LinkedItem {{ get {{ return {attribute.M2MRelatedPropertyName}; }} }}
    }}");
	}

	private static void IncludeM2MReverseClass(StringBuilder sb, ContentInfo content, AttributeInfo attribute)
	{
		sb.AppendLine($@"
	public partial class {attribute.M2MReverseClassName}: IQPLink
	{{
		public {content.MappedName} {attribute.M2MReversePropertyName} {{ get; set; }}		
		public {attribute.RelatedContent.MappedName} {attribute.M2MReverseRelatedPropertyName} {{ get; set; }}

		public int {attribute.M2MReversePropertyName}Id {{ get; set; }}	
		public int {attribute.M2MReverseRelatedPropertyName}Id {{ get; set; }}

		public int LinkId
		{{
			get {{ return {attribute.LinkId}; }}
		}}");

	if (attribute.ContentId != attribute.RelatedContentId)
	{
		sb.AppendLine($@"
		public int Id 
		{{
			get {{ return {attribute.M2MReverseRelatedPropertyName}Id; }}
			set {{ {attribute.M2MReverseRelatedPropertyName}Id = value; }}
		}}
        public int LinkedItemId 
		{{ 
			get {{ return {attribute.M2MReversePropertyName}Id; }}
			set {{ {attribute.M2MReversePropertyName}Id = value; }}
		}}
		public IQPArticle Item {{  get {{ return {attribute.M2MReverseRelatedPropertyName}; }} }}		
		public IQPArticle LinkedItem {{  get {{ return {attribute.M2MReversePropertyName}; }} }}");
		}
		else
		{
			sb.AppendLine($@"
		public int Id 
		{{
			get {{ return {attribute.M2MReverseRelatedPropertyName}Id; }} 
			set {{ {attribute.M2MReverseRelatedPropertyName}Id = value; }} 
		}}
		public int LinkedItemId 
		{{
			get {{ return {attribute.M2MReversePropertyName}Id; }} 
			set {{ {attribute.M2MReversePropertyName}Id = value; }} 
		}}
		public IQPArticle Item {{  get {{ return {attribute.M2MReverseRelatedPropertyName}; }} }}		
		public IQPArticle LinkedItem {{  get {{ return {attribute.M2MReversePropertyName}; }} }}");
		}

		sb.AppendLine("}");
	}
}