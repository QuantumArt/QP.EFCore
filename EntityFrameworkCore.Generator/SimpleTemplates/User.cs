using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class User
    {
        public static string GetTemplate(string ns, GenerationContext context, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"{context.Settings.GeneratedCodePrefix}
using System.Collections.Generic;

namespace {ns}
{{
    public partial class User
    {{
        public User()
        {{
            UserGroupBinds = new HashSet<UserGroupBind>();
        }}

        public virtual int Id {{ get; set; }}
        public virtual string login {{ get; set; }}
        public virtual string NTLogin {{ get; set; }}
        public virtual string ISOCode {{ get; set; }}
        public virtual string FirstName {{ get; set; }}
        public virtual string LastName {{ get; set; }}
        public virtual string Email {{ get; set; }}
        public virtual ICollection<UserGroupBind> UserGroupBinds {{ get; set; }}
    }}
}}";
        }
    }
}