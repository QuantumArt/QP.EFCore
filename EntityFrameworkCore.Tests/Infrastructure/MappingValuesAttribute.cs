using NUnit.Framework;

namespace EntityFrameworkCore.Tests.Infrastructure
{
    public class MappingValuesAttribute : ValuesAttribute
    {
        public MappingValuesAttribute()
            : base(
                Mapping.StaticMapping,
                Mapping.FileDefaultMapping,
                Mapping.FileDynamicMapping,
                Mapping.DatabaseDefaultMapping,
                Mapping.DatabaseDynamicMapping)
        {
        }
    }
}
