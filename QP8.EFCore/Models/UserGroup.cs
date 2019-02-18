﻿using System.Collections.Generic;

namespace Quantumart.QP8.EFCore.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            UserGroupBinds = new HashSet<UserGroupBind>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<UserGroupBind> UserGroupBinds { get; set; }
    }
}
