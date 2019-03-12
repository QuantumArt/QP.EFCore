using System;
using System.Collections;

namespace Quantumart.QP8.EFCore.Models
{
    public interface IQPLink
    {
        int Id { get; }
        int LinkedItemId { get; }
        int LinkId { get; }
        
    }

}
