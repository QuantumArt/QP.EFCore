// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EFCore.Models;
namespace EntityFrameworkCore.Templates
{
    public partial class Setting2SettingForRelatedSettings: IQPLink
    {
		public Setting SettingItem { get; set; }		
		public Setting SettingLinkedItem { get; set; }

		public int SettingItem_ID { get; set; }	
		public int SettingLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 69; }
		}

		public int Id { get { return SettingItem_ID; } }
        public int LinkedItemId { get { return SettingLinkedItem_ID; } }
	}

	public partial class Setting2SettingForBackwardForRelatedSettings: IQPLink
    {
		public Setting SettingItem { get; set; }		
		public Setting SettingLinkedItem { get; set; }

		public int SettingItem_ID { get; set; }	
		public int SettingLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 69; }
		}

	   public int Id { get { return SettingLinkedItem_ID; } }
       public int LinkedItemId { get { return SettingItem_ID; } }

	}

}
