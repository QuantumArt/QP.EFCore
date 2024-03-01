using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
    public static class ModelDbContextExtensions
    {
        internal static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Common;
{(context.IsPostgres 
                ? "using Npgsql;" 
                : "using System.Data.SqlClient;")}
using Quantumart.QPublishing.Database;
using System.Linq.Expressions;
using System.Collections.Generic;
using Quantumart.QPublishing.Info;
using System.Collections;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using System.Transactions;
using System.Threading.Tasks;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;
{context.Settings.Usings}

namespace {ns}
{{
    public partial class {context.Model.Schema.ClassName}: IQPLibraryService, IQPFormService, IQPSchema
    {{
        #region Constructors

        public {context.Model.Schema.ClassName}(ModelReader schema) : base(DefaultConnectionOptions())
        {{
            MappingResolver = new MappingResolver(schema);
            OnContextCreated();
        }}

		public {context.Model.Schema.ClassName}(DbContextOptions<{context.Model.Schema.ClassName}> options, ModelReader schema) 
		: base(options)
        {{
            MappingResolver = new MappingResolver(schema);
            OnContextCreated();
        }}

        private IMappingResolver GetDefaultMappingResolver()
        {{
            var schema = new StaticSchemaProvider();
            return new MappingResolver(schema.GetSchema());
        }}

        #endregion

        #region Private members
        private const string uploadPlaceholder = ""<%=upload_url%>"";
        private const string sitePlaceholder = ""<%=site_url%>"";
        private static string _defaultSiteName = ""{context.Model.Schema.SiteName ?? "string.Empty"}"";
        private static string _defaultConnectionString;
        private static string _defaultConnectionStringName = ""{context.Model.Schema.ConnectionStringName}"";
        private bool _shouldRemoveSchema = false;
        private string _siteName;
        private DBConnector _cnn;
        #endregion

        #region Properties
        public static bool RemoveUploadUrlSchema = false;

        protected IMappingResolver MappingResolver {{ get; private set; }}

        public bool ShouldRemoveSchema {{ get {{ return _shouldRemoveSchema; }} set {{ _shouldRemoveSchema = value; }} }}
        public Int32 SiteId {{ get; private set; }}
		public string SiteUrl {{ get {{ return StageSiteUrl; }} }}
		public string UploadUrl => {(context.Model.Schema.UseLongUrls ? "LongUploadUrl" : "ShortUploadUrl")};
		public string LiveSiteUrl {{ get; private set; }}
		public string LiveSiteUrlRel {{ get; private set; }}
		public string StageSiteUrl {{ get; private set; }}
		public string StageSiteUrlRel {{ get; private set; }}
		public string LongUploadUrl {{ get; private set; }}
		public string ShortUploadUrl {{ get; private set; }}
		public Int32 PublishedId {{ get; private set; }}
		public string ConnectionString {{ get; private set; }}
		public static string DefaultSiteName 
		{{ 
			get {{ return _defaultSiteName; }}
			set {{ _defaultSiteName = value; }}
		}}
		public DBConnector Cnn
		{{
			get 
			{{
				if (_cnn == null) 
				{{
					_cnn = new DBConnector(Database.GetDbConnection());
					_cnn.UpdateManyToMany = false;
				}}
				return _cnn;
			}}
		}}
		public string SiteName 
		{{ 
			get {{ return _siteName; }} 
			set
			{{
				if (!String.Equals(_siteName, value, StringComparison.InvariantCultureIgnoreCase))
				{{
					_siteName = value;
					SiteId = Cnn.GetSiteId(_siteName);
					LoadSiteSpecificInfo();
				}}
			}}
		}}
		public static string DefaultConnectionString 
		{{ 
			get
			{{
				if (_defaultConnectionString == null)
				{{
					var configuration = new ConfigurationBuilder()
						.AddJsonFile(""appsettings.json"")
						.Build();
					var connectionString = configuration.GetConnectionString(_defaultConnectionStringName);
					if (string.IsNullOrWhiteSpace(connectionString))
						throw new ApplicationException(string.Format(""Connection string '{{0}}' is not specified"", _defaultConnectionStringName));
					_defaultConnectionString = connectionString;
				}}
				return _defaultConnectionString;
			}}
			set
			{{
				_defaultConnectionString = value;
			}}
		}}
		#endregion

		#region Factory methods
		public static {context.Model.Schema.ClassName} Create(DbConnection connection)
		{{
			var optionsBuilder = new DbContextOptionsBuilder<{context.Model.Schema.ClassName}>();
            {IncludeDbUse(context)}
            var ctx = new {context.Model.Schema.ClassName}(optionsBuilder.Options);
			ctx.SiteName = DefaultSiteName;
		    ctx.ConnectionString = connection.ConnectionString;
			return ctx;
		}}

		public static {context.Model.Schema.ClassName} Create(IMappingConfigurator configurator, DbConnection connection)
        {{
		    var mapping = configurator.GetMappingInfo();
            var optionsBuilder = new DbContextOptionsBuilder<{context.Model.Schema.ClassName}>();
            {IncludeDbUse(context)}
			optionsBuilder.UseModel(mapping.DbCompiledModel);
            {context.Model.Schema.ClassName} ctx = new {context.Model.Schema.ClassName}(optionsBuilder.Options, mapping.Schema);
            ctx.SiteName = mapping.Schema.Schema.SiteName;
            ctx.ConnectionString = connection.ConnectionString;
            return ctx;
        }}


        public static {context.Model.Schema.ClassName} Create(IMappingConfigurator configurator)
        {{
			var connection = {IncludeNewDbConnection(context.IsPostgres)};
            return Create(configurator, connection);
        }}

		public static {context.Model.Schema.ClassName} Create(string connection, string siteName) 
		{{
            {context.Model.Schema.ClassName} ctx;
			if(connection.IndexOf(""metadata"", StringComparison.InvariantCultureIgnoreCase) == -1)
			{{
				var optionsBuilder = new DbContextOptionsBuilder<{context.Model.Schema.ClassName}>();
                {IncludeDbUse(context)}
                ctx = new {context.Model.Schema.ClassName}(optionsBuilder.Options);
				ctx.SiteName = siteName;
				ctx.ConnectionString = connection;
				return ctx;
			}}
			else
			{{
				var optionsBuilder = new DbContextOptionsBuilder<{context.Model.Schema.ClassName}>();
                {IncludeDbUse(context)}
                ctx = new {context.Model.Schema.ClassName}(optionsBuilder.Options);
				ctx.SiteName = siteName;
				ctx.ConnectionString = connection;
				return ctx;
			}}
		}}


		public static {context.Model.Schema.ClassName} Create(string connection) 
		{{
			return Create(connection, DefaultSiteName);
		}}

		public static {context.Model.Schema.ClassName} Create() 
		{{
			return Create(DefaultConnectionString);
		}}

		public static {context.Model.Schema.ClassName} CreateWithStaticMapping(ContentAccess contentAccess)
        {{
            var connection = {IncludeNewDbConnection(context.IsPostgres)};
            return CreateWithStaticMapping(contentAccess, connection);
        }}

        public static {context.Model.Schema.ClassName} CreateWithStaticMapping(ContentAccess contentAccess, DbConnection connection)
        {{
			var schemaProvider = new StaticSchemaProvider();
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);
            return Create(configurator, connection);
        }}

		 public static {context.Model.Schema.ClassName} CreateWithDatabaseMapping(ContentAccess contentAccess)
        {{
            return CreateWithDatabaseMapping(contentAccess, DefaultSiteName);
        }}

        public static {context.Model.Schema.ClassName} CreateWithDatabaseMapping(ContentAccess contentAccess, string siteName)
        {{
            var connection = {IncludeNewDbConnection(context.IsPostgres)};
            return CreateWithDatabaseMapping(contentAccess, siteName, connection);
        }}

        public static {context.Model.Schema.ClassName} CreateWithDatabaseMapping(ContentAccess contentAccess, string siteName, DbConnection connection)
        {{
            var schemaProvider = new DatabaseSchemaProvider(siteName, connection);
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);         
            var context = Create(configurator, connection);
			context.SiteName = siteName;
			return context;
        }}

        public static {context.Model.Schema.ClassName} CreateWithFileMapping(ContentAccess contentAccess, string path)
        {{
			var connection = {IncludeNewDbConnection(context.IsPostgres)};
            return CreateWithFileMapping(contentAccess, path, connection);
        }}

        public static {context.Model.Schema.ClassName} CreateWithFileMapping(ContentAccess contentAccess, string path, DbConnection connection)
        {{
            var schemaProvider = new FileSchemaProvider(path);
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);
            return Create(configurator, connection);
        }}
		#endregion

		#region Helpers
		public string ReplacePlaceholders(string input)
		{{
			string result = input;
			if (result != null && (MappingResolver?.GetSchema()?.ReplaceUrls ?? false))
			{{
				result = result.Replace(uploadPlaceholder, UploadUrl);
				result = result.Replace(sitePlaceholder, SiteUrl);
			}}
			return result;
		}}

		public string GetUrl(string input, string className, string propertyName)
		{{
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return String.Format(@""{{0}}/{{1}}"", Cnn.GetUrlForFileAttribute(Cnn.GetAttributeIdByNetNames(SiteId, className, propertyName), true, ShouldRemoveSchema), input);
		}}


		public string GetUploadPath(string input, string className, string propertyName)
		{{
			return Cnn.GetDirectoryForFileAttribute(Cnn.GetAttributeIdByNetNames(SiteId, className, propertyName));
		}}
		
		public void LoadSiteSpecificInfo()
        {{
            if (RemoveUploadUrlSchema && !_shouldRemoveSchema)
            {{
                _shouldRemoveSchema = RemoveUploadUrlSchema;
            }}

            LiveSiteUrl = Cnn.GetSiteUrl(SiteId, true);
            LiveSiteUrlRel = Cnn.GetSiteUrlRel(SiteId, true);
            StageSiteUrl = Cnn.GetSiteUrl(SiteId, false);
            StageSiteUrlRel = Cnn.GetSiteUrlRel(SiteId, false);
            LongUploadUrl = Cnn.GetImagesUploadUrl(SiteId, false, _shouldRemoveSchema);
            ShortUploadUrl = Cnn.GetImagesUploadUrl(SiteId, true, _shouldRemoveSchema);
            PublishedId = Cnn.GetMaximumWeightStatusTypeId(SiteId);
        }}
        #endregion


        #region Save changes
        public override int SaveChanges()
        {{
            return OnSaveChanges();
        }}

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {{
            return await OnSaveChangesAsync();
        }}


        private int OnSaveChanges()
        {{
            ChangeTracker.DetectChanges();

            var modified = ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Modified || (x.State == EntityState.Deleted && x.Entity is IQPLink)) && x.Entity != null)
                .ToList();
            var added = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added && x.Entity != null)
                .ToList();
            var deleted = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted && x.Entity != null && x.Entity is IQPArticle)
                .ToList();

            var connection = Database.GetDbConnection();
            if (connection.State == System.Data.ConnectionState.Closed)
            {{
                connection.Open();
            }}
            if (Cnn.ExternalTransaction != null)
            {{
                UpdateObjectStateEntries(modified, (content, item) => item.Properties.Where(x => x.IsModified).Select(x => x.Metadata.Name).ToArray(), true);
                UpdateObjectStateEntries(added, (content, item) => GetProperties(content), false);

                foreach (var deletedItem in deleted)
                {{
                    var article = (IQPArticle)deletedItem.Entity;
                    Cnn.DeleteContentItem(article.Id);
                }}
            }}
            else
            {{
                using (var transaction = Database.BeginTransaction())
                {{
                    Cnn.ExternalTransaction = transaction.GetDbTransaction();

                    UpdateObjectStateEntries(modified, (content, item) => item.Properties.Where(x => x.IsModified).Select(x => x.Metadata.Name).ToArray(), true);
                    UpdateObjectStateEntries(added, (content, item) => GetProperties(content), false);

                    foreach (var deletedItem in deleted)
                    {{
                        var article = (IQPArticle)deletedItem.Entity;
                        Cnn.DeleteContentItem(article.Id);
                    }}

                    transaction.Commit();
                    Cnn.ExternalTransaction = null;
                }}
            }}
            SendNotifications(added, modified, deleted);
            ChangeTracker.AcceptAllChanges();
            return 0;
        }}
        private async Task<int> OnSaveChangesAsync()
        {{
            ChangeTracker.DetectChanges();

             var modified = ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Modified || (x.State == EntityState.Deleted && x.Entity is IQPLink)) && x.Entity != null)
                .ToList();
            var added = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added && x.Entity != null)
                .ToList();
            var deleted = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted && x.Entity != null && x.Entity is IQPArticle)
                .ToList();

            var connection = Database.GetDbConnection();
            if (connection.State == System.Data.ConnectionState.Closed)
            {{
                await connection.OpenAsync();
            }}
            if (Cnn.ExternalTransaction != null)
            {{
                await UpdateObjectStateEntriesAsync(modified, (content, item) => item.Properties.Where(x => x.IsModified).Select(x => x.Metadata.Name).ToArray(), true);
                await UpdateObjectStateEntriesAsync(added, (content, item) => GetProperties(content), false);

                foreach (var deletedItem in deleted)
                {{
                    var article = (IQPArticle)deletedItem.Entity;
                    Cnn.DeleteContentItem(article.Id);
                }}
            }}
            else
            {{

                using (var transaction = await Database.BeginTransactionAsync())
                {{
                    Cnn.ExternalTransaction = transaction.GetDbTransaction();

                    await UpdateObjectStateEntriesAsync(modified, (content, item) => item.Properties.Where(x => x.IsModified).Select(x => x.Metadata.Name).ToArray(), true);
                    await UpdateObjectStateEntriesAsync(added, (content, item) => GetProperties(content), false);
                   
                    foreach (var deletedItem in deleted)
                    {{
                        var article = (IQPArticle)deletedItem.Entity;
                        Cnn.DeleteContentItem(article.Id);                       
                    }}

                    await transaction.CommitAsync();
                    Cnn.ExternalTransaction = null;
                }}
            }}
            SendNotifications(added, modified, deleted);
            ChangeTracker.AcceptAllChanges();
            return 0;
        }}
        private void SendNotifications(IEnumerable<EntityEntry> added, IEnumerable<EntityEntry> modified, IEnumerable<EntityEntry> deleted)
        {{
            if(GetInfo().SendNotifications)
            {{
                foreach (var addedItem in added)
                {{
                    var article = (IQPArticle)addedItem.Entity;
                    Cnn.SendNotification(article.Id, NotificationEvent.Create);
                }}
                foreach (var modifiedItem in modified)
                {{
                    var article = (IQPArticle)modifiedItem.Entity;
                    Cnn.SendNotification(article.Id, NotificationEvent.Modify);
                    if (article.StatusTypeId != 0)
                    {{
                        Cnn.SendNotification(article.Id, NotificationEvent.StatusChanged);
                    }}
                }}
                foreach (var deletedItem in deleted)
                {{
                    var article = (IQPArticle)deletedItem.Entity;
                    Cnn.SendNotification(article.Id, NotificationEvent.Remove);
                }}
             }}
        }}
        private void UpdateObjectStateEntries(IEnumerable<EntityEntry> entries, Func<ContentInfo, EntityEntry, string[]> getProperties, bool passNullValues)
        {{
            var links = entries.Where(x => typeof(IQPLink).IsAssignableFrom(x.Entity.GetType())).ToList();
            foreach (var group in entries.Where(e => !typeof(IQPLink).IsAssignableFrom(e.Entity.GetType())).GroupBy(m => m.Entity.GetType().Name))
            {{
                var contentName = group.Key;
                var content = MappingResolver.GetContent(contentName);
                if (!content.IsVirtual)
                {{
                    var items = group
                        .Where(item => item.Entity is IQPArticle)
                        .Select(item =>
                        {{

                            var article = (IQPArticle)item.Entity;
                            var properties = getProperties(content, item);
                            var fieldValues = GetFieldValues(contentName, article, properties, passNullValues);
                            if (fieldValues.ContainsKey(""CONTENT_ITEM_ID"") && Int32.Parse(fieldValues[""CONTENT_ITEM_ID""]) < 0)
                            {{
                                fieldValues[""CONTENT_ITEM_ID""] = ""0"";
                                item.Property(""Id"").IsTemporary = false;
                            }}
                            AddLinksToUpdate(article, fieldValues, links);
                            return new
                            {{
                                article,
                                fieldValues
                            }};
                        }})
                        .ToArray();

                    Cnn.MassUpdate(content.Id, items.Select(item => item.fieldValues), 1);

                    foreach (var item in items)
                    {{
                        SyncArticle(item.article, item.fieldValues);
                    }}
                }}
            }}

            foreach (var e in entries.Where(x => typeof(IQPLink).IsAssignableFrom(x.Entity.GetType())))
            {{
                if (((IQPLink)e.Entity).Id <= 0)
                {{
                    ((IQPLink)e.Entity).Id = ((IQPLink)e.Entity).Item.Id;
                    var p = e.Properties.Where(n => n.Metadata.Name != ""ItemId"" && !n.Metadata.Name.EndsWith(""LinkedItemId"") &&
                                            n.Metadata.Name.EndsWith(""ItemId"")).FirstOrDefault();
                    e.Property(p.Metadata.Name).IsTemporary = false;

                }}
                if (((IQPLink)e.Entity).LinkedItemId <= 0)
                {{
                    ((IQPLink)e.Entity).LinkedItemId = ((IQPLink)e.Entity).LinkedItem.Id;
                    var p = e.Properties.Where(n => n.Metadata.Name != ""LinkedItemId"" && n.Metadata.Name.EndsWith(""LinkedItemId"")).FirstOrDefault();
                    e.Property(p.Metadata.Name).IsTemporary = false;
                }}
            }}

            var relations = (from e in links
                             where typeof(IQPLink).IsAssignableFrom(e.Entity.GetType()) &&  e.State != EntityState.Deleted
                             let Id = ((IQPLink)e.Entity).Id
                             let relatedId = ((IQPLink)e.Entity).LinkedItemId
                             let attribute = MappingResolver.GetAttribute(e.Metadata.Name.Substring(e.Metadata.Name.LastIndexOf(""."") + 1))
                             let item = new
                             {{
                                 Id = Id,
                                 RelatedId = relatedId,
                                 ContentId = attribute.ContentId,
                                 Field = attribute.Name
                             }}
                             group item by item.ContentId into g
                             select new {{ ContentId = g.Key, Items = g.ToArray() }}
                    )
                    .ToArray();

            foreach (var relation in relations)
            {{
                var values = relation.Items
                    .GroupBy(r => r.Id)
                    .Select(g =>
                    {{
                        var d = g.GroupBy(x => x.Field).ToDictionary(x => x.Key, x => string.Join("","", x.Select(y => y.RelatedId)));
                        d[SystemColumnNames.Id] = g.Key.ToString();
                        return d;
                    }})
                    .ToArray();

                Cnn.MassUpdate(relation.ContentId, values, 1);
            }}
        }}

        private async Task UpdateObjectStateEntriesAsync(IEnumerable<EntityEntry> entries, Func<ContentInfo, EntityEntry, string[]> getProperties, bool passNullValues)
        {{
            var links = entries.Where(x => typeof(IQPLink).IsAssignableFrom(x.Entity.GetType())).ToList();
            foreach (var group in entries.Where(e => !typeof(IQPLink).IsAssignableFrom(e.Entity.GetType())).GroupBy(m => m.Entity.GetType().Name))
            {{
                var contentName = group.Key;
                var content = MappingResolver.GetContent(contentName);
                if (!content.IsVirtual)
                {{
                    var items = group
                        .Where(item => item.Entity is IQPArticle)
                        .Select(item =>
                        {{

                            var article = (IQPArticle)item.Entity;
                            var properties = getProperties(content, item);
                            var fieldValues = GetFieldValues(contentName, article, properties, passNullValues);
                            if (fieldValues.ContainsKey(""CONTENT_ITEM_ID"") && Int32.Parse(fieldValues[""CONTENT_ITEM_ID""]) < 0)
                            {{
                                fieldValues[""CONTENT_ITEM_ID""] = ""0"";
                                item.Property(""Id"").IsTemporary = false;
                            }}
                            AddLinksToUpdate(article, fieldValues, links);
                            return new
                            {{
                                article,
                                fieldValues
                            }};
                        }})
                        .ToArray();

                    await Cnn.MassUpdateAsync(content.Id, items.Select(item => item.fieldValues), 1);

                    foreach (var item in items)
                    {{
                        SyncArticle(item.article, item.fieldValues);
                    }}
                }}
            }}

            foreach (var e in entries.Where(x => typeof(IQPLink).IsAssignableFrom(x.Entity.GetType())))
            {{
                if (((IQPLink)e.Entity).Id <= 0)
                {{
                    ((IQPLink)e.Entity).Id = ((IQPLink)e.Entity).Item.Id;
                    var p = e.Properties.Where(n => n.Metadata.Name != ""ItemId"" && !n.Metadata.Name.EndsWith(""LinkedItemId"") &&
                                            n.Metadata.Name.EndsWith(""ItemId"")).FirstOrDefault();
                    e.Property(p.Metadata.Name).IsTemporary = false;

                }}
                if (((IQPLink)e.Entity).LinkedItemId <= 0)
                {{
                    ((IQPLink)e.Entity).LinkedItemId = ((IQPLink)e.Entity).LinkedItem.Id;
                    var p = e.Properties.Where(n => n.Metadata.Name != ""LinkedItemId"" && n.Metadata.Name.EndsWith(""LinkedItemId"")).FirstOrDefault();
                    e.Property(p.Metadata.Name).IsTemporary = false;
                }}
            }}

            var relations = (from e in links
                             where typeof(IQPLink).IsAssignableFrom(e.Entity.GetType()) &&  e.State != EntityState.Deleted
                             let Id = ((IQPLink)e.Entity).Id
                             let relatedId = ((IQPLink)e.Entity).LinkedItemId
                             let attribute = MappingResolver.GetAttribute(e.Metadata.Name.Substring(e.Metadata.Name.LastIndexOf(""."") + 1))
                             let item = new
                             {{
                                 Id = Id,
                                 RelatedId = relatedId,
                                 ContentId = attribute.ContentId,
                                 Field = attribute.Name
                             }}
                             group item by item.ContentId into g
                             select new {{ ContentId = g.Key, Items = g.ToArray() }}
                    )
                    .ToArray();

            foreach (var relation in relations)
            {{
                var values = relation.Items
                    .GroupBy(r => r.Id)
                    .Select(g =>
                    {{
                        var d = g.GroupBy(x => x.Field).ToDictionary(x => x.Key, x => string.Join("","", x.Select(y => y.RelatedId)));
                        d[SystemColumnNames.Id] = g.Key.ToString();
                        return d;
                    }})
                    .ToArray();

                await Cnn.MassUpdateAsync(relation.ContentId, values, 1);
            }}
        }}

        private void SyncArticle(IQPArticle article, Dictionary<string, string> fieldValues)
        {{
            article.Id = int.Parse(fieldValues[SystemColumnNames.Id], CultureInfo.InvariantCulture);
            ChangeTracker.Context.Entry(article).CurrentValues[""Id""] = article.Id;
            article.Modified = DateTime.Parse(fieldValues[SystemColumnNames.Modified], CultureInfo.InvariantCulture);
            article.Created = DateTime.Parse(fieldValues[SystemColumnNames.Created], CultureInfo.InvariantCulture);
        }}

        private void AddLinksToUpdate(IQPArticle article, Dictionary<string, string> fieldValues, List<EntityEntry> links)
        {{
            var forwardLinks = links.Where(e => ((IQPLink)e.Entity).Id == article.Id && ((IQPLink)e.Entity).LinkedItemId > 0).ToList();
            if (forwardLinks.Count > 0)
            {{
                var relations = (from e in forwardLinks
                                 let relatedId = ((IQPLink)e.Entity).LinkedItemId
                                 let attribute = MappingResolver.GetAttribute(e.Metadata.Name.Substring(e.Metadata.Name.LastIndexOf(""."") + 1))
                                 select new
                                 {{
                                     RelatedId = e.State == EntityState.Deleted ? 0 : relatedId,
                                     Field = attribute.Name
                                 }})
                    .ToArray();
                var values = relations
                    .GroupBy(r => r.Field).ToDictionary(x => x.Key, x => string.Join("","", 
                        x.Where(y=> y.RelatedId != 0).Select(y => y.RelatedId)));
                MergeValues(fieldValues, values);
                links.RemoveAll(x => forwardLinks.Contains(x));
            }}
            var backwardLinks = links.Where(e => ((IQPLink)e.Entity).LinkedItemId == article.Id && ((IQPLink)e.Entity).Id > 0).ToList();
            if (backwardLinks.Count > 0)
            {{
                var relations = (from e in forwardLinks
                                 let relatedId = ((IQPLink)e.Entity).Id
                                 let attribute = MappingResolver.GetAttribute(e.Metadata.Name.Substring(e.Metadata.Name.LastIndexOf(""."") + 1))
                                 select new
                                 {{
                                     RelatedId =e.State == EntityState.Deleted ? 0 : relatedId,
                                     Field = attribute.RelatedAttribute.Name
                                 }})
                    .ToArray();
                var values = relations
                    .GroupBy(r => r.Field).ToDictionary(x => x.Key, x => string.Join("","", 
                         x.Where(y=> y.RelatedId != 0).Select(y => y.RelatedId)));
                MergeValues(fieldValues, values);
                links.RemoveAll(x => backwardLinks.Contains(x));
            }}
        }}
        private void MergeValues(Dictionary<string, string> fieldValues, Dictionary<string, string> linkValues)
        {{
            foreach (var key in linkValues.Keys)
            {{
                if (fieldValues.ContainsKey(key))
                {{
                    if (string.IsNullOrWhiteSpace(fieldValues[key]))
                    {{
                        fieldValues[key] = linkValues[key];
                    }}
                    else
                    {{
                        fieldValues[key] = string.Join(',', 
                            fieldValues[key].Split(',').Concat(linkValues[key].Split(',')).Distinct());
                    }}
                }}
                else
                {{
                    fieldValues.Add(key, linkValues[key]);
                }}
            }}
        }}

        private string[] GetProperties(ContentInfo content)
        {{
            return content.Attributes
                .Where(c => !c.IsM2O)
                .Select(c => c.MappedName)
                .ToArray();
        }}

        private Dictionary<string, string> GetFieldValues(string contentName, IQPArticle article, string[] fields, bool passNullValues)
        {{
            var filteredFields = fields.Where(x => x != ""StatusTypeId"").ToArray();           
            var fieldValues = article.GetType()
               .GetProperties()
               .Where(f => filteredFields.Contains(f.Name))
               .Select(f => new
               {{
                   field = MappingResolver.GetAttribute(contentName, f.Name.Replace(""_ID"", """")).Name,
                   value = GetValue(f.GetValue(article))
               }})
               .Where(f => passNullValues || f.value != null)
               .Distinct()
               .ToDictionary(
                   f => f.field,
                   f => f.value
               );

            fieldValues[SystemColumnNames.Id] = article.Id.ToString(CultureInfo.InvariantCulture);
            fieldValues[SystemColumnNames.Created] = article.Created.ToString(CultureInfo.InvariantCulture);
            fieldValues[SystemColumnNames.Modified] = article.Modified.ToString(CultureInfo.InvariantCulture);

            if (article.StatusTypeId != 0)
            {{
                fieldValues[SystemColumnNames.StatusTypeId] = article.StatusTypeId.ToString();
            }}
            return fieldValues;
        }}

        private string GetValue(object o)
        {{
            if (o == null)
            {{
                return null;
            }}
            else if (o is bool b)
            {{
                return b ? ""1"" : ""0"";
            }}
            else if (o is IQPArticle)
            {{
                return ((IQPArticle)o).Id.ToString();
            }}
            else if (o is string)
            {{
                return (string)o;
            }}
            else if (o is IEnumerable)
            {{
                var ids = ((IEnumerable)o).OfType<IQPArticle>().Select(a => a.Id).ToArray();
                return string.Join("","", ids);
            }}
            else
            {{
                return o.ToString();
            }}
        }}

        #endregion
        string IQPFormService.GetFormNameByNetNames(string netContentName, string netFieldName)
        {{
            return Cnn.GetFormNameByNetNames(this.SiteId, netContentName, netFieldName);
        }}

        #region IQPSchema implementation
        public SchemaInfo GetInfo()
        {{
            return MappingResolver.GetSchema();
        }}

        public ContentInfo GetInfo<T>()
			where T : IQPArticle
        {{
            return MappingResolver.GetContent(typeof(T).Name);
        }}

        public AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector)
            where Tcontent : IQPArticle
        {{
            var contentName = typeof(Tcontent).Name;
            var expression = (MemberExpression)fieldSelector.Body;
            var attributeName = expression.Member.Name;
            return MappingResolver.GetAttribute(contentName, attributeName);
        }}
        #endregion
    }}
}}
";
        }

        private static string IncludeDbUse(GenerationContext context)
        {
            return context.IsPostgres
                ? $"optionsBuilder.UseNpgsql<{context.Model.Schema.ClassName}>(connection);"
                : $"optionsBuilder.UseSqlServer<{context.Model.Schema.ClassName}>(connection);";
        }

        private static string IncludeNewDbConnection(bool isPostgres)
        {
            return isPostgres
                ? "new NpgsqlConnection(DefaultConnectionString)"
                : "new SqlConnection(DefaultConnectionString)";
        }
    }
}