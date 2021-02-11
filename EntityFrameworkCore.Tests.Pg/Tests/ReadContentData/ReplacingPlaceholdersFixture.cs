using System.Linq;
using NUnit.Framework;
using EntityFrameworkCore.Tests.Pg.Infrastructure;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Quantumart.QP8.EntityFrameworkCore.Generator.EmbeddedModels;
using Quantumart.QPublishing.Database;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace EntityFrameworkCore.Tests.Pg.ReadContentData
{
    [TestFixture]
    class ReplacingPlaceholdersFixture : DataContextFixtureBase
    {
        private static Regex URL_PLACEHOLDER = new Regex(@"<%=upload_url%>|<%=site_url%>");

        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_Replacing_Placeholder_IF_True([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
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
            using (var connection = new NpgsqlConnection(EFCoreModel.DefaultConnectionString))
            using (var context = GetDataContext(access, mapping, connection))
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
                cmd.CommandText = $"SELECT {SqlQuerySyntaxHelper.Top(context.Cnn.DatabaseType, "1")} REPLACE_URLS FROM SITE WHERE SITE_ID = @SiteId";
                DbParameter parameter;
                if (context.Cnn.DatabaseType == QP.ConfigurationService.Models.DatabaseType.SqlServer)
                {
                    parameter = new SqlParameter("SiteId", context.SiteId);
                }
                else
                {
                    parameter = new NpgsqlParameter("SiteId", context.SiteId);
                }
                cmd.Parameters.Add(parameter);
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
