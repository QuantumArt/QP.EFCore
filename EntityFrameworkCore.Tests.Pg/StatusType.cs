using System;

namespace EntityFrameworkCore.Tests.Pg
{
    public partial class StatusType
    {
        public Int32 Id { get; set; }
        public string StatusTypeName { get; set; }
        public int Weight { get; set; }
        public Int32 SiteId { get; set; }
    }
}
