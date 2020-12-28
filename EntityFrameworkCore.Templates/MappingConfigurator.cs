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
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Regions)
                .WithMany(e => e.BackwardForRegions_Product)
                .UsingEntity<Product2RegionForRegions>(
                bc => bc
                    .HasOne(c => c.RegionLinkedItem)
                    .WithMany()
                    .HasForeignKey(c => c.RegionLinkedItemId),
                bc => bc
                    .HasOne(c => c.ProductItem)
                    .WithMany(),
                bc => 
                { 
                    bc.Property(e => e.ProductItemId).HasColumnName("id");
                    bc.Property(e => e.RegionLinkedItemId).HasColumnName("linked_id");
                    bc.HasKey(ug => new { ug.ProductItemId, ug.RegionLinkedItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetLinkTableName("Product", "Regions"));
                });
            
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Regions)
                .WithMany(e => e.BackwardForRegions_Product)
                .UsingEntity<Region2ProductForBackwardForRegions_Product>(
                bc => bc
                    .HasOne(c => c.RegionItem)
                    .WithMany()
                    .HasForeignKey(c => c.RegionItemId),
                bc => bc
                    .HasOne(c => c.ProductLinkedItem)
                    .WithMany(),
                bc => 
                { 
                    bc.Property(e => e.ProductLinkedItemId).HasColumnName("linked_id");
                    bc.Property(e => e.RegionItemId).HasColumnName("id");
                    bc.HasKey(ug => new { ug.ProductLinkedItemId, ug.RegionItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetReversedLinkTableName("Product", "Regions"));
                });

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
            modelBuilder.Entity<Region>()
                .HasMany(e => e.AllowedRegions)
                .WithMany(e => e.BackwardForAllowedRegions_Region)
                .UsingEntity<Region2RegionForAllowedRegions>(
                bc => bc
                    .HasOne(c => c.RegionLinkedItem)
                    .WithMany()
                    .HasForeignKey(c => c.RegionLinkedItemId),
                bc => bc
                    .HasOne(c => c.RegionItem)
                    .WithMany(),
                bc => 
                { 
                    bc.Property(e => e.RegionItemId).HasColumnName("id");
                    bc.Property(e => e.RegionLinkedItemId).HasColumnName("linked_id");
                    bc.HasKey(ug => new { ug.RegionItemId, ug.RegionLinkedItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetLinkTableName("Region", "AllowedRegions"));
                });
            
            modelBuilder.Entity<Region>()
                .HasMany(e => e.AllowedRegions)
                .WithMany(e => e.BackwardForAllowedRegions_Region)
                .UsingEntity<Region2RegionForBackwardForAllowedRegions_Region>(
                bc => bc
                    .HasOne(c => c.RegionItem)
                    .WithMany()
                    .HasForeignKey(c => c.RegionItemId),
                bc => bc
                    .HasOne(c => c.RegionLinkedItem)
                    .WithMany(),
                bc => 
                { 
			        bc.Property(e => e.RegionLinkedItemId).HasColumnName("id");
			        bc.Property(e => e.RegionItemId).HasColumnName("linked_id");
           
                    bc.HasKey(ug => new { ug.RegionLinkedItemId, ug.RegionItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetReversedLinkTableName("Region", "AllowedRegions"));
                });

            modelBuilder.Entity<Region>()
                .HasMany(e => e.DeniedRegions)
                .WithMany(e => e.BackwardForDeniedRegions_Region)
                .UsingEntity<Region2RegionForDeniedRegions>(
                bc => bc
                    .HasOne(c => c.RegionLinkedItem)
                    .WithMany()
                    .HasForeignKey(c => c.RegionLinkedItemId),
                bc => bc
                    .HasOne(c => c.RegionItem)
                    .WithMany(),
                bc => 
                { 
                    bc.Property(e => e.RegionItemId).HasColumnName("id");
                    bc.Property(e => e.RegionLinkedItemId).HasColumnName("linked_id");
                    bc.HasKey(ug => new { ug.RegionItemId, ug.RegionLinkedItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetLinkTableName("Region", "DeniedRegions"));
                });
            
            modelBuilder.Entity<Region>()
                .HasMany(e => e.DeniedRegions)
                .WithMany(e => e.BackwardForDeniedRegions_Region)
                .UsingEntity<Region2RegionForBackwardForDeniedRegions_Region>(
                bc => bc
                    .HasOne(c => c.RegionItem)
                    .WithMany()
                    .HasForeignKey(c => c.RegionItemId),
                bc => bc
                    .HasOne(c => c.RegionLinkedItem)
                    .WithMany(),
                bc => 
                { 
			        bc.Property(e => e.RegionLinkedItemId).HasColumnName("id");
			        bc.Property(e => e.RegionItemId).HasColumnName("linked_id");
           
                    bc.HasKey(ug => new { ug.RegionLinkedItemId, ug.RegionItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetReversedLinkTableName("Region", "DeniedRegions"));
                });

 
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
            modelBuilder.Entity<Setting>()
                .HasMany(e => e.RelatedSettings)
                .WithMany(e => e.BackwardForRelatedSettings_Setting)
                .UsingEntity<Setting2SettingForRelatedSettings>(
                bc => bc
                    .HasOne(c => c.SettingLinkedItem)
                    .WithMany()
                    .HasForeignKey(c => c.SettingLinkedItemId),
                bc => bc
                    .HasOne(c => c.SettingItem)
                    .WithMany(),
                bc => 
                { 
                    bc.Property(e => e.SettingItemId).HasColumnName("id");
                    bc.Property(e => e.SettingLinkedItemId).HasColumnName("linked_id");
                    bc.HasKey(ug => new { ug.SettingItemId, ug.SettingLinkedItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetLinkTableName("Setting", "RelatedSettings"));
                });
            
            modelBuilder.Entity<Setting>()
                .HasMany(e => e.RelatedSettings)
                .WithMany(e => e.BackwardForRelatedSettings_Setting)
                .UsingEntity<Setting2SettingForBackwardForRelatedSettings_Setting>(
                bc => bc
                    .HasOne(c => c.SettingItem)
                    .WithMany()
                    .HasForeignKey(c => c.SettingItemId),
                bc => bc
                    .HasOne(c => c.SettingLinkedItem)
                    .WithMany(),
                bc => 
                { 
			        bc.Property(e => e.SettingLinkedItemId).HasColumnName("id");
			        bc.Property(e => e.SettingItemId).HasColumnName("linked_id");
           
                    bc.HasKey(ug => new { ug.SettingLinkedItemId, ug.SettingItemId });
                    bc.Ignore(x=>x.Id);
                    bc.Ignore(x=>x.LinkId);
                    bc.Ignore(x=>x.LinkedItemId);
                    bc.Ignore(x=>x.Item);
                    bc.Ignore(x=>x.LinkedItem);
                    bc.ToTable(GetReversedLinkTableName("Setting", "RelatedSettings"));
                });

 
            #endregion
			AddMappingInfo(modelBuilder.Model);
        }
    }
}
