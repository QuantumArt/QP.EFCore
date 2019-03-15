// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Tests
{
    public partial class ToSymmetricRelationAtricle: IQPArticle
    {
        public ToSymmetricRelationAtricle()
        {
		    ToSymmetricRelation = new HashSet<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>();
			BackwardForSymmetricRelation = new HashSet<SymmetricRelationArticle2ToSymmetricRelationAtricleForBackwardForSymmetricRelation>();
        }

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public  ICollection<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation> ToSymmetricRelation { get; set; }
		/// <summary>
		/// Auto-generated backing property for 38259/SymmetricRelation
		/// </summary>
		public  ICollection<SymmetricRelationArticle2ToSymmetricRelationAtricleForBackwardForSymmetricRelation> BackwardForSymmetricRelation { get; set; }
	}
}
	
