using IntecWebShop.Core.Interfaces;
using IntecWebShop.Core.Models;
using IntecWebShop.DataAccess.SQL.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecWebShop.DataAccess.SQL.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext _context;
        internal DbSet<T> _dbSet;

        public SQLRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return _dbSet;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(string id)
        {
            var thingToDelete = FindInList(id);

            try
            {
                if (_context.Entry(thingToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(thingToDelete);
                }
                _context.Entry(thingToDelete).State = EntityState.Deleted;
                _dbSet.Remove(thingToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T FindInList(string id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T t)
        {
            _dbSet.Add(t);
        }

        public void Update(T t)
        {
            _dbSet.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}
