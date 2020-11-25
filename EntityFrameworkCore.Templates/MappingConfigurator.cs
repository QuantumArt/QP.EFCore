using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Quantumart.QP8.CoreCodeGeneration.Services;

/* place your custom usings here */

namespace EntityFrameworkCore.Templates
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

            #region MarketingProduct mappings
            modelBuilder.Entity<MarketingProduct>()
                .ToTable(GetTableName("MarketingProduct"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<MarketingProduct>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<MarketingProduct>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("MarketingProduct", "Title"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Alias)
                .HasColumnName(GetFieldName("MarketingProduct", "Alias"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.ProductType)
                .HasColumnName(GetFieldName("MarketingProduct", "ProductType"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Benefit)
                .HasColumnName(GetFieldName("MarketingProduct", "Benefit"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.ShortBenefit)
                .HasColumnName(GetFieldName("MarketingProduct", "ShortBenefit"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Legal)
                .HasColumnName(GetFieldName("MarketingProduct", "Legal"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Description)
                .HasColumnName(GetFieldName("MarketingProduct", "Description"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.ShortDescription)
                .HasColumnName(GetFieldName("MarketingProduct", "ShortDescription"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Purpose)
                .HasColumnName(GetFieldName("MarketingProduct", "Purpose"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.Family_ID)
                .HasColumnName(GetFieldName("MarketingProduct", "Family_ID"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.TitleForFamily)
                .HasColumnName(GetFieldName("MarketingProduct", "TitleForFamily"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.CommentForFamily)
                .HasColumnName(GetFieldName("MarketingProduct", "CommentForFamily"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.MarketingSign_ID)
                .HasColumnName(GetFieldName("MarketingProduct", "MarketingSign_ID"));
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.OldSiteId)
                .HasColumnName(GetFieldName("MarketingProduct", "OldSiteId"));
 
            #endregion

            #region Product mappings
            modelBuilder.Entity<Product>()
                .ToTable(GetTableName("Product"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<Product>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<Product>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<Product>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<Product>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<Product>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<Product>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<Product>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<Product>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<Product>()
                .Property(x => x.Type)
                .HasColumnName(GetFieldName("Product", "Type"));
            modelBuilder.Entity<Product>()
                .Property(x => x.PDF)
                .HasColumnName(GetFieldName("Product", "PDF"));
            modelBuilder.Entity<Product>()
                .Property(x => x.Legal)
                .HasColumnName(GetFieldName("Product", "Legal"));
            modelBuilder.Entity<Product>()
                .Property(x => x.Benefit)
                .HasColumnName(GetFieldName("Product", "Benefit"));
            modelBuilder.Entity<Product>()
                .Property(x => x.SortOrder)
                .HasColumnName(GetFieldName("Product", "SortOrder"));
            modelBuilder.Entity<Product>()
                .Property(x => x.MarketingSign_ID)
                .HasColumnName(GetFieldName("Product", "MarketingSign_ID"));
            modelBuilder.Entity<Product>()
                .Property(x => x.StartDate)
                .HasColumnName(GetFieldName("Product", "StartDate"));
            modelBuilder.Entity<Product>()
                .Property(x => x.EndDate)
                .HasColumnName(GetFieldName("Product", "EndDate"));
            modelBuilder.Entity<Product>()
                .Property(x => x.ArchiveTitle)
                .HasColumnName(GetFieldName("Product", "ArchiveTitle"));
            modelBuilder.Entity<Product>()
                .Property(x => x.ArchiveNotes)
                .HasColumnName(GetFieldName("Product", "ArchiveNotes"));
            modelBuilder.Entity<Product>()
                .Property(x => x.OldSiteId)
                .HasColumnName(GetFieldName("Product", "OldSiteId"));
            modelBuilder.Entity<Product>()
                .HasOne<MarketingProduct>(mp => mp.MarketingProduct)
                .WithMany(mp => mp.Products)
                .HasForeignKey(fp => fp.MarketingProduct_ID);

            modelBuilder.Entity<Product>()
                .Property(x => x.MarketingProduct_ID)
                .HasColumnName(GetFieldName("Product", "MarketingProduct").ToLowerInvariant());

             modelBuilder.Entity<Product2RegionForRegions>()
                .ToTable(GetLinkTableName("Product", "Regions"));

            modelBuilder.Entity<Product2RegionForRegions>().Property(e => e.ProductItemId).HasColumnName("id");
            modelBuilder.Entity<Product2RegionForRegions>().Property(e => e.RegionLinkedItemId).HasColumnName("linked_id");
            modelBuilder.Entity<Product2RegionForRegions>().HasKey(ug => new { ug.ProductItemId, ug.RegionLinkedItemId });

            modelBuilder.Entity<Product2RegionForRegions>()
                .HasOne(bc => bc.ProductItem)
                .WithMany(b => b.Regions)
                .HasForeignKey(bc => bc.ProductItemId);

            modelBuilder.Entity<Product2RegionForRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();
			modelBuilder.Entity<Product2RegionForRegions>().Ignore(x=>x.Id);
			modelBuilder.Entity<Product2RegionForRegions>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Product2RegionForRegions>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Product2RegionForRegions>().Ignore(x=>x.Item);
			modelBuilder.Entity<Product2RegionForRegions>().Ignore(x=>x.LinkedItem);

			 modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>()
                .ToTable(GetReversedLinkTableName("Product", "Regions"));
      

			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().Property(e => e.ProductLinkedItemId).HasColumnName("linked_id");
			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().Property(e => e.RegionItemId).HasColumnName("id");
			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().HasKey(ug => new { ug.ProductLinkedItemId, ug.RegionItemId });
            
			 modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>()
                .HasOne(bc => bc.RegionItem)
                .WithMany(b => b.BackwardForRegions_Product)
                .HasForeignKey(bc => bc.RegionItemId);

            modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>()
                .HasOne(bc => bc.ProductLinkedItem)
                .WithMany();

			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().Ignore(x=>x.Id);
			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().Ignore(x=>x.Item);
			modelBuilder.Entity<Region2ProductForBackwardForRegions_Product>().Ignore(x=>x.LinkedItem);
            modelBuilder.Entity<Product>().Ignore(p => p.PDFUrl);
            modelBuilder.Entity<Product>().Ignore(p => p.PDFUploadPath);
 
            #endregion

            #region ProductParameter mappings
            modelBuilder.Entity<ProductParameter>()
                .ToTable(GetTableName("ProductParameter"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<ProductParameter>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<ProductParameter>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<ProductParameter>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("ProductParameter", "Title"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.GroupMapped_ID)
                .HasColumnName(GetFieldName("ProductParameter", "GroupMapped_ID"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.BaseParameter_ID)
                .HasColumnName(GetFieldName("ProductParameter", "BaseParameter_ID"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Zone_ID)
                .HasColumnName(GetFieldName("ProductParameter", "Zone_ID"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Direction_ID)
                .HasColumnName(GetFieldName("ProductParameter", "Direction_ID"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.SortOrder)
                .HasColumnName(GetFieldName("ProductParameter", "SortOrder"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.NumValue)
                .HasColumnName(GetFieldName("ProductParameter", "NumValue"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Value)
                .HasColumnName(GetFieldName("ProductParameter", "Value"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Unit_ID)
                .HasColumnName(GetFieldName("ProductParameter", "Unit_ID"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Legal)
                .HasColumnName(GetFieldName("ProductParameter", "Legal"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.ShortTitle)
                .HasColumnName(GetFieldName("ProductParameter", "ShortTitle"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.ShortValue)
                .HasColumnName(GetFieldName("ProductParameter", "ShortValue"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.MatrixParameter_ID)
                .HasColumnName(GetFieldName("ProductParameter", "MatrixParameter_ID"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.OldSiteId)
                .HasColumnName(GetFieldName("ProductParameter", "OldSiteId"));
            modelBuilder.Entity<ProductParameter>()
                .HasOne<Product>(mp => mp.Product)
                .WithMany(mp => mp.Parameters)
                .HasForeignKey(fp => fp.Product_ID);

            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Product_ID)
                .HasColumnName(GetFieldName("ProductParameter", "Product").ToLowerInvariant());
 
            #endregion

            #region Region mappings
            modelBuilder.Entity<Region>()
                .ToTable(GetTableName("Region"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<Region>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<Region>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<Region>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<Region>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<Region>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<Region>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<Region>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<Region>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<Region>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("Region", "Title"));
            modelBuilder.Entity<Region>()
                .Property(x => x.Alias)
                .HasColumnName(GetFieldName("Region", "Alias"));
            modelBuilder.Entity<Region>()
                .Property(x => x.OldSiteId)
                .HasColumnName(GetFieldName("Region", "OldSiteId"));
            modelBuilder.Entity<Region>()
                .HasOne<Region>(mp => mp.Parent)
                .WithMany(mp => mp.Children)
                .HasForeignKey(fp => fp.Parent_ID);

            modelBuilder.Entity<Region>()
                .Property(x => x.Parent_ID)
                .HasColumnName(GetFieldName("Region", "Parent").ToLowerInvariant());

             modelBuilder.Entity<Region2RegionForAllowedRegions>()
                .ToTable(GetLinkTableName("Region", "AllowedRegions"));

            modelBuilder.Entity<Region2RegionForAllowedRegions>().Property(e => e.RegionItemId).HasColumnName("id");
            modelBuilder.Entity<Region2RegionForAllowedRegions>().Property(e => e.RegionLinkedItemId).HasColumnName("linked_id");
            modelBuilder.Entity<Region2RegionForAllowedRegions>().HasKey(ug => new { ug.RegionItemId, ug.RegionLinkedItemId });

            modelBuilder.Entity<Region2RegionForAllowedRegions>()
                .HasOne(bc => bc.RegionItem)
                .WithMany(b => b.AllowedRegions)
                .HasForeignKey(bc => bc.RegionItemId);

            modelBuilder.Entity<Region2RegionForAllowedRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();
			modelBuilder.Entity<Region2RegionForAllowedRegions>().Ignore(x=>x.Id);
			modelBuilder.Entity<Region2RegionForAllowedRegions>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Region2RegionForAllowedRegions>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Region2RegionForAllowedRegions>().Ignore(x=>x.Item);
			modelBuilder.Entity<Region2RegionForAllowedRegions>().Ignore(x=>x.LinkedItem);

			 modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>()
                .ToTable(GetReversedLinkTableName("Region", "AllowedRegions"));
      

			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().Property(e => e.RegionLinkedItemId).HasColumnName("id");
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().Property(e => e.RegionItemId).HasColumnName("linked_id");
           
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().HasKey(ug => new { ug.RegionLinkedItemId, ug.RegionItemId });
            
			 modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>()
                .HasOne(bc => bc.RegionItem)
                .WithMany(b => b.BackwardForAllowedRegions_Region)
                .HasForeignKey(bc => bc.RegionItemId);

            modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();

			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().Ignore(x=>x.Id);
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().Ignore(x=>x.Item);
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions_Region>().Ignore(x=>x.LinkedItem);

             modelBuilder.Entity<Region2RegionForDeniedRegions>()
                .ToTable(GetLinkTableName("Region", "DeniedRegions"));

            modelBuilder.Entity<Region2RegionForDeniedRegions>().Property(e => e.RegionItemId).HasColumnName("id");
            modelBuilder.Entity<Region2RegionForDeniedRegions>().Property(e => e.RegionLinkedItemId).HasColumnName("linked_id");
            modelBuilder.Entity<Region2RegionForDeniedRegions>().HasKey(ug => new { ug.RegionItemId, ug.RegionLinkedItemId });

            modelBuilder.Entity<Region2RegionForDeniedRegions>()
                .HasOne(bc => bc.RegionItem)
                .WithMany(b => b.DeniedRegions)
                .HasForeignKey(bc => bc.RegionItemId);

            modelBuilder.Entity<Region2RegionForDeniedRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();
			modelBuilder.Entity<Region2RegionForDeniedRegions>().Ignore(x=>x.Id);
			modelBuilder.Entity<Region2RegionForDeniedRegions>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Region2RegionForDeniedRegions>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Region2RegionForDeniedRegions>().Ignore(x=>x.Item);
			modelBuilder.Entity<Region2RegionForDeniedRegions>().Ignore(x=>x.LinkedItem);

			 modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>()
                .ToTable(GetReversedLinkTableName("Region", "DeniedRegions"));
      

			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().Property(e => e.RegionLinkedItemId).HasColumnName("id");
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().Property(e => e.RegionItemId).HasColumnName("linked_id");
           
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().HasKey(ug => new { ug.RegionLinkedItemId, ug.RegionItemId });
            
			 modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>()
                .HasOne(bc => bc.RegionItem)
                .WithMany(b => b.BackwardForDeniedRegions_Region)
                .HasForeignKey(bc => bc.RegionItemId);

            modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();

			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().Ignore(x=>x.Id);
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().Ignore(x=>x.Item);
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions_Region>().Ignore(x=>x.LinkedItem);
 
            #endregion

            #region MobileTariff mappings
            modelBuilder.Entity<MobileTariff>()
                .ToTable(GetTableName("MobileTariff"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<MobileTariff>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<MobileTariff>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<MobileTariff>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<MobileTariff>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<MobileTariff>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<MobileTariff>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<MobileTariff>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<MobileTariff>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<MobileTariff>()
                .Property(x => x.SplitInternetDeviceCount)
                .HasColumnName(GetFieldName("MobileTariff", "SplitInternetDeviceCount"));
            modelBuilder.Entity<MobileTariff>()
                .HasOne<Product>(mp => mp.Product)
                .WithMany(mp => mp.MobileTariffs)
                .HasForeignKey(fp => fp.Product_ID);

            modelBuilder.Entity<MobileTariff>()
                .Property(x => x.Product_ID)
                .HasColumnName(GetFieldName("MobileTariff", "Product").ToLowerInvariant());
 
            #endregion

            #region Setting mappings
            modelBuilder.Entity<Setting>()
                .ToTable(GetTableName("Setting"))
                .Property(x => x.Id)
                .HasColumnName("content_item_id");

			 modelBuilder.Entity<Setting>()
                .HasKey(x=>x.Id);
           
		    modelBuilder.Entity<Setting>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("last_modified_by");
            
            modelBuilder.Entity<Setting>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("status_type_id");

			modelBuilder.Entity<Setting>()
                .Property(x => x.Archive)
                .HasColumnName("archive");

			modelBuilder.Entity<Setting>()
                .Property(x => x.Created)
                .HasColumnName("created");

			modelBuilder.Entity<Setting>()
                .Property(x => x.Modified)
                .HasColumnName("modified");

			modelBuilder.Entity<Setting>()
                .Property(x => x.Visible)
                .HasColumnName("visible");

			modelBuilder.Entity<Setting>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<Setting>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("Setting", "Title"));
            modelBuilder.Entity<Setting>()
                .Property(x => x.ValueMapped)
                .HasColumnName(GetFieldName("Setting", "ValueMapped"));
            modelBuilder.Entity<Setting>()
                .Property(x => x.DecimalValue)
                .HasColumnName(GetFieldName("Setting", "DecimalValue"));

             modelBuilder.Entity<Setting2SettingForRelatedSettings>()
                .ToTable(GetLinkTableName("Setting", "RelatedSettings"));

            modelBuilder.Entity<Setting2SettingForRelatedSettings>().Property(e => e.SettingItemId).HasColumnName("id");
            modelBuilder.Entity<Setting2SettingForRelatedSettings>().Property(e => e.SettingLinkedItemId).HasColumnName("linked_id");
            modelBuilder.Entity<Setting2SettingForRelatedSettings>().HasKey(ug => new { ug.SettingItemId, ug.SettingLinkedItemId });

            modelBuilder.Entity<Setting2SettingForRelatedSettings>()
                .HasOne(bc => bc.SettingItem)
                .WithMany(b => b.RelatedSettings)
                .HasForeignKey(bc => bc.SettingItemId);

            modelBuilder.Entity<Setting2SettingForRelatedSettings>()
                .HasOne(bc => bc.SettingLinkedItem)
                .WithMany();
			modelBuilder.Entity<Setting2SettingForRelatedSettings>().Ignore(x=>x.Id);
			modelBuilder.Entity<Setting2SettingForRelatedSettings>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Setting2SettingForRelatedSettings>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Setting2SettingForRelatedSettings>().Ignore(x=>x.Item);
			modelBuilder.Entity<Setting2SettingForRelatedSettings>().Ignore(x=>x.LinkedItem);

			 modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>()
                .ToTable(GetReversedLinkTableName("Setting", "RelatedSettings"));
      

			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().Property(e => e.SettingLinkedItemId).HasColumnName("id");
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().Property(e => e.SettingItemId).HasColumnName("linked_id");
           
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().HasKey(ug => new { ug.SettingLinkedItemId, ug.SettingItemId });
            
			 modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>()
                .HasOne(bc => bc.SettingItem)
                .WithMany(b => b.BackwardForRelatedSettings_Setting)
                .HasForeignKey(bc => bc.SettingItemId);

            modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>()
                .HasOne(bc => bc.SettingLinkedItem)
                .WithMany();

			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().Ignore(x=>x.Id);
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().Ignore(x=>x.LinkId);
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().Ignore(x=>x.LinkedItemId);
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().Ignore(x=>x.Item);
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings_Setting>().Ignore(x=>x.LinkedItem);
 
            #endregion
			AddMappingInfo(modelBuilder.Model);
        }
    }
}
