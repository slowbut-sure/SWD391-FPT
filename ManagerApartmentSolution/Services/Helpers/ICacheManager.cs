using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public interface ICacheManager
    {
        Task Set(String key, object value, int time);

        Task<T> Get<T>(string key);

        Task Remove(String key);
    }
}
