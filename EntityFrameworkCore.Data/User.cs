using System.Collections.Generic;

namespace EntityFrameworkCore.Data
{
    public partial class User
    {
        public User()
        {
            UserGroupBinds = new HashSet<UserGroupBind>();
        }

        public virtual int Id { get; set; }
        public virtual string login { get; set; }
        public virtual string NTLogin { get; set; }
        public virtual string ISOCode { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual ICollection<UserGroupBind> UserGroupBinds { get; set; }
    }
}
