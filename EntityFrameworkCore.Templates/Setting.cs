// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Templates
{
    public partial class Setting: IQPArticle
    {
        public Setting()
        {
		    RelatedSettings = new HashSet<Setting2SettingForRelatedSettings>();
			BackwardForRelatedSettings = new HashSet<Setting2SettingForBackwardForRelatedSettings>();
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
		private String _internalValueMapped;
		public virtual String ValueMapped 
		{ 
			get { return _internalValueMapped; }
			set { _internalValueMapped = EFCoreModel.Current.ReplacePlaceholders(value);}
		}
        public virtual Decimal? DecimalValue { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Setting2SettingForRelatedSettings> RelatedSettings { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1657/RelatedSettings
		/// </summary>
		public  ICollection<Setting2SettingForBackwardForRelatedSettings> BackwardForRelatedSettings { get; set; }
	}
} 