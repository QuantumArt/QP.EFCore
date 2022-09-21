using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class DatabaseSchemaProvider
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Common;
using Quantumart.QPublishing.Database;
using System.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace {ns}
{{
    public class DatabaseSchemaProvider : ISchemaProvider
    {{
        #region Queries
        private const string ContentQuery = @""
            select
	            c.CONTENT_ID,
	            c.NET_CONTENT_NAME,
	            c.USE_DEFAULT_FILTRATION,
                c.virtual_type
            from
	            CONTENT c
            where
	            c.SITE_ID = @siteId"";

        private const string AttributeQuery = @""
            select
	            a.ATTRIBUTE_ID,
	            a.CONTENT_ID,
	            c.NET_CONTENT_NAME,
                a.ATTRIBUTE_NAME,
	            a.NET_ATTRIBUTE_NAME,
	            a.link_id,
                t.TYPE_NAME,
				mtm.r_content_id
            from
	            CONTENT_ATTRIBUTE a
	            join CONTENT c on a.CONTENT_ID = c.CONTENT_ID
                join ATTRIBUTE_TYPE t on a.ATTRIBUTE_TYPE_ID = t.ATTRIBUTE_TYPE_ID
				LEFT JOIN CONTENT_TO_CONTENT mtm ON a.LINK_ID = mtm.LINK_ID AND a.CONTENT_ID = mtm.l_content_id
            where
	            c.SITE_ID = @siteId"";
        #endregion

        private readonly string _siteName;
        private readonly DbConnection _connection;

        public DatabaseSchemaProvider(string siteName, DbConnection connection)
        {{
            _siteName = siteName;
            _connection = connection;
        }}

        #region ISchemaProvider implementation
        public ModelReader GetSchema()
        {{
            var connector = GetDBConnector(_connection);
            int siteId = connector.GetSiteId(_siteName);
            bool replaceUrls;

            using (var cmd = connector.CreateDbCommand($""SELECT {{SqlQuerySyntaxHelper.Top(connector.DatabaseType, ""1"")}} REPLACE_URLS FROM SITE WHERE SITE_ID = @siteId""))
            {{
                cmd.Parameters.AddWithValue(""@siteId"", siteId);
                replaceUrls = (bool)connector.GetRealScalarData(cmd);
            }}

            var attributes = GetAttributes(connector, siteId);
            var contents = GetContents(connector, siteId, attributes);
            attributes = AddM2MMappings(attributes, contents);

            var model = new ModelReader();

            model.Schema.DBType =  Enum.Parse<Quantumart.QP8.EntityFrameworkCore.Generator.Models.DatabaseType>(connector.DatabaseType.ToString());
            model.Schema.ReplaceUrls = replaceUrls;
            model.Schema.SiteName = _siteName;
            model.Attributes.AddRange(attributes);
            model.Contents.AddRange(contents);

            return model;
        }}

        public object GetCacheKey()
        {{
            return new {{ _siteName, _connection.ConnectionString }};
        }}
        #endregion

        #region Private methods
        private DBConnector GetDBConnector(DbConnection connection)
        {{
            return new DBConnector(
                connection,
                new DbConnectorSettings(),
                new MemoryCache(new MemoryCacheOptions()),
                new HttpContextAccessor {{ HttpContext = new DefaultHttpContext() }}
                );
        }}

        private ContentInfo[] GetContents(DBConnector connector, int siteId, AttributeInfo[] attributes)
        {{
            var command = connector.CreateDbCommand(ContentQuery);
            command.Parameters.AddWithValue(""@siteId"", siteId);

            var attributesLookup = attributes.ToLookup(a => a.ContentId, a => a);

            var contents = connector
                .GetRealData(command)
                .AsEnumerable()
                .Select(row => {{
                    var contentId = (int)row.Field<decimal>(""CONTENT_ID"");
                    var mappedName = row.Field<string>(""NET_CONTENT_NAME"");
                    var useDefaultFiltration = row.Field<bool>(""USE_DEFAULT_FILTRATION"");
                    var IsVirtual = row.Field<decimal>(""virtual_type"") != 0;

                    var content = new ContentInfo
                    {{
                        Id = contentId,
                        MappedName = mappedName,
                        UseDefaultFiltration = useDefaultFiltration,
                        Attributes = new List<AttributeInfo>(attributesLookup[contentId]),
                        IsVirtual = IsVirtual
                    }};

                    content.Attributes.ForEach(a => a.Content = content);

                    return content;
                }})
                .ToArray();

            return contents;
        }}

        private AttributeInfo[] GetAttributes(DBConnector connector, int siteId)
        {{
            var command = connector.CreateDbCommand(AttributeQuery);
            command.Parameters.AddWithValue(""@siteId"", siteId);

            var attributes = connector
                .GetRealData(command)
                .AsEnumerable()
                .Select(row => new AttributeInfo
                {{
                    Id = (int)row.Field<decimal>(""ATTRIBUTE_ID""),
                    ContentId = (int)row.Field<decimal>(""CONTENT_ID""),
                    Name = row.Field<string>(""ATTRIBUTE_NAME""),
                    MappedName = row.Field<string>(""NET_ATTRIBUTE_NAME""),
                    LinkId = (int)(row.Field<decimal?>(""LINK_ID"") ?? 0),
                    Type = row.Field<string>(""TYPE_NAME""),
                    RelatedContentId = (int)(row.Field<decimal?>(""r_content_id"") ?? 0)
                }})
                .ToArray();

            foreach (var a in attributes)
            {{
                a.Type = GetType(a);
            }}

            return AddO2mMappings(attributes);
        }}


        private AttributeInfo[] AddO2mMappings(AttributeInfo[] attributes)
        {{
            var attributesList = new List<AttributeInfo>(attributes);
            foreach (var item in attributes.Where(w => w.IsO2M))
            {{
                attributesList.Add(
                    new AttributeInfo()
                    {{
                        Id = item.Id,
                        ContentId = item.ContentId,
                        Name = item.MappedName,
                        MappedName = item.MappedName + ""_ID"",
                        LinkId = item.LinkId,
                        Type = ""Numeric""
                    }});
            }}
            return attributesList.ToArray();
        }}

        private AttributeInfo[] AddM2MMappings(AttributeInfo[] attributes, ContentInfo[] contents)
        {{
            var attributesList = new List<AttributeInfo>(attributes);

            foreach (var item in attributes.Where(w => w.IsM2M))
            {{
                var contentFrom = contents.FirstOrDefault(x => x.Id == item.ContentId);

                if (contentFrom == null)
                {{
                    continue;
                }}
                var contentTo = contents.FirstOrDefault(x => x.Id == item.RelatedContentId);

                if (contentTo == null)
                {{
                    continue;
                }}
                var attributeFrom = attributes.FirstOrDefault(x => x.LinkId == item.LinkId && item.ContentId == x.ContentId);
                var attributeTo = attributes.FirstOrDefault(x => x.LinkId == item.LinkId && item.RelatedContentId == x.ContentId && (attributeFrom == null || attributeFrom.Id != x.Id));


                if (attributeFrom == null)
                {{
                    attributeFrom = GenM2M(contentTo, contentFrom, attributeTo, attributes.Max(x => x.Id) + 1);
                    attributesList.Add(attributeFrom);
                    contentFrom.Attributes.Add(attributeFrom);
                }}

                if (attributeTo == null)
                {{
                    attributeTo = GenM2M(contentFrom, contentTo, attributeFrom, attributes.Max(x => x.Id) + 1);
                    attributesList.Add(attributeTo);
                    contentTo.Attributes.Add(attributeTo);
                }}

            }}
            return attributesList.ToArray();
        }}
        private AttributeInfo GenM2M(ContentInfo contentFrom, ContentInfo contentTo, AttributeInfo attr, int id)
        {{
            var name = string.IsNullOrEmpty(attr.MappedBackName) ?
                string.Format(""BackwardFor{{0}}_{{1}}"", attr.MappedName, contentFrom.MappedName)
                : attr.MappedBackName;

            var mappedName = name;

            return new AttributeInfo
            {{
                Id = id,
                Name = name,
                Type = ""M2M"",
                MappedName = mappedName,
                Link = attr.Link,
                LinkId = attr.LinkId,
                ContentId = contentTo.Id,
                Description = string.Format(""Auto-generated backing property for {{0}}/{{1}}"", attr.Id, attr.Name, attr.MappedBackName),
                Content = contentTo,
                RelatedContent = contentFrom,
                RelatedContentId = contentFrom.Id
            }};

        }}

        private string GetType(AttributeInfo attribute)
        {{
            if (attribute.Type == ""Relation"")
            {{
                if (attribute.LinkId == 0)
                {{
                    return ""O2M"";
                }}
                else
                {{
                    return ""M2M"";
                }}
            }}
            else if (attribute.Type == ""Relation Many-to-One"")
            {{
                return ""M2O"";
            }}

            return attribute.Type;
        }}

        #endregion
    }}
}}
";
        }
    }
}