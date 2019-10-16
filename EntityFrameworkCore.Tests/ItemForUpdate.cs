// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Tests
{
    public partial class ItemForUpdate: IQPArticle
    {
        public ItemForUpdate()
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

		private String _internalTitle;
		public virtual String Title 
		{ 
			get { return _internalTitle; }
			set { _internalTitle = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
	}
} 	
