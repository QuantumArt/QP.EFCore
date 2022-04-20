﻿using System.Threading;

namespace Quantumart.QP8.EntityFrameworkCore.Generator.SimpleTemplates
{
    internal static class UserGroup
    {
        public static string GetTemplate(string ns, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return @$"
// Code generated by a source generator template
using System.Collections.Generic;

namespace {ns}
{{
    public partial class UserGroup
    {{
        public UserGroup()
        {{
            UserGroupBinds = new HashSet<UserGroupBind>();
        }}

        public virtual int Id {{ get; set; }}
        public virtual string Name {{ get; set; }}
        public virtual ICollection<UserGroupBind> UserGroupBinds {{ get; set; }}
    }}
}}";
        }
    }
}