using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolStatistics.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        void Map(T t);
        T UnMap(string id);
    }
}
