using System;
using System.Collections;

namespace EntityFrameworkCore.Templates
{
    public interface IQPLink
    {
        int Id { get; }
        int LinkedItemId { get; }
        int LinkId { get; }
        
    }

}
