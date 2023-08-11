using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Templates
{
    internal class MappingConfigurator
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var sb = new StringBuilder();
            sb.AppendLine(@$"{context.Settings.GeneratedCodePrefix}
using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.EntityFrameworkCore.Metadata;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

{context.Settings.Usings}

namespace {ns}
{{
    public class MappingConfigurator : MappingConfiguratorBase
    {{
        public MappingConfigurator(ContentAccess contentAccess, ISchemaProvider schemaProvider)
            : base(contentAccess, schemaProvider)
        {{
        }}

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {{
            base.OnModelCreating(modelBuilder);");
            IncludeMappingConfigurators(sb, context.Model.Contents);
            sb.AppendLine(@"
        }
        
        public override void OnModelFinalized(IModel model)
        {
            AddMappingInfo(model);
        }
    }
}");
            return sb.ToString();
        }

        private static void IncludeMappingConfigurators(StringBuilder sb, IEnumerable<ContentInfo> contents)
        {
            foreach (var content in contents)
            {
                sb.AppendLine($"#region {content.MappedName} mappings");
                IncludeBaseMapping(sb, content.MappedName);
                IncludeAttributesMappingIsRelation(sb, content.Attributes.Where(x => !x.IsRelation));
                IncludeAttributesMappingIsO2M(sb, content.Attributes.Where(x => x.IsO2M));
                IncludeAttributesMappingIsM2MIsSource(sb, content.MappedName,
                    content.Attributes.Where(x => x.IsM2M && x.IsSource == true));
                IncludeAttributesMappingIsGenerateLibraryUrl(sb, content.Attributes.Where(x => x.GenerateLibraryUrl));
                IncludeAttributesMappingIsGenerateUploadPath(sb, content.Attributes.Where(x => x.GenerateUploadPath));
                sb.AppendLine("#endregion");
            }
        }

        private static void IncludeBaseMapping(StringBuilder sb, string mappedName)
        {
            sb.AppendLine($@"
            modelBuilder.Entity<{mappedName}>()
                .ToTable(GetTableName(""{mappedName}""))
                .Property(x => x.Id)
                .HasColumnName(""content_item_id"");

                modelBuilder.Entity<{mappedName}>()
                    .HasKey(x=>x.Id);
           
                modelBuilder.Entity<{mappedName}>()
                    .Property(x => x.LastModifiedBy)
                    .HasColumnName(""last_modified_by"");
            
                modelBuilder.Entity<{mappedName}>()
                    .Property(x => x.StatusTypeId)
                    .HasColumnName(""status_type_id"");

                modelBuilder.Entity<{mappedName}>()
                    .Property(x => x.Archive)
                    .HasColumnName(""archive"");

                modelBuilder.Entity<{mappedName}>()
                    .Property(x => x.Created)
                    .HasColumnName(""created"");

                modelBuilder.Entity<{mappedName}>()
                    .Property(x => x.Modified)
                    .HasColumnName(""modified"");

                modelBuilder.Entity<{mappedName}>()
                    .Property(x => x.Visible)
                    .HasColumnName(""visible"");

                modelBuilder.Entity<{mappedName}>()
                    .HasOne<StatusType>(x => x.StatusType)
                    .WithMany()
                    .IsRequired()
                    .HasForeignKey(x => x.StatusTypeId);");
        }

        private static void IncludeAttributesMappingIsRelation(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
        {
            foreach (var attribute in attributes)
            {
                sb.AppendLine($@"
            modelBuilder.Entity<{attribute.Content.MappedName}>()
                .Property(x => x.{attribute.MappedName})
                .HasColumnName(GetFieldName(""{attribute.Content.MappedName}"", ""{attribute.MappedName}""));");
            }
        }

        private static void IncludeAttributesMappingIsO2M(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
        {
            foreach (var attribute in attributes)
            {
                sb.AppendLine(@$"
            modelBuilder.Entity<{attribute.Content.MappedName}>()
                .HasOne<{attribute.RelatedContent.MappedName}>(mp => mp.{attribute.MappedName})
                .WithMany(mp => mp.{attribute.RelatedAttribute.MappedName})
                .HasForeignKey(fp => fp.{attribute.OriginalMappedName});

            modelBuilder.Entity<{attribute.Content.MappedName}>()
                .Property(x => x.{attribute.OriginalMappedName})
                .HasColumnName(GetFieldName(""{attribute.Content.MappedName}"", ""{attribute.MappedName}"").ToLowerInvariant());");
            }
        }

        private static void IncludeAttributesMappingIsM2MIsSource(StringBuilder sb, string mappedName,
            IEnumerable<AttributeInfo> attributes)
        {
            foreach (var attribute in attributes)
            {
                if (!attribute.RelatedContent.SplitArticles)
                {
                    sb.AppendLine($@"
                modelBuilder.Entity<{attribute.Content.MappedName}>()
                .HasMany(e => e.{attribute.MappedName})
                .WithMany(e => e.{attribute.RelatedAttribute.MappedName})
                .UsingEntity<{attribute.M2MClassName}>(
                bc => bc
                    .HasOne(c => c.{attribute.M2MRelatedPropertyName})
                    .WithMany()
                    .HasForeignKey(c => c.{attribute.M2MRelatedPropertyName}Id),
                bc => bc
                    .HasOne(c => c.{attribute.M2MPropertyName})
                    .WithMany()
                    .HasForeignKey(c => c.{attribute.M2MPropertyName}Id),
                bc => 
                {{ 
                    bc.Property(e => e.{attribute.M2MPropertyName}Id).HasColumnName(""id"");
                    bc.Property(e => e.{attribute.M2MRelatedPropertyName}Id).HasColumnName(""linked_id"");
                    bc.HasKey(ug => new {{ ug.{attribute.M2MPropertyName}Id, ug.{attribute.M2MRelatedPropertyName}Id }});
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetLinkTableName(""{mappedName}"", ""{attribute.MappedName}""));
                    }});
");
                }
                else
                {
                    sb.AppendLine($@"
                modelBuilder.Entity<{attribute.Content.MappedName}>()
                .HasMany(e => e.{attribute.MappedName})
                .WithMany(e => e.{attribute.RelatedAttribute.MappedName}Reverse)
                .UsingEntity<{attribute.M2MClassName}>(
                bc => bc
                    .HasOne(c => c.{attribute.M2MRelatedPropertyName})
                    .WithMany(),
                bc => bc
                    .HasOne(c => c.{attribute.M2MPropertyName})
                    .WithMany()
                    .HasForeignKey(c => c.{attribute.M2MPropertyName}Id),
                bc => 
                {{
                    bc.Property(e => e.{attribute.M2MPropertyName}Id).HasColumnName(""id"");
                    bc.Property(e => e.{attribute.M2MRelatedPropertyName}Id).HasColumnName(""linked_id"");
                    bc.HasKey(ug => new {{ ug.{attribute.M2MPropertyName}Id, ug.{attribute.M2MRelatedPropertyName}Id }});
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetLinkTableName(""{mappedName}"", ""{attribute.MappedName}""));
                }});
            
            modelBuilder.Entity<{attribute.RelatedContent.MappedName}>()
                .HasMany(e => e.{attribute.RelatedAttribute.MappedName})
                .WithMany(e => e.{attribute.MappedName}Reverse)
                .UsingEntity<{attribute.M2MReverseClassName}>(
                bc => bc
                    .HasOne(c => c.{attribute.M2MReversePropertyName})
                    .WithMany(),
                bc => bc
                    .HasOne(c => c.{attribute.M2MReverseRelatedPropertyName})
                    .WithMany()
                    .HasForeignKey(c => c.{attribute.M2MReverseRelatedPropertyName}Id),
                bc => 
                {{");

                    if (attribute.ContentId != attribute.RelatedContentId)
                    {
                        sb.AppendLine($@"
                    bc.Property(e => e.{attribute.M2MReversePropertyName}Id).HasColumnName(""linked_id"");
                    bc.Property(e => e.{attribute.M2MReverseRelatedPropertyName}Id).HasColumnName(""id"");");
                    }
                    else
                    {
                        sb.AppendLine($@"
			        bc.Property(e => e.{attribute.M2MReversePropertyName}Id).HasColumnName(""id"");
			        bc.Property(e => e.{attribute.M2MReverseRelatedPropertyName}Id).HasColumnName(""linked_id"");");
                    }

                    sb.AppendLine($@"
                    bc.HasKey(ug => new {{ ug.{attribute.M2MReversePropertyName}Id, ug.{attribute.M2MReverseRelatedPropertyName}Id }});
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetReversedLinkTableName(""{mappedName}"", ""{attribute.MappedName}""));
                }});

"); 
                } 
            }
        }

        private static void IncludeAttributesMappingIsGenerateLibraryUrl(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
        {
            foreach (var attribute in attributes)
            {
                sb.AppendLine(
                    $"            modelBuilder.Entity<{attribute.Content.MappedName}>().Ignore(p => p.{attribute.MappedName}Url);");
            }
        }

        private static void IncludeAttributesMappingIsGenerateUploadPath(StringBuilder sb, IEnumerable<AttributeInfo> attributes)
        {
            foreach (var attribute in attributes)
            {
                sb.AppendLine(
                    $"            modelBuilder.Entity<{attribute.Content.MappedName}>().Ignore(p => p.{attribute.MappedName}UploadPath);");
            }
        }
    }
}