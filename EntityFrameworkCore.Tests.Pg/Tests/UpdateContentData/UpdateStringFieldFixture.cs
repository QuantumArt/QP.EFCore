using System;
using EntityFrameworkCore.Tests.Pg.Infrastructure;
using NUnit.Framework;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.UpdateContentData;

[TestFixture]
public class UpdateStringFieldFixture : DataContextUpdateFixtureBase
{
    [Test, Combinatorial]
    [Category("UpdateContentData")]
    public void Check_That_String_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        UpdateProperty<StringItemForUpdate>(access, mapping, a => a.StringValue = Guid.NewGuid().ToString(), a => a.StringValue);
    }
}
