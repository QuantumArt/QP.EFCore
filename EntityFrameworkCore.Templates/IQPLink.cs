using System;
using System.Collections;

namespace EntityFrameworkCore.Templates
{
    public interface IQPLink
    {
        int Id { get; set; }
        int LinkedItemId { get; set; }
        int LinkId { get; }

        IQPArticle Item { get; }
        IQPArticle LinkedItem { get; }
    }

}
