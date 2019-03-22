// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Tests
{
    public partial class StringItemForUpdate: IQPArticle
    {
        public StringItemForUpdate()
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

		private String _StringValue;
		public virtual String StringValue 
		{ 
			get { return _StringValue; }
			set { _StringValue = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
	}
}
	