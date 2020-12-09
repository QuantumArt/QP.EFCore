using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Quantumart.QP8.CoreCodeGeneration.Services;



namespace EntityFrameworkCore.Tests
{
    public class MappingConfigurator : MappingConfiguratorBase
    {
        public MappingConfigurator(ContentAccess contentAccess, ISchemaProvider schemaProvider)
            : base(contentAccess, schemaProvider)
        {
        }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);

            #region AfiellFieldsItem mappings
            modelBuilder.Entity<AfiellFieldsItem>()
                .ToTable(GetTableName("AfiellFieldsItem"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<AfiellFieldsItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<AfiellFieldsItem>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.String)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "String"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Integer)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "Integer"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Decimal)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "Decimal"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Boolean)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "Boolean"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Date)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "Date"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Time)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "Time"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.DateTime)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "DateTime"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.File)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "File"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Image)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "Image"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.TextBox)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "TextBox"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.VisualEdit)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "VisualEdit"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.DynamicImage)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "DynamicImage"));
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.Enum)
                .HasColumnName(GetFieldName("AfiellFieldsItem", "Enum"));
            modelBuilder.Entity<AfiellFieldsItem>().Ignore(p => p.FileUrl);
            modelBuilder.Entity<AfiellFieldsItem>().Ignore(p => p.ImageUrl);
            modelBuilder.Entity<AfiellFieldsItem>().Ignore(p => p.DynamicImageUrl);
            modelBuilder.Entity<AfiellFieldsItem>().Ignore(p => p.FileUploadPath);
            modelBuilder.Entity<AfiellFieldsItem>().Ignore(p => p.ImageUploadPath);
 
            #endregion

            #region Schema mappings
            modelBuilder.Entity<Schema>()
                .ToTable(GetTableName("Schema"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<Schema>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<Schema>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<Schema>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<Schema>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<Schema>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<Schema>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<Schema>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<Schema>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<Schema>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("Schema", "Title"));
 
            #endregion

            #region StringItem mappings
            modelBuilder.Entity<StringItem>()
                .ToTable(GetTableName("StringItem"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<StringItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<StringItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<StringItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<StringItem>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<StringItem>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<StringItem>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<StringItem>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<StringItem>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<StringItem>()
                .Property(x => x.StringValue)
                .HasColumnName(GetFieldName("StringItem", "StringValue"));
 
            #endregion

            #region StringItemForUpdate mappings
            modelBuilder.Entity<StringItemForUpdate>()
                .ToTable(GetTableName("StringItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<StringItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<StringItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.StringValue)
                .HasColumnName(GetFieldName("StringItemForUpdate", "StringValue"));
 
            #endregion

            #region StringItemForUnsert mappings
            modelBuilder.Entity<StringItemForUnsert>()
                .ToTable(GetTableName("StringItemForUnsert"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<StringItemForUnsert>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<StringItemForUnsert>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.StringValue)
                .HasColumnName(GetFieldName("StringItemForUnsert", "StringValue"));
 
            #endregion

            #region ItemForUpdate mappings
            modelBuilder.Entity<ItemForUpdate>()
                .ToTable(GetTableName("ItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<ItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<ItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("ItemForUpdate", "Title"));
 
            #endregion

            #region ItemForInsert mappings
            modelBuilder.Entity<ItemForInsert>()
                .ToTable(GetTableName("ItemForInsert"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<ItemForInsert>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<ItemForInsert>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("ItemForInsert", "Title"));
 
            #endregion

            #region PublishedNotPublishedItem mappings
            modelBuilder.Entity<PublishedNotPublishedItem>()
                .ToTable(GetTableName("PublishedNotPublishedItem"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<PublishedNotPublishedItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<PublishedNotPublishedItem>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("PublishedNotPublishedItem", "Title"));
            modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.Alias)
                .HasColumnName(GetFieldName("PublishedNotPublishedItem", "Alias"));
 
            #endregion

            #region ReplacingPlaceholdersItem mappings
            modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .ToTable(GetTableName("ReplacingPlaceholdersItem"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("ReplacingPlaceholdersItem", "Title"));
 
            #endregion

            #region FileFieldsItem mappings
            modelBuilder.Entity<FileFieldsItem>()
                .ToTable(GetTableName("FileFieldsItem"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<FileFieldsItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<FileFieldsItem>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.FileItem)
                .HasColumnName(GetFieldName("FileFieldsItem", "FileItem"));
            modelBuilder.Entity<FileFieldsItem>().Ignore(p => p.FileItemUrl);
            modelBuilder.Entity<FileFieldsItem>().Ignore(p => p.FileItemUploadPath);
 
            #endregion

            #region SymmetricRelationArticle mappings
            modelBuilder.Entity<SymmetricRelationArticle>()
                .ToTable(GetTableName("SymmetricRelationArticle"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<SymmetricRelationArticle>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<SymmetricRelationArticle>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

 
            #endregion

            #region ToSymmetricRelationAtricle mappings
            modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .ToTable(GetTableName("ToSymmetricRelationAtricle"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 


             modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>()
                .ToTable(GetLinkTableName("ToSymmetricRelationAtricle", "ToSymmetricRelation"));

            modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().Property(e => e.ToSymmetricRelationAtricleItemId).HasColumnName("id");
            modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().Property(e => e.SymmetricRelationArticleLinkedItemId).HasColumnName("linked_id");
            modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().HasKey(ug => new { ug.ToSymmetricRelationAtricleItemId, ug.SymmetricRelationArticleLinkedItemId });

            modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>()
                .HasOne(bc => bc.ToSymmetricRelationAtricleItem)
                .WithMany(b => b.ToSymmetricRelation)
                .HasForeignKey(bc => bc.ToSymmetricRelationAtricleItemId);

            modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>()
                .HasOne(bc => bc.SymmetricRelationArticleLinkedItem)
                .WithMany();
			modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().Ignore(x=>x.Id);
			modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().Ignore(x=>x.Item);
			modelBuilder.Entity<ToSymmetricRelationAtricle2SymmetricRelationArticleForToSymmetricRelation>().Ignore(x=>x.LinkedItem);

			 modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>()
                .ToTable(GetReversedLinkTableName("ToSymmetricRelationAtricle", "ToSymmetricRelation"));
      

			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().Property(e => e.ToSymmetricRelationAtricleLinkedItemId).HasColumnName("linked_id");
			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().Property(e => e.SymmetricRelationArticleItemId).HasColumnName("id");
			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().HasKey(ug => new { ug.ToSymmetricRelationAtricleLinkedItemId, ug.SymmetricRelationArticleItemId });
            
			 modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>()
                .HasOne(bc => bc.SymmetricRelationArticleItem)
                .WithMany(b => b.SymmetricRelation)
                .HasForeignKey(bc => bc.SymmetricRelationArticleItemId);

            modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>()
                .HasOne(bc => bc.ToSymmetricRelationAtricleLinkedItem)
                .WithMany();

			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().Ignore(x=>x.Id);
			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().Ignore(x=>x.Item);
			modelBuilder.Entity<SymmetricRelationArticle2ToSymmetricRelationAtricleForSymmetricRelation>().Ignore(x=>x.LinkedItem);
 
            #endregion

            #region MtMItemForUpdate mappings
            modelBuilder.Entity<MtMItemForUpdate>()
                .ToTable(GetTableName("MtMItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<MtMItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<MtMItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("MtMItemForUpdate", "Title"));

             modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>()
                .ToTable(GetLinkTableName("MtMItemForUpdate", "Reference"));

            modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().Property(e => e.MtMItemForUpdateItemId).HasColumnName("id");
            modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().Property(e => e.MtMDictionaryForUpdateLinkedItemId).HasColumnName("linked_id");
            modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().HasKey(ug => new { ug.MtMItemForUpdateItemId, ug.MtMDictionaryForUpdateLinkedItemId });

            modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>()
                .HasOne(bc => bc.MtMItemForUpdateItem)
                .WithMany(b => b.Reference)
                .HasForeignKey(bc => bc.MtMItemForUpdateItemId);

            modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>()
                .HasOne(bc => bc.MtMDictionaryForUpdateLinkedItem)
                .WithMany();
			modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().Ignore(x=>x.Id);
			modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().Ignore(x=>x.Item);
			modelBuilder.Entity<MtMItemForUpdate2MtMDictionaryForUpdateForReference>().Ignore(x=>x.LinkedItem);

			 modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >()
                .ToTable(GetReversedLinkTableName("MtMItemForUpdate", "Reference"));
      

			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().Property(e => e.MtMItemForUpdateLinkedItemId).HasColumnName("linked_id");
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().Property(e => e.MtMDictionaryForUpdateItemId).HasColumnName("id");
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().HasKey(ug => new { ug.MtMItemForUpdateLinkedItemId, ug.MtMDictionaryForUpdateItemId });
            
			 modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >()
                .HasOne(bc => bc.MtMDictionaryForUpdateItem)
                .WithMany(b => b.BackwardForReference_MtMItemForUpdate )
                .HasForeignKey(bc => bc.MtMDictionaryForUpdateItemId);

            modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >()
                .HasOne(bc => bc.MtMItemForUpdateLinkedItem)
                .WithMany();

			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().Ignore(x=>x.Id);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().Ignore(x=>x.LinkId);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().Ignore(x=>x.Item);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference_MtMItemForUpdate >().Ignore(x=>x.LinkedItem);
 
            #endregion

            #region MtMDictionaryForUpdate mappings
            modelBuilder.Entity<MtMDictionaryForUpdate>()
                .ToTable(GetTableName("MtMDictionaryForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<MtMDictionaryForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<MtMDictionaryForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("MtMDictionaryForUpdate", "Title"));
 
            #endregion

            #region OtMItemForUpdate mappings
            modelBuilder.Entity<OtMItemForUpdate>()
                .ToTable(GetTableName("OtMItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<OtMItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<OtMItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("OtMItemForUpdate", "Title"));
            modelBuilder.Entity<OtMItemForUpdate>()
                .HasOne<OtMDictionaryForUpdate>(mp => mp.Reference)
                .WithMany(mp => mp.BackReference)
                .HasForeignKey(fp => fp.Reference_ID);

            modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.Reference_ID)
                .HasColumnName(GetFieldName("OtMItemForUpdate", "Reference").ToLowerInvariant());
 
            #endregion

            #region OtMDictionaryForUpdate mappings
            modelBuilder.Entity<OtMDictionaryForUpdate>()
                .ToTable(GetTableName("OtMDictionaryForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<OtMDictionaryForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<OtMDictionaryForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("OtMDictionaryForUpdate", "Title"));
 
            #endregion

            #region DateItemForUpdate mappings
            modelBuilder.Entity<DateItemForUpdate>()
                .ToTable(GetTableName("DateItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<DateItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<DateItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.DateValueField)
                .HasColumnName(GetFieldName("DateItemForUpdate", "DateValueField"));
 
            #endregion

            #region TimeItemForUpdate mappings
            modelBuilder.Entity<TimeItemForUpdate>()
                .ToTable(GetTableName("TimeItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<TimeItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<TimeItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.TimeValueField)
                .HasColumnName(GetFieldName("TimeItemForUpdate", "TimeValueField"));
 
            #endregion

            #region DateTimeItemForUpdate mappings
            modelBuilder.Entity<DateTimeItemForUpdate>()
                .ToTable(GetTableName("DateTimeItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<DateTimeItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<DateTimeItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.DateTimeValueField)
                .HasColumnName(GetFieldName("DateTimeItemForUpdate", "DateTimeValueField"));
 
            #endregion

            #region FileItemForUpdate mappings
            modelBuilder.Entity<FileItemForUpdate>()
                .ToTable(GetTableName("FileItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<FileItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<FileItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.FileValueField)
                .HasColumnName(GetFieldName("FileItemForUpdate", "FileValueField"));
            modelBuilder.Entity<FileItemForUpdate>().Ignore(p => p.FileValueFieldUrl);
            modelBuilder.Entity<FileItemForUpdate>().Ignore(p => p.FileValueFieldUploadPath);
 
            #endregion

            #region ImageItemForUpdate mappings
            modelBuilder.Entity<ImageItemForUpdate>()
                .ToTable(GetTableName("ImageItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<ImageItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<ImageItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.ImageValueField)
                .HasColumnName(GetFieldName("ImageItemForUpdate", "ImageValueField"));
            modelBuilder.Entity<ImageItemForUpdate>().Ignore(p => p.ImageValueFieldUrl);
            modelBuilder.Entity<ImageItemForUpdate>().Ignore(p => p.ImageValueFieldUploadPath);
 
            #endregion

            #region OtMItemForMapping mappings
            modelBuilder.Entity<OtMItemForMapping>()
                .ToTable(GetTableName("OtMItemForMapping"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<OtMItemForMapping>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<OtMItemForMapping>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<OtMItemForMapping>()
                .HasOne<OtMRelatedItemWithMapping>(mp => mp.OtMReferenceMapping)
                .WithMany(mp => mp.BackOtMReferenceMapping)
                .HasForeignKey(fp => fp.OtMReferenceMapping_ID);

            modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.OtMReferenceMapping_ID)
                .HasColumnName(GetFieldName("OtMItemForMapping", "OtMReferenceMapping").ToLowerInvariant());
 
            #endregion

            #region OtMRelatedItemWithMapping mappings
            modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .ToTable(GetTableName("OtMRelatedItemWithMapping"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

 
            #endregion

            #region OtMItemToContentWithoutMapping mappings
            modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .ToTable(GetTableName("OtMItemToContentWithoutMapping"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.OtMReferenceMapping_ID)
                .HasColumnName(GetFieldName("OtMItemToContentWithoutMapping", "OtMReferenceMapping_ID"));
 
            #endregion

            #region BooleanItemForUpdate mappings
            modelBuilder.Entity<BooleanItemForUpdate>()
                .ToTable(GetTableName("BooleanItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<BooleanItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<BooleanItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<BooleanItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<BooleanItemForUpdate>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<BooleanItemForUpdate>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<BooleanItemForUpdate>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<BooleanItemForUpdate>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<BooleanItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

 
            #endregion

            #region OtMItemForUpdateVirtual mappings
            modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .ToTable(GetTableName("OtMItemForUpdateVirtual"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("OtMItemForUpdateVirtual", "Title"));
            modelBuilder.Entity<OtMItemForUpdateVirtual>()
                .Property(x => x.Reference_ID)
                .HasColumnName(GetFieldName("OtMItemForUpdateVirtual", "Reference_ID"));
 
            #endregion
			AddMappingInfo(modelBuilder.Model);
        }
    }
}
