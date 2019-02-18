using System.Collections.Generic;

namespace Quantumart.QP8.EFCore.Services
{
    public interface IUpdateProvider
    {
        void Update(IEnumerable<object> data);
        void Insert(IEnumerable<object> data);
        void Delete(int id);
    }
}
