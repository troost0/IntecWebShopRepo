using System.Linq;
using IntecWebShop.Core.Models;

namespace IntecWebShop.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        bool Delete(string id);
        T FindInList(string id);
        void Insert(T t);
        void Update(T t);
    }
}