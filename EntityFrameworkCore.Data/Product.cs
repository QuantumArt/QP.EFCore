// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Data
{
    public partial class Product: IQPArticle
    {
        public Product()
        {
		    Parameters = new HashSet<ProductParameter>();
		    MobileTariffs = new HashSet<MobileTariff>();
		    Regions = new HashSet<Product2RegionForRegions>();
        }

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }

        public virtual Int32? Type { get; set; }
        public virtual String PDF { get; set; }
		private String _Legal;
		public virtual String Legal 
		{ 
			get { return _Legal; }
			set { _Legal = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _Benefit;
		public virtual String Benefit 
		{ 
			get { return _Benefit; }
			set { _Benefit = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
        public virtual Int32? SortOrder { get; set; }
        public virtual Int32? MarketingSign_ID { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
		private String _ArchiveTitle;
		public virtual String ArchiveTitle 
		{ 
			get { return _ArchiveTitle; }
			set { _ArchiveTitle = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _ArchiveNotes;
		public virtual String ArchiveNotes 
		{ 
			get { return _ArchiveNotes; }
			set { _ArchiveNotes = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
        public virtual Int32? OldSiteId { get; set; }
		/// <summary>
		/// 
		/// </summary>			
		public virtual MarketingProduct MarketingProduct { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? MarketingProduct_ID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<ProductParameter> Parameters { get; set; }
		/// <summary>
		/// Auto-generated backing property for field (id: 1192)/Product MobileTariffs
		/// </summary>
		public  ICollection<MobileTariff> MobileTariffs { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Product2RegionForRegions> Regions { get; set; }
	}
}
	
