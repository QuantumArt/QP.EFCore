using System;
using System.Collections;

namespace Quantumart.QP8.EntityFrameworkCore
{
    public interface IQPLink
    {
        int Id { get; }
        int LinkedItemId { get; }
        int LinkId { get; }
        
    }

}
