using NUnit.Framework;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.Infrastructure
{
    public class ContentAccessValuesAttribute : ValuesAttribute
    {
        public ContentAccessValuesAttribute()
            : base(
                ContentAccess.Live,
                ContentAccess.Stage,
                ContentAccess.StageNoDefaultFiltration)
        {
        }
    }
}
