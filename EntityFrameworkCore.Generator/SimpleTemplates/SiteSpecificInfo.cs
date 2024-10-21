using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class SiteSpecificInfo
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using Quantumart.QPublishing.Database;

namespace {ns}
{{
    public partial class SiteSpecificInfo
    {{
        public int SiteId {{ get; private set; }}
		public string LiveSiteUrl {{ get; private set; }}
		public string LiveSiteUrlRel {{ get; private set; }}
		public string StageSiteUrl {{ get; private set; }}
		public string StageSiteUrlRel {{ get; private set; }}
		public string LongUploadUrl {{ get; private set; }}
		public string ShortUploadUrl {{ get; private set; }}
		public int PublishedId {{ get; private set; }}
		
		public void Load(DBConnector cnn, string siteName, bool shouldRemoveSchema)
        {{
            SiteId = cnn.GetSiteId(siteName);
            LiveSiteUrl = cnn.GetSiteUrl(SiteId, true);
            LiveSiteUrlRel = cnn.GetSiteUrlRel(SiteId, true);
            StageSiteUrl = cnn.GetSiteUrl(SiteId, false);
            StageSiteUrlRel = cnn.GetSiteUrlRel(SiteId, false);
            LongUploadUrl = cnn.GetImagesUploadUrl(SiteId, false, shouldRemoveSchema);
            ShortUploadUrl = cnn.GetImagesUploadUrl(SiteId, true, shouldRemoveSchema);
            PublishedId = cnn.GetMaximumWeightStatusTypeId(SiteId);
        }}

        public void CopyFrom(SiteSpecificInfo info)
        {{
            SiteId = info.SiteId;
            LiveSiteUrl = info.LiveSiteUrl;
            LiveSiteUrlRel = info.LiveSiteUrlRel;
            StageSiteUrl = info.StageSiteUrl;
            StageSiteUrlRel = info.StageSiteUrlRel;
            LongUploadUrl = info.LongUploadUrl;
            ShortUploadUrl = info.ShortUploadUrl;
            PublishedId = info.PublishedId;
        }}
    }}
}}";
        }
    }
}