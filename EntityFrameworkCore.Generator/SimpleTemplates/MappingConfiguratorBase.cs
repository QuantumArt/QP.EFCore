﻿using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class MappingConfiguratorBase
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.EntityFrameworkCore.Metadata;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.Conventions;

namespace {ns}
{{
    public abstract class MappingConfiguratorBase : IMappingConfigurator
    {{
        private const string TableLive = ""content_{{0}}_new"";
        private const string TableStage = ""content_{{0}}_united_new"";
        private const string TableLiveFiltered = ""content_{{0}}_live_new"";
        private const string TableStageFiltered = ""content_{{0}}_stage_new"";

        private static ConcurrentDictionary<object, Lazy<MappingInfo>> _cache = new ConcurrentDictionary<object, Lazy<MappingInfo>>();

        private readonly ISchemaProvider _schemaProvider;
        private readonly ContentAccess _contentAccess;
        private IMappingResolver _mappingResolver;

        public MappingConfiguratorBase(ContentAccess contentAccess, ISchemaProvider schemaProvider)
        {{
            _contentAccess = contentAccess;
            _schemaProvider = schemaProvider;
        }}

        public virtual MappingInfo GetMappingInfo()
        {{
            return _cache.GetOrAdd(GetCacheKey(), a =>
            {{
                var _schema = _schemaProvider.GetSchema();
                _mappingResolver = new MappingResolver(_schema);
                ConventionSet conventionSet;
                if (_schema.Schema.DBType == DatabaseType.Postgres)
                {{
                    conventionSet = NpgsqlConventionSetBuilder.Build();
                }}
                else
                {{
                    conventionSet = SqlServerConventionSetBuilder.Build();
                }}
                var builder = new ModelBuilder(conventionSet);
                OnModelCreating(builder);
                var iModel = builder.FinalizeModel();
                OnModelFinalized(iModel);

                return new Lazy<MappingInfo>(
                    () => new MappingInfo(iModel, _schema),
                    LazyThreadSafetyMode.ExecutionAndPublication);
            }}).Value;
        }}

        public ModelReader GetSchema()
		{{
			return _schemaProvider.GetSchema();
		}}

        protected void AddMappingInfo(IModel model)
        {{
            var _schema = _schemaProvider.GetSchema();
            _cache.TryAdd(GetCacheKey(), new Lazy<MappingInfo>(
                    () => new MappingInfo(model, _schema),
                    LazyThreadSafetyMode.ExecutionAndPublication));
        }}

        public virtual void OnModelFinalized(IModel model)
        {{
        }}

        public virtual void OnModelCreating(ModelBuilder modelBuilder)
        {{
            if (_mappingResolver == null)
            {{
                _mappingResolver = new MappingResolver(_schemaProvider.GetSchema());
            }}

            #region StatusType
            modelBuilder.Entity<StatusType>()
                .ToTable(""status_type_new"")
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(""id"");

            modelBuilder.Entity<StatusType>().Property(e => e.SiteId).HasColumnName(""site_id"");
            modelBuilder.Entity<StatusType>().Property(e => e.StatusTypeName).HasColumnName(""name"");
            modelBuilder.Entity<StatusType>().Property(e => e.Weight).HasColumnName(""weight"");
            #endregion

            #region User
            modelBuilder.Entity<User>()
                .ToTable(""user_new"")
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(""id"");

            modelBuilder.Entity<User>().Property(e => e.FirstName).HasColumnName(""first_name"");
            modelBuilder.Entity<User>().Property(e => e.LastName).HasColumnName(""last_name"");
            modelBuilder.Entity<User>().Property(e => e.NTLogin).HasColumnName(""nt_login"");
            modelBuilder.Entity<User>().Property(e => e.ISOCode).HasColumnName(""iso_code"");
            modelBuilder.Entity<User>().Property(e => e.Email).HasColumnName(""email"");
            #endregion

            #region UserGroup
            modelBuilder.Entity<UserGroup>()
                .ToTable(""user_group_new"")
                .Property(e => e.Id).ValueGeneratedOnAdd()
                .HasColumnName(""id"");

            modelBuilder.Entity<UserGroup>().Property(e => e.Name).HasColumnName(""name"");

            modelBuilder.Entity<UserGroupBind>()
                .ToTable(""user_group_bind_new"");

            modelBuilder.Entity<UserGroupBind>().Property(e => e.UserId).HasColumnName(""user_id"");
            modelBuilder.Entity<UserGroupBind>().Property(e => e.GroupId).HasColumnName(""group_id"");
            modelBuilder.Entity<UserGroupBind>().HasKey(ug => new {{ ug.UserId, ug.GroupId }});

            modelBuilder.Entity<UserGroupBind>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserGroupBinds)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserGroupBind>()
                .HasOne(bc => bc.UserGroup)
                .WithMany(c => c.UserGroupBinds)
                .HasForeignKey(bc => bc.GroupId);

            #endregion
        }}

        private object GetCacheKey()
        {{
            return new {{ _contentAccess, resolverKey = _schemaProvider.GetCacheKey() }};
        }}

        #region Dynamic mapping
        protected string GetFieldName(string contentMappedName, string fieldMappedName)
        {{
            return _mappingResolver.GetAttribute(contentMappedName, fieldMappedName).Name.ToLowerInvariant();
        }}

        protected string GetTableName(string mappedName)
        {{
            var content = _mappingResolver.GetContent(mappedName);
            return GetTableName(content.Id, content.UseDefaultFiltration).ToLowerInvariant();
        }}

        protected string GetLinkTableName( string contentMappedName, string fieldMappedName)
        {{
            int linkId = _mappingResolver.GetAttribute(contentMappedName, fieldMappedName).LinkId;
            return GetLinkTableName(linkId);
        }}

        protected string GetReversedLinkTableName(string contentMappedName, string fieldMappedName)
        {{
            int linkId = _mappingResolver.GetAttribute(contentMappedName, fieldMappedName).LinkId;
            return GetReversedLinkTableName(linkId);
        }}
        #endregion

        #region Static mapping
        private string GetTableName(int contentId, bool useDefaultFiltration)
        {{
            switch (_contentAccess)
            {{
                case ContentAccess.Live:
                    return string.Format(useDefaultFiltration ? TableLiveFiltered : TableLive, contentId);
                case ContentAccess.Stage:
                    return string.Format(useDefaultFiltration ? TableStageFiltered : TableStage, contentId);
                case ContentAccess.StageNoDefaultFiltration:
                    return string.Format(TableStage, contentId);
            }}

            throw new InvalidOperationException(_contentAccess + "" is not supported."");
        }}

        private string GetLinkTableName(int linkId)
        {{
            switch (_contentAccess)
            {{
                case ContentAccess.Live:
                    return string.Format(""item_link_{{0}}"", linkId);
                case ContentAccess.Stage:
                    return string.Format(""item_link_{{0}}_united"", linkId);
                case ContentAccess.StageNoDefaultFiltration:
                    return string.Format(""item_link_{{0}}_united"", linkId);
            }}

            throw new InvalidOperationException(_contentAccess + "" is not supported."");
        }}

        private string GetReversedLinkTableName(int linkId)
        {{
            switch (_contentAccess)
            {{
                case ContentAccess.Live:
                    return string.Format(""item_link_{{0}}_rev"", linkId);
                case ContentAccess.Stage:
                    return string.Format(""item_link_{{0}}_united_rev"", linkId);
                case ContentAccess.StageNoDefaultFiltration:
                    return string.Format(""item_link_{{0}}_united_rev"", linkId);
            }}

            throw new InvalidOperationException(_contentAccess + "" is not supported."");
        }}
        #endregion
    }}
}}";
        }
    }
}