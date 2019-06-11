using IntecWebShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace IntecWebShop.DataAcces.InMemory.Repositories
{
    public class ProductCategoryRepository
    {

        ObjectCache Cache = MemoryCache.Default;
        List<ProductCategory> categories;

        public ProductCategoryRepository()
        {
            categories = (List<ProductCategory>)Cache["productcategory"];

            if (categories == null)
                categories = new List<ProductCategory>();
        }

        public void Commit()
        {
            Cache["productcategory"] = categories;
        }

        public void Insert(ProductCategory category)
        {
            categories.Add(category);
            Commit();
        }

        public void Update(ProductCategory category)
        {
            var index = categories.FindIndex(x => x.Id == category.Id);

            if (index == -1)
                throw new ArgumentNullException();

            categories[index] = category;
            Commit();
        }

        public ProductCategory FindProductCategory(string Id)
        {
            var tempProduct = categories.Find(x => x.Id == Id);

            if (tempProduct != null)
                return tempProduct;
            else
                throw new Exception("404 Product Not Found");
        }

        public IQueryable<ProductCategory> Collection()
        {
            return categories.AsQueryable();
        }

        public bool Delete(string id)
        {
            var tempProductCategory = FindProductCategory(id);
            var isDeleted = categories.Remove(tempProductCategory);
            Commit();
            return isDeleted;
        }
    }
}
