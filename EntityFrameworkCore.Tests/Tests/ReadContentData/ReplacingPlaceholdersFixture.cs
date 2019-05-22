using System.Linq;
using NUnit.Framework;
using EntityFrameworkCore.Tests.Infrastructure;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using Quantumart.QP8.CoreCodeGeneration.Services;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Tests.ReadContentData
{
    [TestFixture]
    class ReplacingPlaceholdersFixture : DataContextFixtureBase
    {
        private static Regex URL_PLACEHOLDER = new Regex(@"<%=upload_url%>|<%=site_url%>");

        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_Replacing_Placeholder_IF_True([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                bool ReplaceUrls = GetValueReplaceUrl(context, mapping);
                if (ReplaceUrls)
                {
                    var item = context.ReplacingPlaceholdersItems.FirstOrDefault();
                    Match match = URL_PLACEHOLDER.Match(item.Title);
                    Assert.That(match.Length, Is.EqualTo(0));
                }
            }
        }

        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_Replacing_Placeholder_IF_False([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                bool ReplaceUrls = GetValueReplaceUrl(context, mapping);
                if (!ReplaceUrls)
                {
                    var item = context.ReplacingPlaceholdersItems.FirstOrDefault();
                    Match match = URL_PLACEHOLDER.Match(item.Title);
                    Assert.That(match.Length, Is.Not.EqualTo(0));
                }
            }
        }

        private bool GetValueReplaceUrl(EFCoreModel context, Mapping mapping)
        {
            if (new[] { Mapping.DatabaseDynamicMapping, Mapping.FileDynamicMapping }.Contains(mapping))
            {
                var model = GetModel();
                return model.Schema.ReplaceUrls;
            }
            else
            {
                DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
                cmd.CommandText = "SELECT TOP 1 REPLACE_URLS FROM SITE WHERE SITE_ID = @SiteId";
                cmd.Parameters.Add(new SqlParameter("SiteId", context.SiteId));
                return (bool)cmd.ExecuteScalar();

            }
        }

        private ModelReader GetModel()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"DynamicMappingResult.xml");
            return new ModelReader(path, _ => { }, true);
        }
    }
}
