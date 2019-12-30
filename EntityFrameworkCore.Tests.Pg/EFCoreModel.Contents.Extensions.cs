// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EntityFrameworkCore.Tests.Pg
{
    public partial class AfiellFieldsItem: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<AfiellFieldsItem, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<AfiellFieldsItem,  IQPFormService, string>>
        {
			{ "String", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.String != null ? ctx.ReplacePlaceholders(self.String) : null) },
			{ "Integer", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.Integer != null ? self.Integer.ToString() : null) },
			{ "Decimal", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.Decimal != null ? self.Decimal.ToString() : null) },
			{ "Boolean", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.Boolean != null ? self.Boolean.Value ? "1" : "0" : null) },
			{ "Date", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.Date != null ? self.Date.ToString() : null) },
			{ "Time", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.Time != null ? self.Time.ToString() : null) },
			{ "DateTime", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.DateTime != null ? self.DateTime.ToString() : null) },
			{ "File", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.File != null ? self.File : null) },
			{ "Image", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.Image != null ? self.Image : null) },
			{ "TextBox", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.TextBox != null ? ctx.ReplacePlaceholders(self.TextBox) : null) },
			{ "VisualEdit", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.VisualEdit != null ? ctx.ReplacePlaceholders(self.VisualEdit) : null) },
			{ "DynamicImage", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.DynamicImage != null ? self.DynamicImage : null) },
			{ "Enum", new Func<AfiellFieldsItem, IQPFormService, string>((self, ctx) => self.Enum != null ? ctx.ReplacePlaceholders(self.Enum) : null) },
        };

        #endregion
        #region Genarated properties
        public string FileUrl 
		{ 
			get { return EFCoreModel.Current.GetUrl(this.File, "AfiellFieldsItem", "File"); }
		}
        public string ImageUrl 
		{ 
			get { return EFCoreModel.Current.GetUrl(this.Image, "AfiellFieldsItem", "Image"); }
		}
        public string DynamicImageUrl 
		{ 
			get { return EFCoreModel.Current.GetUrl(this.DynamicImage, "AfiellFieldsItem", "DynamicImage"); }
		}
        public string FileUploadPath 
		{ 
			get { return EFCoreModel.Current.GetUploadPath(this.File, "AfiellFieldsItem", "File"); }
		}
        public string ImageUploadPath 
		{ 
			get { return EFCoreModel.Current.GetUploadPath(this.Image, "AfiellFieldsItem", "Image"); }
		}
        public Int32 IntegerExact { get { return this.Integer == null ? default(Int32) : this.Integer.Value; } }
        public Decimal DecimalExact { get { return this.Decimal == null ? default(Decimal) : this.Decimal.Value; } }
        public Boolean BooleanExact { get { return this.Boolean == null ? default(Boolean) : this.Boolean.Value; } }
        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("AfiellFieldsItem", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class Schema: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<Schema, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<Schema,  IQPFormService, string>>
        {
			{ "Title", new Func<Schema, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("Schema", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class StringItem: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<StringItem, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<StringItem,  IQPFormService, string>>
        {
			{ "StringValue", new Func<StringItem, IQPFormService, string>((self, ctx) => self.StringValue != null ? ctx.ReplacePlaceholders(self.StringValue) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("StringItem", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class StringItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<StringItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<StringItemForUpdate,  IQPFormService, string>>
        {
			{ "StringValue", new Func<StringItemForUpdate, IQPFormService, string>((self, ctx) => self.StringValue != null ? ctx.ReplacePlaceholders(self.StringValue) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("StringItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class StringItemForUnsert: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<StringItemForUnsert, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<StringItemForUnsert,  IQPFormService, string>>
        {
			{ "StringValue", new Func<StringItemForUnsert, IQPFormService, string>((self, ctx) => self.StringValue != null ? ctx.ReplacePlaceholders(self.StringValue) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("StringItemForUnsert", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class ItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<ItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<ItemForUpdate,  IQPFormService, string>>
        {
			{ "Title", new Func<ItemForUpdate, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("ItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class ItemForInsert: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<ItemForInsert, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<ItemForInsert,  IQPFormService, string>>
        {
			{ "Title", new Func<ItemForInsert, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("ItemForInsert", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class PublishedNotPublishedItem: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<PublishedNotPublishedItem, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<PublishedNotPublishedItem,  IQPFormService, string>>
        {
			{ "Title", new Func<PublishedNotPublishedItem, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
			{ "Alias", new Func<PublishedNotPublishedItem, IQPFormService, string>((self, ctx) => self.Alias != null ? ctx.ReplacePlaceholders(self.Alias) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("PublishedNotPublishedItem", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class ReplacingPlaceholdersItem: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<ReplacingPlaceholdersItem, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<ReplacingPlaceholdersItem,  IQPFormService, string>>
        {
			{ "Title", new Func<ReplacingPlaceholdersItem, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("ReplacingPlaceholdersItem", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class FileFieldsItem: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<FileFieldsItem, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<FileFieldsItem,  IQPFormService, string>>
        {
			{ "FileItem", new Func<FileFieldsItem, IQPFormService, string>((self, ctx) => self.FileItem != null ? self.FileItem : null) },
        };

        #endregion
        #region Genarated properties
        public string FileItemUrl 
		{ 
			get { return EFCoreModel.Current.GetUrl(this.FileItem, "FileFieldsItem", "FileItem"); }
		}
        public string FileItemUploadPath 
		{ 
			get { return EFCoreModel.Current.GetUploadPath(this.FileItem, "FileFieldsItem", "FileItem"); }
		}
        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("FileFieldsItem", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class SymmetricRelationArticle: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<SymmetricRelationArticle, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<SymmetricRelationArticle,  IQPFormService, string>>
        {
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("SymmetricRelationArticle", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class ToSymmetricRelationAtricle: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<ToSymmetricRelationAtricle, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<ToSymmetricRelationAtricle,  IQPFormService, string>>
        {
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("ToSymmetricRelationAtricle", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class MtMItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<MtMItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<MtMItemForUpdate,  IQPFormService, string>>
        {
			{ "Title", new Func<MtMItemForUpdate, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("MtMItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class MtMDictionaryForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<MtMDictionaryForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<MtMDictionaryForUpdate,  IQPFormService, string>>
        {
			{ "Title", new Func<MtMDictionaryForUpdate, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("MtMDictionaryForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class OtMItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<OtMItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<OtMItemForUpdate,  IQPFormService, string>>
        {
			{ "Title", new Func<OtMItemForUpdate, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
			{ "Reference_ID", new Func<OtMItemForUpdate, IQPFormService, string>((self, ctx) => self.Reference_ID != null ? self.Reference_ID.ToString() : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("OtMItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class OtMDictionaryForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<OtMDictionaryForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<OtMDictionaryForUpdate,  IQPFormService, string>>
        {
			{ "Title", new Func<OtMDictionaryForUpdate, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("OtMDictionaryForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class DateItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<DateItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<DateItemForUpdate,  IQPFormService, string>>
        {
			{ "DateValueField", new Func<DateItemForUpdate, IQPFormService, string>((self, ctx) => self.DateValueField != null ? self.DateValueField.ToString() : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("DateItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class TimeItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<TimeItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<TimeItemForUpdate,  IQPFormService, string>>
        {
			{ "TimeValueField", new Func<TimeItemForUpdate, IQPFormService, string>((self, ctx) => self.TimeValueField != null ? self.TimeValueField.ToString() : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("TimeItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class DateTimeItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<DateTimeItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<DateTimeItemForUpdate,  IQPFormService, string>>
        {
			{ "DateTimeValueField", new Func<DateTimeItemForUpdate, IQPFormService, string>((self, ctx) => self.DateTimeValueField != null ? self.DateTimeValueField.ToString() : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("DateTimeItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class FileItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<FileItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<FileItemForUpdate,  IQPFormService, string>>
        {
			{ "FileValueField", new Func<FileItemForUpdate, IQPFormService, string>((self, ctx) => self.FileValueField != null ? self.FileValueField : null) },
        };

        #endregion
        #region Genarated properties
        public string FileValueFieldUrl 
		{ 
			get { return EFCoreModel.Current.GetUrl(this.FileValueField, "FileItemForUpdate", "FileValueField"); }
		}
        public string FileValueFieldUploadPath 
		{ 
			get { return EFCoreModel.Current.GetUploadPath(this.FileValueField, "FileItemForUpdate", "FileValueField"); }
		}
        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("FileItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class ImageItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<ImageItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<ImageItemForUpdate,  IQPFormService, string>>
        {
			{ "ImageValueField", new Func<ImageItemForUpdate, IQPFormService, string>((self, ctx) => self.ImageValueField != null ? self.ImageValueField : null) },
        };

        #endregion
        #region Genarated properties
        public string ImageValueFieldUrl 
		{ 
			get { return EFCoreModel.Current.GetUrl(this.ImageValueField, "ImageItemForUpdate", "ImageValueField"); }
		}
        public string ImageValueFieldUploadPath 
		{ 
			get { return EFCoreModel.Current.GetUploadPath(this.ImageValueField, "ImageItemForUpdate", "ImageValueField"); }
		}
        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("ImageItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class OtMItemForMapping: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<OtMItemForMapping, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<OtMItemForMapping,  IQPFormService, string>>
        {
			{ "OtMReferenceMapping_ID", new Func<OtMItemForMapping, IQPFormService, string>((self, ctx) => self.OtMReferenceMapping_ID != null ? self.OtMReferenceMapping_ID.ToString() : null) },
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("OtMItemForMapping", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class OtMRelatedItemWithMapping: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<OtMRelatedItemWithMapping, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<OtMRelatedItemWithMapping,  IQPFormService, string>>
        {
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("OtMRelatedItemWithMapping", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class OtMItemToContentWithoutMapping: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<OtMItemToContentWithoutMapping, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<OtMItemToContentWithoutMapping,  IQPFormService, string>>
        {
			{ "OtMReferenceMapping_ID", new Func<OtMItemToContentWithoutMapping, IQPFormService, string>((self, ctx) => self.OtMReferenceMapping_ID != null ? self.OtMReferenceMapping_ID.ToString() : null) },
        };

        #endregion
        #region Genarated properties
        public Int32 OtMReferenceMapping_IDExact { get { return this.OtMReferenceMapping_ID == null ? default(Int32) : this.OtMReferenceMapping_ID.Value; } }
        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("OtMItemToContentWithoutMapping", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class BooleanItemForUpdate: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<BooleanItemForUpdate, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<BooleanItemForUpdate,  IQPFormService, string>>
        {
        };

        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("BooleanItemForUpdate", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
    public partial class OtMItemForUpdateVirtual: IQPArticle
    {
        #region Static members
        protected static readonly Dictionary<string, Func<OtMItemForUpdateVirtual, IQPFormService, string>> _valueExtractors = new Dictionary<string, Func<OtMItemForUpdateVirtual,  IQPFormService, string>>
        {
			{ "Title", new Func<OtMItemForUpdateVirtual, IQPFormService, string>((self, ctx) => self.Title != null ? ctx.ReplacePlaceholders(self.Title) : null) },
			{ "Reference_ID", new Func<OtMItemForUpdateVirtual, IQPFormService, string>((self, ctx) => self.Reference_ID != null ? self.Reference_ID.ToString() : null) },
        };

        #endregion
        #region Genarated properties
        public Int32 Reference_IDExact { get { return this.Reference_ID == null ? default(Int32) : this.Reference_ID.Value; } }
        #endregion

		
        // для Poco перенести из класса куда-нибудь, так как нарушается концепция доступа к БД
        Hashtable IQPArticle.Pack(IQPFormService context, params string[] propertyNames)
        {
            Hashtable table;

            if (propertyNames == null || propertyNames.Length == 0)
            {
                table = new Hashtable(_valueExtractors.ToDictionary(x => context.GetFormNameByNetNames("OtMItemForUpdateVirtual", x.Key), y => y.Value(this, context)));
            }
            else
            {
                table = new Hashtable();
                foreach (var prop in propertyNames.Join(_valueExtractors.Keys, x => x, x => x, (x, y) => x))
                {
                    string value = _valueExtractors[prop](this, context);
                    table.Add(prop, value);
                }
            }

            return table;
        }
    }
}
	
	
	
	
	
	
	
	
	
	
	
	
