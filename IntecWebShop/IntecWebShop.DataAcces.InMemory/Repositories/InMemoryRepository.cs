using IntecWebShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace IntecWebShop.DataAcces.InMemory.Repositories
{
    public class InMemoryRepository<T> where T:BaseEntity
    {
        ObjectCache _cache = MemoryCache.Default;
        List<T> _list;
        string _className;

        public InMemoryRepository()
        {
            _className = typeof(T).Name;
            _list = (List<T>)_cache[_className];
            if (_list == null)
            {
                _list = new List<T>();
            }
        }

        public void Commit()
        {
            _cache[_className] = _list;
        }

        public void Insert(T t)
        {
            _list.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = _list.Find(i => i.Id == t.Id);

            if (tToUpdate == null)
                throw new Exception(_className + "Not Found");

            tToUpdate = t;
        }

        public T FindProduct(string id)
        {
            T t = _list.Find(i => i.Id == id);

            if (t == null)
                throw new Exception(_className+" Not Found");
            
            return t;
        }

        public IQueryable<T> Collection()
        {
            return _list.AsQueryable();
        }

        public void Delete(string id)
        {
            T tToDelete = _list.Find(i => i.Id == id);

            if (tToDelete == null)
                throw new Exception("404 Something Not Found");

            _list.Remove(tToDelete);
        }
    }
}
