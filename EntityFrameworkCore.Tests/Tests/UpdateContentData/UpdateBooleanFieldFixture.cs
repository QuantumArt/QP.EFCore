using EntityFrameworkCore.Tests.Infrastructure;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.UpdateContentData
{
    [TestFixture]
    class UpdateBooleanFieldFixture : DataContextUpdateFixtureBase
    {
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_Boolean_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.Boolean = null, a => a.Boolean);
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.Boolean = true, a => a.Boolean);
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.Boolean = false, a => a.Boolean);            
        }
    }
}
