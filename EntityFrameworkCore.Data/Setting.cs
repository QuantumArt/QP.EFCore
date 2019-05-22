// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Data
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

		private String _Title;
		public virtual String Title 
		{ 
			get { return EFCoreModel.Current.ReplacePlaceholders(_Title); }
			set { _Title = value;}
		}
		private String _ValueMapped;
		public virtual String ValueMapped 
		{ 
			get { return EFCoreModel.Current.ReplacePlaceholders(_ValueMapped); }
			set { _ValueMapped = value;}
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
