using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;	
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading;



namespace EntityFrameworkCore.Data
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

        public virtual DbSet<MarketingProduct> MarketingProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductParameter> ProductParameters { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<MobileTariff> MobileTariffs { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
		public virtual DbSet<Product2RegionForRegions> Product2RegionsForRegions { get; set; }

		public virtual DbSet<Region2ProductForBackwardForRegions_Product > Region2ProductsForBackwardForRegions_Product  { get; set; }
		public virtual DbSet<Region2RegionForAllowedRegions> Region2RegionsForAllowedRegions { get; set; }

		public virtual DbSet<Region2RegionForBackwardForAllowedRegions_Region > Region2RegionsForBackwardForAllowedRegions_Region  { get; set; }
		public virtual DbSet<Region2RegionForDeniedRegions> Region2RegionsForDeniedRegions { get; set; }

		public virtual DbSet<Region2RegionForBackwardForDeniedRegions_Region > Region2RegionsForBackwardForDeniedRegions_Region  { get; set; }
		public virtual DbSet<Setting2SettingForRelatedSettings> Setting2SettingsForRelatedSettings { get; set; }

		public virtual DbSet<Setting2SettingForBackwardForRelatedSettings_Setting > Setting2SettingsForBackwardForRelatedSettings_Setting  { get; set; }
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
            optionsBuilder.UseNpgsql<EFCoreModel>(connectionString);
            return optionsBuilder.Options;
        }
		
		private static DbContextOptions<EFCoreModel> DefaultConnectionOptions(IConfiguration configuration)
        {
		    var connectionString = configuration.GetConnectionString("EFCoreModel");
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreModel>();
            optionsBuilder.UseNpgsql<EFCoreModel>(connectionString);
            return optionsBuilder.Options;
        }
		
		
	}
}
