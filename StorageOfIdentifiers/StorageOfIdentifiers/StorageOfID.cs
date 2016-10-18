using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageOfID
{
    public class StorageOfID
    {
        Dictionary<Type, Dictionary<Guid, Object>> storage =
            new Dictionary<Type, Dictionary<Guid, Object>>();

        public T Create<T>()
            where T : class, new()
        {
            T obj = new T();
            if (!storage.ContainsKey(typeof(T)))
                storage[typeof(T)] = new Dictionary<Guid, Object>(); ;
            storage[typeof(T)][Guid.NewGuid()] = obj;
            return obj;
        }

        public IEnumerable<KeyValuePair<Guid, T>> PairsByType<T>()
            where T: class
        {
            return storage[typeof(T)].Select(p => new KeyValuePair<Guid, T>(p.Key, p.Value as T));
        }

        public T ObjectByGuid<T>(Guid id)
            where T : class
        {
            if(storage.ContainsKey(typeof(T)))
                if (storage[typeof(T)].ContainsKey(id))
                return storage[typeof(T)][id] as T;
            return null;
        }
    }
}
