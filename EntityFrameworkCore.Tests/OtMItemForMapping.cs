// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Tests
{
    public partial class OtMItemForMapping: IQPArticle
    {
        public OtMItemForMapping()
        {
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
		public virtual OtMRelatedItemWithMapping OtMReferenceMapping { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? OtMReferenceMapping_ID { get; set; }
	}
}
	
