// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace EntityFrameworkCore.Templates
{
    public partial class MobileTariff: IQPArticle
    {
        public MobileTariff()
        {
        }

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }

        public virtual Int32? SplitInternetDeviceCount { get; set; }
		/// <summary>
		/// 
		/// </summary>			
		public virtual Product Product { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? Product_ID { get; set; }
		#region Generated Content properties
        // public Int32 SplitInternetDeviceCountExact { get { return this.SplitInternetDeviceCount == null ? default(Int32) : this.SplitInternetDeviceCount.Value; } }
		#endregion
	}
}
	
