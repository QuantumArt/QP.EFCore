// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Data
{
    public partial class Setting2SettingForRelatedSettings: IQPLink
    {
		public Setting SettingItem { get; set; }		
		public Setting SettingLinkedItem { get; set; }

		public int SettingItemId { get; set; }	
		public int SettingLinkedItemId { get; set; }

		public int LinkId
		{
			get { return 69; }
		}

		public int Id 
		{ 
			get { return SettingItemId; } 
			set { SettingItemId = value; } 
		}
        public int LinkedItemId 
		{ 
			get { return SettingLinkedItemId; }
			set { SettingLinkedItemId = value; }
		}
		public IQPArticle Item { get { return SettingItem; } }		
		public IQPArticle LinkedItem { get { return SettingLinkedItem; } }
	}

	public partial class Setting2SettingForBackwardForRelatedSettings: IQPLink
    {
		public Setting SettingLinkedItem { get; set; }		
		public Setting SettingItem { get; set; }

		public int SettingLinkedItemId { get; set; }	
		public int SettingItemId { get; set; }

		public int LinkId
		{
			get { return 69; }
		}

		public int Id 
		{ 
			get { return SettingItemId; } 
			set { SettingItemId = value; } 
		}
		public int LinkedItemId 
		{ 
			get { return SettingLinkedItemId; } 
			set { SettingLinkedItemId = value; } 
		}
		public IQPArticle Item { get { return SettingItem; } }		
		public IQPArticle LinkedItem { get { return SettingLinkedItem; } }

	}

}
