using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Quantumart.QP8.CoreCodeGeneration.Services;
using Quantumart.QP8.EFCore.Models;
using Quantumart.QP8.EFCore.Services;


namespace EntityFrameworkCore.Data
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
                .ValueGeneratedOnAdd()
                .HasColumnName("CONTENT_ITEM_ID");
           
		    modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<MarketingProduct>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
 
            #endregion

            #region Product mappings
            modelBuilder.Entity<Product>()
                .ToTable(GetTableName("Product"))
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CONTENT_ITEM_ID");
           
		    modelBuilder.Entity<Product>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<Product>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<Product>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<Product>()
                .Property(x => x.Legal)
                .HasColumnName(GetFieldName("Product", "Legal"));
            modelBuilder.Entity<Product>()
                .Property(x => x.Benefit)
                .HasColumnName(GetFieldName("Product", "Benefit"));
            modelBuilder.Entity<Product>()
                .Property(x => x.MarketingSign_ID)
                .HasColumnName(GetFieldName("Product", "MarketingSign_ID"));
            modelBuilder.Entity<Product>()
                .Property(x => x.ArchiveTitle)
                .HasColumnName(GetFieldName("Product", "ArchiveTitle"));
            modelBuilder.Entity<Product>()
                .Property(x => x.ArchiveNotes)
                .HasColumnName(GetFieldName("Product", "ArchiveNotes"));
            modelBuilder.Entity<Product>()
                .HasOne<MarketingProduct>(mp => mp.MarketingProduct)
                .WithMany(mp => mp.Products)
                .HasForeignKey(fp => fp.MarketingProduct_ID);

            modelBuilder.Entity<Product>()
                .Property(x => x.MarketingProduct_ID)
                .HasColumnName(GetFieldName("Product", "MarketingProduct"));

             modelBuilder.Entity<Product2RegionForRegions>()
                .ToTable(GetLinkTableName("Product", "Regions"));

            modelBuilder.Entity<Product2RegionForRegions>().Property(e => e.ProductItem_ID).HasColumnName("id");
            modelBuilder.Entity<Product2RegionForRegions>().Property(e => e.RegionLinkedItem_ID).HasColumnName("linked_id");
            modelBuilder.Entity<Product2RegionForRegions>().HasKey(ug => new { ug.ProductItem_ID, ug.RegionLinkedItem_ID });

            modelBuilder.Entity<Product2RegionForRegions>()
                .HasOne(bc => bc.ProductItem)
                .WithMany(b => b.Regions)
                .HasForeignKey(bc => bc.ProductItem_ID);

            modelBuilder.Entity<Product2RegionForRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();


			 modelBuilder.Entity<Product2RegionForBackwardForRegions>()
                .ToTable(GetReversedLinkTableName("Product", "Regions"));
      

			modelBuilder.Entity<Product2RegionForBackwardForRegions>().Property(e => e.RegionItem_ID).HasColumnName("linked_id");
			modelBuilder.Entity<Product2RegionForBackwardForRegions>().Property(e => e.ProductLinkedItem_ID).HasColumnName("id");
			modelBuilder.Entity<Product2RegionForBackwardForRegions>().HasKey(ug => new { ug.RegionItem_ID, ug.ProductLinkedItem_ID });
            
			 modelBuilder.Entity<Product2RegionForBackwardForRegions>()
                .HasOne(bc => bc.ProductLinkedItem)
                .WithMany(b => b.BackwardForRegions)
                .HasForeignKey(bc => bc.ProductLinkedItem_ID);

            modelBuilder.Entity<Product2RegionForBackwardForRegions>()
                .HasOne(bc => bc.RegionItem)
                .WithMany();

            modelBuilder.Entity<Product>().Ignore(p => p.PDFUrl);
            modelBuilder.Entity<Product>().Ignore(p => p.PDFUploadPath);
 
            #endregion

            #region ProductParameter mappings
            modelBuilder.Entity<ProductParameter>()
                .ToTable(GetTableName("ProductParameter"))
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CONTENT_ITEM_ID");
           
		    modelBuilder.Entity<ProductParameter>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<ProductParameter>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Title)
                .HasColumnName(GetFieldName("ProductParameter", "Title"));
            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Group_ID)
                .HasColumnName(GetFieldName("ProductParameter", "Group_ID"));
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
                .HasOne<Product>(mp => mp.Product)
                .WithMany(mp => mp.Parameters)
                .HasForeignKey(fp => fp.Product_ID);

            modelBuilder.Entity<ProductParameter>()
                .Property(x => x.Product_ID)
                .HasColumnName(GetFieldName("ProductParameter", "Product"));
 
            #endregion

            #region Region mappings
            modelBuilder.Entity<Region>()
                .ToTable(GetTableName("Region"))
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CONTENT_ITEM_ID");
           
		    modelBuilder.Entity<Region>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<Region>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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
                .HasOne<Region>(mp => mp.Parent)
                .WithMany(mp => mp.Children)
                .HasForeignKey(fp => fp.Parent_ID);

            modelBuilder.Entity<Region>()
                .Property(x => x.Parent_ID)
                .HasColumnName(GetFieldName("Region", "Parent"));

             modelBuilder.Entity<Region2RegionForAllowedRegions>()
                .ToTable(GetLinkTableName("Region", "AllowedRegions"));

            modelBuilder.Entity<Region2RegionForAllowedRegions>().Property(e => e.RegionItem_ID).HasColumnName("id");
            modelBuilder.Entity<Region2RegionForAllowedRegions>().Property(e => e.RegionLinkedItem_ID).HasColumnName("linked_id");
            modelBuilder.Entity<Region2RegionForAllowedRegions>().HasKey(ug => new { ug.RegionItem_ID, ug.RegionLinkedItem_ID });

            modelBuilder.Entity<Region2RegionForAllowedRegions>()
                .HasOne(bc => bc.RegionItem)
                .WithMany(b => b.AllowedRegions)
                .HasForeignKey(bc => bc.RegionItem_ID);

            modelBuilder.Entity<Region2RegionForAllowedRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();


			 modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions>()
                .ToTable(GetReversedLinkTableName("Region", "AllowedRegions"));
      

			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions>().Property(e => e.RegionItem_ID).HasColumnName("id");
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions>().Property(e => e.RegionLinkedItem_ID).HasColumnName("linked_id");
           
			modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions>().HasKey(ug => new { ug.RegionItem_ID, ug.RegionLinkedItem_ID });
            
			 modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany(b => b.BackwardForAllowedRegions)
                .HasForeignKey(bc => bc.RegionLinkedItem_ID);

            modelBuilder.Entity<Region2RegionForBackwardForAllowedRegions>()
                .HasOne(bc => bc.RegionItem)
                .WithMany();


             modelBuilder.Entity<Region2RegionForDeniedRegions>()
                .ToTable(GetLinkTableName("Region", "DeniedRegions"));

            modelBuilder.Entity<Region2RegionForDeniedRegions>().Property(e => e.RegionItem_ID).HasColumnName("id");
            modelBuilder.Entity<Region2RegionForDeniedRegions>().Property(e => e.RegionLinkedItem_ID).HasColumnName("linked_id");
            modelBuilder.Entity<Region2RegionForDeniedRegions>().HasKey(ug => new { ug.RegionItem_ID, ug.RegionLinkedItem_ID });

            modelBuilder.Entity<Region2RegionForDeniedRegions>()
                .HasOne(bc => bc.RegionItem)
                .WithMany(b => b.DeniedRegions)
                .HasForeignKey(bc => bc.RegionItem_ID);

            modelBuilder.Entity<Region2RegionForDeniedRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany();


			 modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions>()
                .ToTable(GetReversedLinkTableName("Region", "DeniedRegions"));
      

			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions>().Property(e => e.RegionItem_ID).HasColumnName("id");
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions>().Property(e => e.RegionLinkedItem_ID).HasColumnName("linked_id");
           
			modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions>().HasKey(ug => new { ug.RegionItem_ID, ug.RegionLinkedItem_ID });
            
			 modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions>()
                .HasOne(bc => bc.RegionLinkedItem)
                .WithMany(b => b.BackwardForDeniedRegions)
                .HasForeignKey(bc => bc.RegionLinkedItem_ID);

            modelBuilder.Entity<Region2RegionForBackwardForDeniedRegions>()
                .HasOne(bc => bc.RegionItem)
                .WithMany();

 
            #endregion

            #region MobileTariff mappings
            modelBuilder.Entity<MobileTariff>()
                .ToTable(GetTableName("MobileTariff"))
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CONTENT_ITEM_ID");
           
		    modelBuilder.Entity<MobileTariff>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<MobileTariff>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

			modelBuilder.Entity<MobileTariff>()
                .HasOne<StatusType>(x => x.StatusType)
                .WithMany()
				.IsRequired()
                .HasForeignKey(x => x.StatusTypeId); 

            modelBuilder.Entity<MobileTariff>()
                .HasOne<Product>(mp => mp.Product)
                .WithMany(mp => mp.MobileTariffs)
                .HasForeignKey(fp => fp.Product_ID);

            modelBuilder.Entity<MobileTariff>()
                .Property(x => x.Product_ID)
                .HasColumnName(GetFieldName("MobileTariff", "Product"));
 
            #endregion

            #region Setting mappings
            modelBuilder.Entity<Setting>()
                .ToTable(GetTableName("Setting"))
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CONTENT_ITEM_ID");
           
		    modelBuilder.Entity<Setting>()
                .Property(x => x.LastModifiedBy)
                .HasColumnName("LAST_MODIFIED_BY");
            
            modelBuilder.Entity<Setting>()
                .Property(x => x.StatusTypeId)
                .HasColumnName("STATUS_TYPE_ID");

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

             modelBuilder.Entity<Setting2SettingForRelatedSettings>()
                .ToTable(GetLinkTableName("Setting", "RelatedSettings"));

            modelBuilder.Entity<Setting2SettingForRelatedSettings>().Property(e => e.SettingItem_ID).HasColumnName("id");
            modelBuilder.Entity<Setting2SettingForRelatedSettings>().Property(e => e.SettingLinkedItem_ID).HasColumnName("linked_id");
            modelBuilder.Entity<Setting2SettingForRelatedSettings>().HasKey(ug => new { ug.SettingItem_ID, ug.SettingLinkedItem_ID });

            modelBuilder.Entity<Setting2SettingForRelatedSettings>()
                .HasOne(bc => bc.SettingItem)
                .WithMany(b => b.RelatedSettings)
                .HasForeignKey(bc => bc.SettingItem_ID);

            modelBuilder.Entity<Setting2SettingForRelatedSettings>()
                .HasOne(bc => bc.SettingLinkedItem)
                .WithMany();


			 modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings>()
                .ToTable(GetReversedLinkTableName("Setting", "RelatedSettings"));
      

			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings>().Property(e => e.SettingItem_ID).HasColumnName("id");
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings>().Property(e => e.SettingLinkedItem_ID).HasColumnName("linked_id");
           
			modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings>().HasKey(ug => new { ug.SettingItem_ID, ug.SettingLinkedItem_ID });
            
			 modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings>()
                .HasOne(bc => bc.SettingLinkedItem)
                .WithMany(b => b.BackwardForRelatedSettings)
                .HasForeignKey(bc => bc.SettingLinkedItem_ID);

            modelBuilder.Entity<Setting2SettingForBackwardForRelatedSettings>()
                .HasOne(bc => bc.SettingItem)
                .WithMany();

 
            #endregion
			AddMappingInfo(modelBuilder.Model);
        }
    }
}
