﻿using System.Collections.Generic;
using System.Text;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
    internal static class ModelDbContext
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var sb = new StringBuilder();
            sb.AppendLine(@$"{context.Settings.GeneratedCodePrefix}
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;	
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;
{context.Settings.Usings}

namespace {ns}
{{
    public partial class {context.Model.Schema.ClassName} : DbContext
    {{
        public static ContentAccess DefaultContentAccess = ContentAccess.Live;

        private static string _Key = Guid.NewGuid().ToString();
        private static string Key
        {{
            get
            {{
                return ""EFCoreUtilDataContextKey "" + _Key;
            }}
        }}
        private static IHttpContextAccessor _accessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {{
            _accessor = accessor;
        }}

        private static AsyncLocal<{context.Model.Schema.ClassName}> _context = new AsyncLocal<{context.Model.Schema.ClassName}>();

        public static {context.Model.Schema.ClassName} Current
        {{
            get
            {{
                if (_accessor?.HttpContext == null)
                    return _context.Value;
                else
                    return ({context.Model.Schema.ClassName})_accessor.HttpContext.Items[Key];
            }}

            private set
            {{
                 if (_accessor?.HttpContext == null)
                    _context.Value = value;
                else
                    _accessor.HttpContext.Items[Key] = value;
            }}
        }}

        void OnContextCreated()
        {{
            Current = this;
        }}

        public {context.Model.Schema.ClassName}()
            : base(DefaultConnectionOptions())
        {{");
            if (context.Settings.GenerateExtensions)
            {
                sb.AppendLine("            MappingResolver = GetDefaultMappingResolver();");
            }

            sb.AppendLine(@$"OnContextCreated();
        }}
		
		public {context.Model.Schema.ClassName}(IConfiguration configuration)
            : base(DefaultConnectionOptions(configuration))
        {{");
            if (context.Settings.GenerateExtensions)
            {
                sb.AppendLine("            MappingResolver = GetDefaultMappingResolver();");
            }

            sb.AppendLine(@$"            OnContextCreated();
        }}
		
		public {context.Model.Schema.ClassName}(DbContextOptions<{context.Model.Schema.ClassName}> options)
            : base(options)
        {{");
            if (context.Settings.GenerateExtensions)
            {
                sb.AppendLine("            MappingResolver = GetDefaultMappingResolver();");
            }

            sb.AppendLine(@"
            OnContextCreated();
        }

        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }");

            IncludeContentsProperties(sb, context.Model.Contents);

            sb.AppendLine($@"
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {{
			var schemaProvider = new StaticSchemaProvider();
			var mapping = new MappingConfigurator(DefaultContentAccess, schemaProvider);
			mapping.OnModelCreating(modelBuilder);
            mapping.OnModelFinalized(modelBuilder.FinalizeModel());
        }}

		private static DbContextOptions<{context.Model.Schema.ClassName}> DefaultConnectionOptions()
        {{
			var configuration = new ConfigurationBuilder()
						.AddJsonFile(""appsettings.json"")
						.Build();
			var connectionString = configuration.GetConnectionString(""{context.Model.Schema.ConnectionStringName}"");
            var optionsBuilder = new DbContextOptionsBuilder<{context.Model.Schema.ClassName}>();
            {IncludeDbUse(context)}
            return optionsBuilder.Options;
        }}
		
		private static DbContextOptions<{context.Model.Schema.ClassName}> DefaultConnectionOptions(IConfiguration configuration)
        {{
		    var connectionString = configuration.GetConnectionString(""{context.Model.Schema.ConnectionStringName}"");
            var optionsBuilder = new DbContextOptionsBuilder<{context.Model.Schema.ClassName}>();
            {IncludeDbUse(context)}
            return optionsBuilder.Options;
        }}
		
		
	}}
}}");
            return sb.ToString();
        }


        private static string IncludeDbUse(GenerationContext context)
        {
            return context.IsPostgres
                ? $"optionsBuilder.UseNpgsql<{context.Model.Schema.ClassName}>(connectionString);"
                : $"optionsBuilder.UseSqlServer<{context.Model.Schema.ClassName}>(connectionString);";
        }

        private static void IncludeContentsProperties(StringBuilder sb, IEnumerable<ContentInfo> contents)
        {
            foreach (var content in contents)
            {
                sb.AppendLine(@$"        public virtual DbSet<{content.MappedName}> {content.PluralMappedName} {{ get; set; }}");
            }
        }
    }
}