// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Tests
{
    public partial class MtMItemForUpdate: IQPArticle
    {
        public MtMItemForUpdate()
        {
		    Reference = new HashSet<MtMItemForUpdate2MtMDictionaryForUpdateForReference>();
        }

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }

		private String _internalTitle;
		public virtual String Title 
		{ 
			get { return _internalTitle; }
			set { _internalTitle = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<MtMItemForUpdate2MtMDictionaryForUpdateForReference> Reference { get; set; }
	}
}
	
