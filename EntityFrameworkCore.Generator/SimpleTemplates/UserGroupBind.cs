using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class UserGroupBind
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System.Collections.Generic;

namespace {ns}
{{
    public partial class UserGroupBind
    {{
        public UserGroupBind()
        {{

        }}
        public virtual int UserId {{ get; set; }}

        public virtual int GroupId {{ get; set; }}

        public virtual User User {{ get; set; }}
        public virtual UserGroup UserGroup {{ get; set; }}
    }}
}}";
        }
    }
}