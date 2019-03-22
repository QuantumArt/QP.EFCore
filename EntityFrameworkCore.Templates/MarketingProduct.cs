// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Templates
{
    public partial class MarketingProduct: IQPArticle
    {
        public MarketingProduct()
        {
		    Products = new HashSet<Product>();
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
		private String _Alias;
		public virtual String Alias 
		{ 
			get { return _Alias; }
			set { _Alias = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
        public virtual Int32? ProductType { get; set; }
		private String _Benefit;
		public virtual String Benefit 
		{ 
			get { return _Benefit; }
			set { _Benefit = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _ShortBenefit;
		public virtual String ShortBenefit 
		{ 
			get { return _ShortBenefit; }
			set { _ShortBenefit = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _Legal;
		public virtual String Legal 
		{ 
			get { return _Legal; }
			set { _Legal = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _Description;
		public virtual String Description 
		{ 
			get { return _Description; }
			set { _Description = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _ShortDescription;
		public virtual String ShortDescription 
		{ 
			get { return _ShortDescription; }
			set { _ShortDescription = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _Purpose;
		public virtual String Purpose 
		{ 
			get { return _Purpose; }
			set { _Purpose = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
        public virtual Int32? Family_ID { get; set; }
		private String _TitleForFamily;
		public virtual String TitleForFamily 
		{ 
			get { return _TitleForFamily; }
			set { _TitleForFamily = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _CommentForFamily;
		public virtual String CommentForFamily 
		{ 
			get { return _CommentForFamily; }
			set { _CommentForFamily = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
        public virtual Int32? MarketingSign_ID { get; set; }
        public virtual Int32? OldSiteId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Product> Products { get; set; }
	}
}
	
