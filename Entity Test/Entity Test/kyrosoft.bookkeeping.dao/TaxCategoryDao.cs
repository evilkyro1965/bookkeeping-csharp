using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using kyrosoft.bookkeeping.entity.dto;
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

        public SearchResult<TaxCategory> search(TaxCategorySearchParameter parameter)
        { 
            int page = parameter.page;
            int total = parameter.pageSize;

            var predicat = PredicateExtensions.PredicateExtensions.Begin<TaxCategory>();

            if ( parameter.name!=null && parameter.name!="" )
            {
                string name = parameter.name.ToLower();
                Expression<Func<TaxCategory, bool>> filterName = t => t.name.ToLower().Contains(name);
                predicat = predicat.And(filterName);
            }
            if (parameter.userId!=0)
            {
                int userId = parameter.userId;
                Expression<Func<TaxCategory, bool>> filterUser = t => t.user.id == userId;
                predicat = predicat.And(filterUser);
            }
            if (parameter.isDisabled!=null)
            {
                bool isDisabled = parameter.isDisabled;
                Expression<Func<TaxCategory, bool>> filterDisabled = t => t.isDisabled == isDisabled;
                predicat = predicat.And(filterDisabled);
            }

            SearchResult<TaxCategory> ret = null;
            try { 
                var query = daoContext.TaxCategories.Where(predicat)
                    .OrderBy(t => t.name)
                    .Skip((page-1)*total)
                    .Take(total);

                List<TaxCategory> result = query.ToList<TaxCategory>();
                ret = new SearchResult<TaxCategory>();
                ret.result = result;
                ret.total = result.Count;
                ret.page = page;
            }
            catch (SqlException e)
            {
                throw e;
            }
            return ret;
        }


    }
}
