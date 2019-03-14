// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EFCore.Models;
namespace EntityFrameworkCore.Tests
{
    public partial class OtMItemForUpdate: IQPArticle
    {
        public OtMItemForUpdate()
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

		private String _Title;
		public virtual String Title 
		{ 
			get { return _Title; }
			set { _Title = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		/// <summary>
		/// 
		/// </summary>			
		public virtual OtMDictionaryForUpdate Reference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? Reference_ID { get; set; }
	}
}
	
