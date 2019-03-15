// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Tests
{
    public partial class ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation: IQPLink
    {
		public ToSymmetricRelationAtricle ToSymmetricRelationAtricleItem { get; set; }		
		public SymmetricRelationArticle SymmetricRelationArticleLinkedItem { get; set; }

		public int ToSymmetricRelationAtricleItem_ID { get; set; }	
		public int SymmetricRelationArticleLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 101; }
		}

		public int Id { get { return ToSymmetricRelationAtricleItem_ID; } }
        public int LinkedItemId { get { return SymmetricRelationArticleLinkedItem_ID; } }
	}

	public partial class ToSymmetricRelationAtricle2SymmetricRelationArticleForBackwardForToSymmetricRelation: IQPLink
    {
		public ToSymmetricRelationAtricle SymmetricRelationArticleItem { get; set; }		
		public SymmetricRelationArticle ToSymmetricRelationAtricleLinkedItem { get; set; }

		public int SymmetricRelationArticleItem_ID { get; set; }	
		public int ToSymmetricRelationAtricleLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 101; }
		}

                    
		public int Id { get { return SymmetricRelationArticleItem_ID; } }
        public int LinkedItemId { get { return ToSymmetricRelationAtricleLinkedItem_ID; } }

	}

}
	
