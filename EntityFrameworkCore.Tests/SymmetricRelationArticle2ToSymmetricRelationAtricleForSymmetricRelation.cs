// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EFCore.Models;
namespace EntityFrameworkCore.Tests
{
    public partial class SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation: IQPLink
    {
		public SymmetricRelationArticle SymmetricRelationArticleItem { get; set; }		
		public ToSymmetricRelationAtricle ToSymmetricRelationAtricleLinkedItem { get; set; }

		public int SymmetricRelationArticleItem_ID { get; set; }	
		public int ToSymmetricRelationAtricleLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 100; }
		}

		public int Id { get { return SymmetricRelationArticleItem_ID; } }
        public int LinkedItemId { get { return ToSymmetricRelationAtricleLinkedItem_ID; } }
	}

	public partial class SymmetricRelationArticle2ToSymmetricRelationAtricleForBackwardForSymmetricRelation: IQPLink
    {
		public SymmetricRelationArticle ToSymmetricRelationAtricleItem { get; set; }		
		public ToSymmetricRelationAtricle SymmetricRelationArticleLinkedItem { get; set; }

		public int ToSymmetricRelationAtricleItem_ID { get; set; }	
		public int SymmetricRelationArticleLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 100; }
		}

                    
		public int Id { get { return ToSymmetricRelationAtricleItem_ID; } }
        public int LinkedItemId { get { return SymmetricRelationArticleLinkedItem_ID; } }

	}

}
	
