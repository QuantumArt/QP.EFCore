// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Templates
{
    public partial class Region: IQPArticle
    {
        public Region()
        {
		    Children = new HashSet<Region>();
		    AllowedRegions = new HashSet<Region2RegionForAllowedRegions>();
		    DeniedRegions = new HashSet<Region2RegionForDeniedRegions>();
			BackwardForRegions = new HashSet<Region2ProductForBackwardForRegions>();
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

		private String _internalTitle;
		public virtual String Title 
		{ 
			get { return _internalTitle; }
			set { _internalTitle = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
		private String _internalAlias;
		public virtual String Alias 
		{ 
			get { return _internalAlias; }
			set { _internalAlias = EFCoreModel.Current.ReplacePlaceholders(value);}
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
		public  ICollection<Region2ProductForBackwardForRegions> BackwardForRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1659/AllowedRegions
		/// </summary>
		public  ICollection<Region2RegionForBackwardForAllowedRegions> BackwardForAllowedRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1660/DeniedRegions
		/// </summary>
		public  ICollection<Region2RegionForBackwardForDeniedRegions> BackwardForDeniedRegions { get; set; }
	}
} 	
