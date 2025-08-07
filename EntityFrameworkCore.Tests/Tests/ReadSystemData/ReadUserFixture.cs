using System.Linq;
using EntityFrameworkCore.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.ReadSystemData;

[TestFixture]
public class ReadUserFixture : DataContextFixtureBase
{
    [Test, Combinatorial]
    [Category("ReadSystemData")]
    public void DataContext_Users_Read([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        using (var context = GetDataContext(access, mapping))
        {
            var users = context.Users
                .Include(u => u.UserGroupBinds)
                    .ThenInclude(ug =>ug.UserGroup)
                .ToArray();
            Assert.That(users, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test, Combinatorial]
    [Category("ReadSystemData")]
    public void DataContext_UserGroups_Read([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        using (var context = GetDataContext(access, mapping))
        {
            var us = context.Users.Include(u => u.UserGroupBinds).FirstOrDefault(f => f.Id == 0);

            var groups = context.UserGroups
                .Include(u => u.UserGroupBinds)
                    .ThenInclude(ug => ug.User)
                .ToArray();
            Assert.That(groups, Is.Not.Null.And.Not.Empty);
        }
    }

    [Test, Combinatorial]
    [Category("ReadSystemData")]
    public void DataContext_StatusTypes_Read([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
    {
        using (var context = GetDataContext(access, mapping))
        {
            var statusTypes = context.StatusTypes.ToArray();
            Assert.That(statusTypes, Is.Not.Null.And.Not.Empty);
        }
    }

}
