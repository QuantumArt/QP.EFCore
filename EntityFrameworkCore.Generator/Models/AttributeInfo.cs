using System;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.Models
{
    public class AttributeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MappedName { get; set; }
        public string MappedBackName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public bool IsLong { get; set; }
        public int RelatedContentId { get; set; }
        public int RelatedAttributeId { get; set; }
        public int LinkId { get; set; }
        public int ContentId { get; set; }
        public bool HasM2O { get; set; }
        public string OriginalMappedName { get { return (Type == "O2M" && MappedName != null) ? MappedName + "_ID" : MappedName; } }
        public bool IsRelation { get { return IsO2M || IsM2M || IsM2O; } }
        public bool IsLocalization { get; set; }
        public bool IsO2M { get { return Type == "O2M"; } }
        public bool IsM2M { get { return Type == "M2M"; } }
        public bool IsM2O { get { return Type == "M2O"; } }
        public ContentInfo Content { get; set; }
        public bool GenerateLibraryUrl { get { return this.Type == "Image" || this.Type == "File" || this.Type == "Dynamic Image"; } }
        public bool GenerateUploadPath { get { return this.Type == "Image" || this.Type == "File"; } }
        public bool CanContainPlaceholders
        {
            get
            {
                return this.Type == "Textbox" || this.Type == "String" || this.Type == "VisualEdit";
            }
        }
        public bool IsNullable
        {
            get
            {
                return this.Type == "Numeric" || this.Type == "Datetime" || this.Type == "Boolean";
            }
        }

        public string NetType
        {
            get
            {
                switch (Type)
                {
                    case "Textbox":
                    case "String":
                    case "Image":
                    case "VisualEdit":
                    case "Dynamic Image":
                    case "File":
                        return "string";
                    case "Boolean": return "bool?";
                    case "Numeric":
                        if (IsLong && Size == 0) { return "long?"; }
                        if (Size == 0) { return "int?"; }
                        return IsLong ? "decimal?" : "double?";
                    case "O2M":
                        return "int?";
                    case "DateTime": return "DateTime?";
                    case "Date": return "DateTime?";
                    case "Time": return "TimeSpan?";
                    default: throw new NotSupportedException("Type is not supported yet: " + this.Type);
                }
            }
        }
        public String ExactType
        {
            get
            {
                switch (Type)
                {
                    case "Textbox":
                    case "String":
                    case "Image":
                    case "VisualEdit":
                    case "Dynamic Image":
                    case "File":
                        return "String";
                    case "Boolean": return "Boolean";
                    case "Numeric":
                        if (IsLong && Size == 0) { return "Int64"; }
                        if (Size == 0) { return "Int32"; }                            
                        if (IsLong) { return "Decimal"; }                            
                        return "Double";
                    case "O2M":
                        return "Int32";
                    case "DateTime": return "DateTime";
                    case "Date": return "DateTime";
                    case "Time": return "TimeSpan";
                    default: throw new NotSupportedException("Type is not supported yet: " + this.Type);
                }
            }
        }

        public ContentInfo RelatedContent { get; set; }

        public AttributeInfo RelatedAttribute { get; set; }

        public bool? IsSource { get; set; }

        public bool? IsTarget { get; set; }

        public LinkInfo Link { get; set; }

        public bool ShouldMap { get; set; }

        public string ExplicitMapping { get; set; }

        public string M2MClassName
        {
            get
            {
               
                return IsSource == true ? string.Format("{0}2{1}For{2}",  Content.MappedName, RelatedContent.MappedName, MappedName)
                    : string.Format("{0}2{1}For{2}", RelatedContent.MappedName, Content.MappedName, RelatedAttribute.MappedName);
            }

        }

        public string M2MPluralClassName
        {
            get
            {
                return IsSource == true ? string.Format("{0}2{1}For{2}", Content.MappedName, RelatedContent.PluralMappedName, MappedName)
                   : string.Format("{0}2{1}For{2}", RelatedContent.MappedName, Content.PluralMappedName, RelatedAttribute.MappedName);
            }

        }

        public string M2MReverseClassName
        {
            get
            {

                return IsSource == true ? string.Format("{0}2{1}For{2}", RelatedContent.MappedName, Content.MappedName, RelatedAttribute.MappedName)
                    : string.Format("{0}2{1}For{2}", Content.MappedName, RelatedContent.MappedName, MappedName);
            }

        }

        public string M2MPluralReverseClassName
        {
            get
            {
                return IsSource == true ? string.Format("{0}2{1}For{2}", RelatedContent.MappedName, Content.PluralMappedName, RelatedAttribute.MappedName)
                   : string.Format("{0}2{1}For{2}", Content.MappedName, RelatedContent.PluralMappedName, MappedName);
            }

        }

        public string M2MRelatedPropertyName
        {
            get
            {
                return RelatedContent.MappedName + "LinkedItem";
            }
        }

        public string M2MPropertyName
        {
            get
            {
                return Content.MappedName +"Item";
            }
        }

        public string M2MReverseRelatedPropertyName
        {
            get
            {
                return RelatedContent.MappedName + "Item"; 
            }
        }

        public string M2MReversePropertyName
        {
            get
            {
                return Content.MappedName + "LinkedItem";
            }
        }
    }
}
