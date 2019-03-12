// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Quantumart.QP8.EFCore.Models;
namespace EntityFrameworkCore.Data
{
    public partial class Product2RegionForRegions: IQPLink
    {
		public Product ProductItem;		
		public Region RegionLinkedItem;

		public int ProductItem_ID { get; set; }	
		public int RegionLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 21; }
		}

		public int Id { get { return ProductItem_ID; } }
        public int LinkedItemId { get { return RegionLinkedItem_ID; } }
	}

	public partial class Product2RegionForBackwardForRegions: IQPLink
    {
		public Product RegionItem;		
		public Region ProductLinkedItem;

		public int RegionItem_ID { get; set; }	
		public int ProductLinkedItem_ID { get; set; }

		public int LinkId
		{
			get { return 21; }
		}

                    
		public int Id { get { return RegionItem_ID; } }
        public int LinkedItemId { get { return ProductLinkedItem_ID; } }

	}

}
	
	
