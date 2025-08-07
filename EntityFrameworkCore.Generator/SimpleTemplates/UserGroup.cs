using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates;

internal static class UserGroup
{
    public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return @$"{context.Settings.GeneratedCodePrefix}
using System.Collections.Generic;

namespace {ns};

public partial class UserGroup
{{
    public UserGroup()
    {{
        UserGroupBinds = new HashSet<UserGroupBind>();
    }}

    public virtual int Id {{ get; set; }}
    public virtual string Name {{ get; set; }}
    public virtual ICollection<UserGroupBind> UserGroupBinds {{ get; set; }}
}}";
    }
}