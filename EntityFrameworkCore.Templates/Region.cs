// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Templates
{
    public partial class Region: IQPArticle
    {
        public Region()
        {
		    Children = new HashSet<Region>();
		    AllowedRegions = new HashSet<Region2RegionForAllowedRegions>();
		    DeniedRegions = new HashSet<Region2RegionForDeniedRegions>();
			BackwardForRegions = new HashSet<Product2RegionForBackwardForRegions>();
			BackwardForAllowedRegions = new HashSet<Region2RegionForBackwardForAllowedRegions>();
			BackwardForDeniedRegions = new HashSet<Region2RegionForBackwardForDeniedRegions>();
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
        public virtual Int32? OldSiteId { get; set; }
		/// <summary>
		/// 
		/// </summary>			
		public virtual Region Parent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? Parent_ID { get; set; }
		/// <summary>
		/// Auto-generated backing property for field (id: 1138)/Parent Children
		/// </summary>
		public  ICollection<Region> Children { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Region2RegionForAllowedRegions> AllowedRegions { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Region2RegionForDeniedRegions> DeniedRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1228/Regions
		/// </summary>
		public  ICollection<Product2RegionForBackwardForRegions> BackwardForRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1659/AllowedRegions
		/// </summary>
		public  ICollection<Region2RegionForBackwardForAllowedRegions> BackwardForAllowedRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1660/DeniedRegions
		/// </summary>
		public  ICollection<Region2RegionForBackwardForDeniedRegions> BackwardForDeniedRegions { get; set; }
		#region Generated Content properties
        // public Int32 OldSiteIdExact { get { return this.OldSiteId == null ? default(Int32) : this.OldSiteId.Value; } }
		#endregion
	}
}
	
