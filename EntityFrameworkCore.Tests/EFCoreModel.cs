using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;	
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading;



namespace EntityFrameworkCore.Tests
{
    public partial class EFCoreModel : DbContext
    {
        public static ContentAccess DefaultContentAccess = ContentAccess.Live;

        private static string _Key = Guid.NewGuid().ToString();
        private static string Key
        {
            get
            {
                return "EFCoreUtilDataContextKey " + _Key;
            }
        }
        private static IHttpContextAccessor _accessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        private static AsyncLocal<EFCoreModel> _context = new AsyncLocal<EFCoreModel>();

        public static EFCoreModel Current
        {
            get
            {
                if (_accessor?.HttpContext == null)
                    return _context.Value;
                else
                    return (EFCoreModel)_accessor.HttpContext.Items[Key];
            }

            private set
            {
                 if (_accessor?.HttpContext == null)
                    _context.Value = value;
                else
                    _accessor.HttpContext.Items[Key] = value;
            }
        }

        void OnContextCreated()
        {
            Current = this;
        }

        public EFCoreModel()
            : base(DefaultConnectionOptions())
        {
            MappingResolver = GetDefaultMappingResolver();

            OnContextCreated();
        }
		
		public EFCoreModel(IConfiguration configuration)
            : base(DefaultConnectionOptions(configuration))
        {
            MappingResolver = GetDefaultMappingResolver();

            OnContextCreated();
        }
		
		public EFCoreModel(DbContextOptions<EFCoreModel> options)
            : base(options)
        {
            MappingResolver = GetDefaultMappingResolver();

            OnContextCreated();
        }

        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        public virtual DbSet<AfiellFieldsItem> AfiellFieldsItems { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<StringItem> StringItems { get; set; }
        public virtual DbSet<StringItemForUpdate> StringItemsForUpdate { get; set; }
        public virtual DbSet<StringItemForUnsert> StringItemsForInsert { get; set; }
        public virtual DbSet<ItemForUpdate> ItemsForUpdate { get; set; }
        public virtual DbSet<ItemForInsert> ItemsForInsert { get; set; }
        public virtual DbSet<PublishedNotPublishedItem> PublishedNotPublishedItems { get; set; }
        public virtual DbSet<ReplacingPlaceholdersItem> ReplacingPlaceholdersItems { get; set; }
        public virtual DbSet<FileFieldsItem> FileFieldsItems { get; set; }
        public virtual DbSet<SymmetricRelationArticle> SymmetricRelationArticles { get; set; }
        public virtual DbSet<ToSymmetricRelationAtricle> ToSymmetricRelationAtricles { get; set; }
        public virtual DbSet<MtMItemForUpdate> MtMItemsForUpdate { get; set; }
        public virtual DbSet<MtMDictionaryForUpdate> MtMDictionaryForUpdate { get; set; }
        public virtual DbSet<OtMItemForUpdate> OtMItemsForUpdate { get; set; }
        public virtual DbSet<OtMDictionaryForUpdate> OtMDictionaryForUpdate { get; set; }
        public virtual DbSet<DateItemForUpdate> DateItemsForUpdate { get; set; }
        public virtual DbSet<TimeItemForUpdate> TimeItemsForUpdate { get; set; }
        public virtual DbSet<DateTimeItemForUpdate> DateTimeItemsForUpdate { get; set; }
        public virtual DbSet<FileItemForUpdate> FileItemsForUpdate { get; set; }
        public virtual DbSet<ImageItemForUpdate> ImageItemsForUpdate { get; set; }
        public virtual DbSet<OtMItemForMapping> OtMItemsForMapping { get; set; }
        public virtual DbSet<OtMRelatedItemWithMapping> OtMRelatedItemsWithMapping { get; set; }
        public virtual DbSet<OtMItemToContentWithoutMapping> OtMItemsToContentWithoutMapping { get; set; }
        public virtual DbSet<BooleanItemForUpdate> BooleanItemsForUpdate { get; set; }
        public virtual DbSet<OtMItemForUpdateVirtual> OtMItemForUpdateVirtuals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			var schemaProvider = new StaticSchemaProvider();
			var mapping = new MappingConfigurator(DefaultContentAccess, schemaProvider);
			mapping.OnModelCreating(modelBuilder);
        }

		private static DbContextOptions<EFCoreModel> DefaultConnectionOptions()
        {
			var configuration = new ConfigurationBuilder()
						.AddJsonFile("appsettings.json")
						.Build();
			var connectionString = configuration.GetConnectionString("EFCoreModel");
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreModel>();
            optionsBuilder.UseSqlServer<EFCoreModel>(connectionString);
            return optionsBuilder.Options;
        }
		
		private static DbContextOptions<EFCoreModel> DefaultConnectionOptions(IConfiguration configuration)
        {
		    var connectionString = configuration.GetConnectionString("EFCoreModel");
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreModel>();
            optionsBuilder.UseSqlServer<EFCoreModel>(connectionString);
            return optionsBuilder.Options;
        }
		
		
	}
}
