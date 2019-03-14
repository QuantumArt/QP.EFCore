// Code generated by a template
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data.Common;
using System.Data.SqlClient;
using Quantumart.QPublishing.Database;
using Quantumart.QP8.CoreCodeGeneration.Services;
using System.Linq.Expressions;
using System.Collections.Generic;
using Quantumart.QPublishing.Info;
using System.Collections;
using System.Globalization;
using Quantumart.QP8.EFCore.Models;
using Quantumart.QP8.EFCore.Services;
using Microsoft.Extensions.Configuration;
/* place your custom usings here */

namespace EntityFrameworkCore.Templates
{
    public partial class EFCoreModel: IQPLibraryService, IQPFormService, IQPSchema
    {
        #region Constructors

        public EFCoreModel(ModelReader schema) : base(DefaultConnectionOptions())
        {
            MappingResolver = new MappingResolver(schema);
            OnContextCreated();
        }

		public EFCoreModel(DbContextOptions<EFCoreModel> options, ModelReader schema) 
		: base(options)
        {
            MappingResolver = new MappingResolver(schema);
            OnContextCreated();
        }
		
		public EFCoreModel(DbContextOptions<EFCoreModel> options, IMappingConfigurator mappingConfigurator) 
		: base(options)
        {
			MappingResolver = new MappingResolver(mappingConfigurator.GetSchema());
            MappingConfigurator = mappingConfigurator;
            OnContextCreated();
        }

        private IMappingResolver GetDefaultMappingResolver()
        {
            var schema = new StaticSchemaProvider();
            return new MappingResolver(schema.GetSchema());
        }

        #endregion

        #region Private members
        private const string uploadPlaceholder = "<%=upload_url%>";
        private const string sitePlaceholder = "<%=site_url%>";
        private static string _defaultSiteName = "Product Catalog";
        private static string _defaultConnectionString;
        private static string _defaultConnectionStringName = "qp_database";
        private bool _shouldRemoveSchema = false;
        private string _siteName;
        private DBConnector _cnn;
        #endregion

        #region Properties
        public static bool RemoveUploadUrlSchema = false;

        protected IMappingResolver MappingResolver { get; private set; }
		
		private IMappingConfigurator MappingConfigurator;

        public bool ShouldRemoveSchema { get { return _shouldRemoveSchema; } set { _shouldRemoveSchema = value; } }
        public Int32 SiteId { get; private set; }
		public string SiteUrl { get { return StageSiteUrl; } }
		public string UploadUrl { get { return LongUploadUrl; } }
		public string LiveSiteUrl { get; private set; }
		public string LiveSiteUrlRel { get; private set; }
		public string StageSiteUrl { get; private set; }
		public string StageSiteUrlRel { get; private set; }
		public string LongUploadUrl { get; private set; }
		public string ShortUploadUrl { get; private set; }
		public Int32 PublishedId { get; private set; }
		public string ConnectionString { get; private set; }
		public static string DefaultSiteName 
		{ 
			get { return _defaultSiteName; }
			set { _defaultSiteName = value; }
		}
		public DBConnector Cnn
		{
			get 
			{
				if (_cnn == null) 
				{
					_cnn = new DBConnector(Database.GetDbConnection());
					_cnn.UpdateManyToMany = false;
				}
				return _cnn;
			}
		}
		public string SiteName 
		{ 
			get { return _siteName; } 
			set
			{
				if (!String.Equals(_siteName, value, StringComparison.InvariantCultureIgnoreCase))
				{
					_siteName = value;
					SiteId = Cnn.GetSiteId(_siteName);
					LoadSiteSpecificInfo();
				}
			}
		}
		public static string DefaultConnectionString 
		{ 
			get
			{
				if (_defaultConnectionString == null)
				{
					var configuration = new ConfigurationBuilder()
						.AddJsonFile("appsettings.json")
						.Build();
					var connectionString = configuration.GetConnectionString(_defaultConnectionStringName);
					if (string.IsNullOrWhiteSpace(connectionString))
						throw new ApplicationException(string.Format("Connection string '{0}' is not specified", _defaultConnectionStringName));
					_defaultConnectionString = connectionString;
				}
				return _defaultConnectionString;
			}
			set
			{
				_defaultConnectionString = value;
			}
		}
		#endregion

		#region Factory methods
		public static EFCoreModel Create(SqlConnection connection)
		{
			var optionsBuilder = new DbContextOptionsBuilder<EFCoreModel>();
            optionsBuilder.UseSqlServer<EFCoreModel>(connection);
            var ctx = new EFCoreModel(optionsBuilder.Options);
			ctx.SiteName = DefaultSiteName;
		    ctx.ConnectionString = connection.ConnectionString;
			return ctx;
		}

		public static EFCoreModel Create(IMappingConfigurator configurator, SqlConnection connection)
        {
			var mapping = configurator.GetMappingInfo();
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreModel>();
            optionsBuilder.UseSqlServer<EFCoreModel>(connection);
			EFCoreModel ctx;
			if(mapping != null)
			{
				optionsBuilder.UseModel(mapping.DbCompiledModel);
				ctx = new EFCoreModel(optionsBuilder.Options, mapping.Schema);
				ctx.SiteName = mapping.Schema.Schema.SiteName;
			} else {
				ctx = new EFCoreModel(optionsBuilder.Options, configurator);
			}
            
            ctx.ConnectionString = connection.ConnectionString;
            return ctx;
        }


        public static EFCoreModel Create(IMappingConfigurator configurator)
        {
            return Create(configurator, new SqlConnection(DefaultConnectionString));
        }

		public static EFCoreModel Create(string connection, string siteName) 
		{
            EFCoreModel ctx;
			if(connection.IndexOf("metadata", StringComparison.InvariantCultureIgnoreCase) == -1)
			{
				var optionsBuilder = new DbContextOptionsBuilder<EFCoreModel>();
                optionsBuilder.UseSqlServer<EFCoreModel>(new SqlConnection(connection));
                ctx = new EFCoreModel(optionsBuilder.Options);
				ctx.SiteName = siteName;
				ctx.ConnectionString = connection;
				return ctx;
			}
			else
			{
				var optionsBuilder = new DbContextOptionsBuilder<EFCoreModel>();
                optionsBuilder.UseSqlServer<EFCoreModel>(connection);
                ctx = new EFCoreModel(optionsBuilder.Options);
				ctx.SiteName = siteName;
				ctx.ConnectionString = connection;
				return ctx;
			}
		}


		public static EFCoreModel Create(string connection) 
		{
			return Create(connection, DefaultSiteName);
		}

		public static EFCoreModel Create() 
		{
			return Create(DefaultConnectionString);
		}

		public static EFCoreModel CreateWithStaticMapping(ContentAccess contentAccess)
        {
            return CreateWithStaticMapping(contentAccess, new SqlConnection(DefaultConnectionString));
        }

        public static EFCoreModel CreateWithStaticMapping(ContentAccess contentAccess, SqlConnection connection)
        {
			var schemaProvider = new StaticSchemaProvider();
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);
            return Create(configurator, connection);
        }

		  public static EFCoreModel CreateWithDatabaseMapping(ContentAccess contentAccess)
        {
            return CreateWithDatabaseMapping(contentAccess, DefaultSiteName);
        }

        public static EFCoreModel CreateWithDatabaseMapping(ContentAccess contentAccess, string siteName)
        {
            return CreateWithDatabaseMapping(contentAccess, siteName, new SqlConnection(DefaultConnectionString));
        }

        public static EFCoreModel CreateWithDatabaseMapping(ContentAccess contentAccess, string siteName, SqlConnection connection)
        {
            var schemaProvider = new DatabaseSchemaProvider(siteName, connection);
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);         
            var context = Create(configurator, connection);
			context.SiteName = siteName;
			return context;
        }

        public static EFCoreModel CreateWithFileMapping(ContentAccess contentAccess, string path)
        {
            return CreateWithFileMapping(contentAccess, path, new SqlConnection(DefaultConnectionString));
        }

        public static EFCoreModel CreateWithFileMapping(ContentAccess contentAccess, string path, SqlConnection connection)
        {
            var schemaProvider = new FileSchemaProvider(path);
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);
            return Create(configurator, connection);
        }
		#endregion

		#region Helpers
		public string ReplacePlaceholders(string input)
		{
			string result = input;
			if (result != null && MappingResolver.GetSchema().ReplaceUrls)
			{
				result = result.Replace(uploadPlaceholder, UploadUrl);
				result = result.Replace(sitePlaceholder, SiteUrl);
			}
			return result;
		}

		public string GetUrl(string input, string className, string propertyName)
		{
            return String.Format(@"{0}/{1}", Cnn.GetUrlForFileAttribute(Cnn.GetAttributeIdByNetNames(SiteId, className, propertyName), true, ShouldRemoveSchema), input);
		}


		public string GetUploadPath(string input, string className, string propertyName)
		{
			return Cnn.GetDirectoryForFileAttribute(Cnn.GetAttributeIdByNetNames(SiteId, className, propertyName));
		}
		
		public void LoadSiteSpecificInfo()
        {
            if (RemoveUploadUrlSchema && !_shouldRemoveSchema)
            {
                _shouldRemoveSchema = RemoveUploadUrlSchema;
            }

            LiveSiteUrl = Cnn.GetSiteUrl(SiteId, true);
            LiveSiteUrlRel = Cnn.GetSiteUrlRel(SiteId, true);
            StageSiteUrl = Cnn.GetSiteUrl(SiteId, false);
            StageSiteUrlRel = Cnn.GetSiteUrlRel(SiteId, false);
            LongUploadUrl = Cnn.GetImagesUploadUrl(SiteId, false, _shouldRemoveSchema);
            ShortUploadUrl = Cnn.GetImagesUploadUrl(SiteId, true, _shouldRemoveSchema);
            PublishedId = Cnn.GetMaximumWeightStatusTypeId(SiteId);
        }
        #endregion


        #region Save changes
        public override int SaveChanges()
        {
            return OnSaveChanges2();
        }

        private int OnSaveChanges2()
        {
            ChangeTracker.DetectChanges();

            var modified = ChangeTracker.Entries()
                .Where(x=>x.State == EntityState.Modified && x.Entity != null)
                .ToList();
            var added = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added && x.Entity != null)
                .ToList();
            var deleted = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted && x.Entity != null)
                .ToList();

            var connection = Database.GetDbConnection();
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            using (var transaction = Database.BeginTransaction())
            {
                Cnn.ExternalTransaction = transaction.GetDbTransaction();

                UpdateObjectStateEntries(modified, (content, item) => item.Properties.Where(x=>x.IsModified).Select(x=>x.Metadata.Name).ToArray(), true);
                UpdateObjectStateEntries(added, (content, item) => GetProperties(content), false);

                foreach (var deletedItem in deleted)
                {
                    var article = (IQPArticle)deletedItem.Entity;
                    Cnn.DeleteContentItem(article.Id);
                }

                transaction.Commit();
                Cnn.ExternalTransaction = null;
            }

            connection.Close();

            return 0;
        }

      private void UpdateObjectStateEntries(IEnumerable<EntityEntry> entries, Func<ContentInfo, EntityEntry, string[]> getProperties, bool passNullValues)
        {
            foreach (var group in entries.Where(e => !e.Entity.GetType().IsAssignableFrom(typeof(IQPLink))).GroupBy(m => m.Entity.GetType().Name))
            {
                var contentName = group.Key;
                var content = MappingResolver.GetContent(contentName);
                if (!content.IsVirtual)
                {
                  var items = group
                      .Where(item => item.Entity is IQPArticle)
                      .Select(item => {

                          var article = (IQPArticle)item.Entity;
                          var properties = getProperties(content, item);
                          var fieldValues = GetFieldValues(contentName, article, properties, passNullValues);

                          return new
                          {
                              article,
                              fieldValues
                          };
                      })
                      .ToArray();

                  Cnn.MassUpdate(content.Id, items.Select(item => item.fieldValues), 1);

                  foreach (var item in items)
                  {
                      SyncArticle(item.article, item.fieldValues);
                  }
                }
            }

            var relations = (from e in entries
                    where e.Entity.GetType().IsAssignableFrom(typeof(IQPLink))
                    let  keyParts = e.Metadata.FindPrimaryKey().Properties.Select(p=> e.Property(p.Name).CurrentValue).ToArray()
                    let entityKey = keyParts[0]
                    let relatedEntityKey = keyParts[1]
                    let entry = e.Context.ChangeTracker.Entries().Where(x=>x.CurrentValues["Id"] == entityKey).FirstOrDefault()
                    let relatedEntry = e.Context.ChangeTracker.Entries().Where(x => x.CurrentValues["Id"] == relatedEntityKey).FirstOrDefault()
                    let id = ((IQPArticle)entry.Entity).Id
                    let relatedId = ((IQPArticle)relatedEntry.Entity).Id
                    let attribute = MappingResolver.GetAttribute(e.Metadata.Name)
                    let item = new
                    {
                        Id = id,
                        RelatedId = relatedId,
                        ContentId = attribute.ContentId,
                        Field = attribute.MappedName
                    }
                    group item by item.ContentId into g
                    select new { ContentId = g.Key, Items = g.ToArray() }
                    )
                    .ToArray();

            foreach (var relation in relations)
            {
                var values = relation.Items
                    .GroupBy(r => r.Id)
                    .Select(g =>
                    {
                        var d = g.GroupBy(x => x.Field).ToDictionary(x => x.Key, x => string.Join(",", x.Select(y => y.RelatedId)));
                        d[SystemColumnNames.Id] = g.Key.ToString();
                        return d;
                    })
                    .ToArray();
                
                Cnn.MassUpdate(relation.ContentId, values, 1);
            }
        }

        private void SyncArticle(IQPArticle article, Dictionary<string, string> fieldValues)
        {
            article.Id = int.Parse(fieldValues[SystemColumnNames.Id], CultureInfo.InvariantCulture);
            article.Modified = DateTime.Parse(fieldValues[SystemColumnNames.Modified], CultureInfo.InvariantCulture);
            article.Created = DateTime.Parse(fieldValues[SystemColumnNames.Created], CultureInfo.InvariantCulture);
        }

        private string[] GetProperties(ContentInfo content)
        {
            return content.Attributes
                .Where(c => !c.IsM2O)
                .Select(c => c.MappedName)
                .ToArray();
        }

        private Dictionary<string, string> GetFieldValues(string contentName, IQPArticle article, string[] fields, bool passNullValues)
        {
             var fieldValues = article.GetType()
                .GetProperties()
                .Where(f => fields.Contains(f.Name))
                .Select(f => new {
                    field = MappingResolver.GetAttribute(contentName, f.Name.Replace("_ID", "")).Name,
                    value = GetValue(f.GetValue(article))
                })
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
            {
                fieldValues[SystemColumnNames.StatusTypeId] = article.StatusTypeId.ToString();
            }

            return fieldValues;
        }

        private string GetValue(object o)
        {
            if (o == null)
            {
                return null;
            }
			else if (o is bool b)
            {
                return b ? "1" : "0";
            }
            else if (o is IQPArticle)
            {
                return ((IQPArticle)o).Id.ToString();
            }
            else if (o is string)
            {
                return (string)o;
            }
            else if (o is IEnumerable)
            {
                var ids = ((IEnumerable)o).OfType<IQPArticle>().Select(a => a.Id).ToArray();
                return string.Join(",", ids);
            }
            else
            {
                return o.ToString();
            }
        }


        int OnSaveChanges()
        {
            base.ChangeTracker.DetectChanges();

            var objectCount = 0;
            

            var modified = ChangeTracker.Entries()
                .Where(x=>x.State == EntityState.Modified && x.Entity != null)
                .ToList();
            var added = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added && x.Entity != null)
                .ToList();
            var deleted = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted && x.Entity != null)
                .ToList();

            foreach (var addedItem in added)
            {
                objectCount++;
                if (!addedItem.Entity.GetType().IsAssignableFrom(typeof(IQPLink)))
                {
                    var entity = addedItem.Entity as IQPArticle;
                    if(entity != null)
                    {
                        ProcessCreating(addedItem.Metadata.Name, entity, addedItem);
                    }
                }
                else
                {
                }
            }

            foreach (var modifiedItem in modified)
            {
                if (!modifiedItem.Entity.GetType().IsAssignableFrom(typeof(IQPLink)))
                {
                    objectCount++;
                    var entity = modifiedItem.Entity as IQPArticle;
                    if (entity != null)
                    {
                        ProcessUpdating(modifiedItem.Metadata.Name, entity, modifiedItem);
                    }
                }
                else
                {
                }
            }

            return 0;
        }


        private void ProcessCreating(string contentName, IQPArticle instance, EntityEntry entry)
        {
            throw new NotImplementedException();
            var properties = entry.Properties.Where(x=>x.IsModified).Select(x=>x.Metadata.Name).ToArray();
            var values = instance.Pack(this);
            DateTime created = DateTime.Now;
            // instance.LoadStatusType();
            // todo: load first status
            const string lowestStatus = "None";
            if (!properties.Contains("Visible"))
                instance.Visible = true;
            if (!properties.Contains("Archive"))
                instance.Archive = false;

            // instance.Id = Cnn.AddFormToContent(SiteId, Cnn.GetContentIdByNetName(SiteId, contentName), lowestStatus, ref values, 0, true, 0, instance.Visible, instance.Archive, true, ref created);
            instance.Created = created;
            instance.Modified = created;
        }

        private void ProcessUpdating(string contentName, IQPArticle instance, EntityEntry entry)
        {
		    throw new NotImplementedException();
		    var properties = entry.Properties.Where(x=>x.IsModified).Select(x=>x.Metadata.Name).ToArray();
			var values = instance.Pack(this);
			DateTime modified = DateTime.Now;
			throw new NotImplementedException("CUD operations are not implemented yet.");
			// Cnn.AddFormToContent(SiteId, Cnn.GetContentIdByNetName(SiteId, contentName), instance.StatusType.StatusTypeName, ref values, (int)instance.Id, true, 0, instance.Visible, instance.Archive, true, ref modified);
			// instance.Modified = modified;
        }
        #endregion
        string IQPFormService.GetFormNameByNetNames(string netContentName, string netFieldName)
        {
            return Cnn.GetFormNameByNetNames(this.SiteId, netContentName, netFieldName);
        }

        #region IQPSchema implementation
        public SchemaInfo GetInfo()
        {
            return MappingResolver.GetSchema();
        }

        public ContentInfo GetInfo<T>()
			where T : IQPArticle
        {
            return MappingResolver.GetContent(typeof(T).Name);
        }

        public AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector)
            where Tcontent : IQPArticle
        {
            var contentName = typeof(Tcontent).Name;
            var expression = (MemberExpression)fieldSelector.Body;
            var attributeName = expression.Member.Name;
            return MappingResolver.GetAttribute(contentName, attributeName);
        }
        #endregion
    }
}
