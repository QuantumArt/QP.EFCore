using Quantumart.QP8.EFCore.Services;
using NUnit.Framework;

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
