// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Data
{
    public partial class Region2RegionForDeniedRegions: IQPLink
    {
		public Region RegionItem { get; set; }		
		public Region RegionLinkedItem { get; set; }

		public int RegionItemId { get; set; }	
		public int RegionLinkedItemId { get; set; }

		public int LinkId
		{
			get { return 72; }
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

	public partial class Region2RegionForBackwardForDeniedRegions_Region : IQPLink
    {
		public Region RegionLinkedItem { get; set; }		
		public Region RegionItem { get; set; }

		public int RegionLinkedItemId { get; set; }	
		public int RegionItemId { get; set; }

		public int LinkId
		{
			get { return 72; }
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
	
	
