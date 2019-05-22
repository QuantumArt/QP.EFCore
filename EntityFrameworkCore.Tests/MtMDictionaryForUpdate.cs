// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Tests
{
    public partial class MtMDictionaryForUpdate: IQPArticle
    {
        public MtMDictionaryForUpdate()
        {
			BackwardForReference = new HashSet<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>();
        }

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }

		private String _Title;
		public virtual String Title 
		{ 
			get { return EFCoreModel.Current.ReplacePlaceholders(_Title); }
			set { _Title = value;}
		}
		/// <summary>
		/// Auto-generated backing property for 39284/Reference
		/// </summary>
		public  ICollection<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference> BackwardForReference { get; set; }
	}
}
	
