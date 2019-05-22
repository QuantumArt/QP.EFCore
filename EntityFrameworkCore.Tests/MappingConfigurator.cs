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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<AfiellFieldsItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<AfiellFieldsItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<Schema>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<Schema>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<Schema>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<StringItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<StringItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<StringItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<StringItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<StringItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<StringItemForUnsert>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<StringItemForUnsert>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<ItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<ItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<ItemForInsert>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<ItemForInsert>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<PublishedNotPublishedItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<PublishedNotPublishedItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<ReplacingPlaceholdersItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<FileFieldsItem>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<FileFieldsItem>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<FileFieldsItem>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<FileFieldsItem>().Ignore(p => p.FileItemUrl);
            modelBuilder.Entity<FileFieldsItem>().Ignore(p => p.FileItemUploadPath);
 
            #endregion

            #region SymmetricRelationArticle mappings
            modelBuilder.Entity<SymmetricRelationArticle>()
                .ToTable(GetTableName("SymmetricRelationArticle"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<SymmetricRelationArticle>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<SymmetricRelationArticle>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<ToSymmetricRelationAtricle>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<MtMItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<MtMItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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

			 modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>()
                .ToTable(GetReversedLinkTableName("MtMItemForUpdate", "Reference"));
      

			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().Property(e => e.MtMItemForUpdateLinkedItemId).HasColumnName("linked_id");
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().Property(e => e.MtMDictionaryForUpdateItemId).HasColumnName("id");
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().HasKey(ug => new { ug.MtMItemForUpdateLinkedItemId, ug.MtMDictionaryForUpdateItemId });
            
			 modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>()
                .HasOne(bc => bc.MtMDictionaryForUpdateItem)
                .WithMany(b => b.BackwardForReference)
                .HasForeignKey(bc => bc.MtMDictionaryForUpdateItemId);

            modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>()
                .HasOne(bc => bc.MtMItemForUpdateLinkedItem)
                .WithMany();

			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().Ignore(x=>x.Id);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().Ignore(x=>x.Item);
			modelBuilder.Entity<MtMDictionaryForUpdate2MtMItemForUpdateForBackwardForReference>().Ignore(x=>x.LinkedItem);
 
            #endregion

            #region MtMDictionaryForUpdate mappings
            modelBuilder.Entity<MtMDictionaryForUpdate>()
                .ToTable(GetTableName("MtMDictionaryForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<MtMDictionaryForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<MtMDictionaryForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<OtMItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<OtMItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName(GetFieldName("OtMItemForUpdate", "Reference"));
 
            #endregion

            #region OtMDictionaryForUpdate mappings
            modelBuilder.Entity<OtMDictionaryForUpdate>()
                .ToTable(GetTableName("OtMDictionaryForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<OtMDictionaryForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<OtMDictionaryForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<DateItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<DateItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<DateItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

 
            #endregion

            #region TimeItemForUpdate mappings
            modelBuilder.Entity<TimeItemForUpdate>()
                .ToTable(GetTableName("TimeItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<TimeItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<TimeItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<TimeItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

 
            #endregion

            #region DateTimeItemForUpdate mappings
            modelBuilder.Entity<DateTimeItemForUpdate>()
                .ToTable(GetTableName("DateTimeItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<DateTimeItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<DateTimeItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<DateTimeItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

 
            #endregion

            #region FileItemForUpdate mappings
            modelBuilder.Entity<FileItemForUpdate>()
                .ToTable(GetTableName("FileItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<FileItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<FileItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<FileItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<FileItemForUpdate>().Ignore(p => p.FileValueFieldUrl);
            modelBuilder.Entity<FileItemForUpdate>().Ignore(p => p.FileValueFieldUploadPath);
 
            #endregion

            #region ImageItemForUpdate mappings
            modelBuilder.Entity<ImageItemForUpdate>()
                .ToTable(GetTableName("ImageItemForUpdate"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<ImageItemForUpdate>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<ImageItemForUpdate>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<ImageItemForUpdate>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<ImageItemForUpdate>().Ignore(p => p.ImageValueFieldUrl);
            modelBuilder.Entity<ImageItemForUpdate>().Ignore(p => p.ImageValueFieldUploadPath);
 
            #endregion

            #region OtMItemForMapping mappings
            modelBuilder.Entity<OtMItemForMapping>()
                .ToTable(GetTableName("OtMItemForMapping"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<OtMItemForMapping>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<OtMItemForMapping>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName(GetFieldName("OtMItemForMapping", "OtMReferenceMapping"));
 
            #endregion

            #region OtMRelatedItemWithMapping mappings
            modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .ToTable(GetTableName("OtMRelatedItemWithMapping"))
                .Property(x => x.Id)
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<OtMRelatedItemWithMapping>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasColumnName("CONTENT_ITEM_ID");

			 modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<OtMItemToContentWithoutMapping>()
                .Property(x => x.OtMReferenceMapping_ID)
                .HasColumnName(GetFieldName("OtMItemToContentWithoutMapping", "OtMReferenceMapping_ID"));
 
            #endregion
			AddMappingInfo(modelBuilder.Model);
        }
    }
}
