using System.Collections.Generic;

namespace Quantumart.QP8.EntityFrameworkCore
{
    public interface IUpdateProvider
    {
        void Update(IEnumerable<object> data);
        void Insert(IEnumerable<object> data);
        void Delete(int id);
    }
}
