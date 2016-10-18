using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageOfID
{
    public class StorageOfID
    {
        Dictionary<Guid, Object> Storage = new Dictionary<Guid, Object>();

        public T Create<T>()
            where T : class, new()
        {
            T obj = new T();
            Storage[Guid.NewGuid()] = obj;
            return obj;
        }

        public IEnumerable<KeyValuePair<Guid, T>> PairsByType<T>()
            where T: class
        {
            return Storage.Where(p => p.Value.GetType() == typeof(T)).Select(p => new KeyValuePair<Guid,T>(p.Key,p.Value as T));   
        }

        public T ObjectByGuid<T>(Guid id)
            where T : class
        {
            if(Storage.ContainsKey(id))
                return Storage[id] as T;
            return null;
        }
    }
}
