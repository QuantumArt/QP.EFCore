// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EntityFrameworkCore;
namespace EntityFrameworkCore.Templates
{
    public partial class Region2RegionForAllowedRegions: IQPLink
    {
		public Region RegionItem { get; set; }		
		public Region RegionLinkedItem { get; set; }

		public int RegionItemId { get; set; }	
		public int RegionLinkedItemId { get; set; }

		public int LinkId
		{
			get { return 71; }
		}

		public int Id 
		{ 
			get { return RegionItemId; } 
			set { RegionItemId = value; } 
		}
        public int LinkedItemId 
		{ 
			get { return RegionLinkedItemId; }
			set { RegionLinkedItemId = value; }
		}
		public IQPArticle Item { get { return RegionItem; } }		
		public IQPArticle LinkedItem { get { return RegionLinkedItem; } }
	}

	public partial class Region2RegionForBackwardForAllowedRegions: IQPLink
    {
		public Region RegionLinkedItem { get; set; }		
		public Region RegionItem { get; set; }

		public int RegionLinkedItemId { get; set; }	
		public int RegionItemId { get; set; }

		public int LinkId
		{
			get { return 71; }
		}

		public int Id 
		{ 
			get { return RegionItemId; } 
			set { RegionItemId = value; } 
		}
		public int LinkedItemId 
		{ 
			get { return RegionLinkedItemId; } 
			set { RegionLinkedItemId = value; } 
		}
		public IQPArticle Item { get { return RegionItem; } }		
		public IQPArticle LinkedItem { get { return RegionLinkedItem; } }

	}

}
