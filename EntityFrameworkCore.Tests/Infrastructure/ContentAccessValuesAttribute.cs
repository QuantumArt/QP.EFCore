using NUnit.Framework;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Infrastructure
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
