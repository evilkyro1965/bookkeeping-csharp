using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using PredicateExtensions;

namespace kyrosoft.bookkeeping.dao
{
    public class TaxCategoryDao: BaseDao<TaxCategory>, ITaxCategoryDao
    {
        public void create(TaxCategory taxCategory)
        {
            try
            {
                daoContext.TaxCategories.Add(taxCategory);
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void update(TaxCategory taxCategory)
        {
            try
            {
                var entry = daoContext.Entry<TaxCategory>(taxCategory);
                entry.State = EntityState.Modified;
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void delete(int[] ids)
        {
            try
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    TaxCategory taxCat = daoContext.TaxCategories.Find(ids[i]);
                    if (taxCat == null)
                        throw new Exception("Tax Category with id:" + ids[i] + " is not found!");
                    daoContext.TaxCategories.Remove(taxCat);
                    daoContext.SaveChanges();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public TaxCategory get(int id)
        {
            try
            {
                TaxCategory taxCat = daoContext.TaxCategories.Find(id);
                return taxCat;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public SearchResult<TaxCategory> search(BaseSearchParameter parameter)
        {
            string name = parameter.filter["name"];

            //IQueryable<TaxCategory> query;  
            Dictionary<String,String> filter = parameter.filter;
            Expression<Func<TaxCategory, bool>> taxFilter = u => u.name.Contains(name);

            var query3 = daoContext.TaxCategories.Where(taxFilter).OrderBy(u => u.name);

            int page = parameter.page;
            int total = parameter.pageSize;

            var predicat = PredicateExtensions.PredicateExtensions.Begin<TaxCategory>();

            if (filter.ContainsKey("name"))
            {
                //query3.Where(u => u.name.Contains(name));
                //query.WhereLike(u => u.name, "Tax1*", '*');
                Expression<Func<TaxCategory, bool>> filterName = u => u.name.Contains(name);
                predicat = predicat.And(filterName);
            }

            var query = daoContext.TaxCategories.Where(
                predicat
                );
            List<TaxCategory> result = query.ToList<TaxCategory>();
            SearchResult<TaxCategory> ret = new SearchResult<TaxCategory>();
            ret.result = result;
            ret.total = result.Count;
            ret.page = page;

            return ret;
        }


    }
}
