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
    public class IncomeCategoryDao : BaseDao<IncomeCategory>, IIncomeCategoryDao
    {
        public void create(IncomeCategory incomeCategory)
        {
            try
            {
                daoContext.IncomeCategories.Add(incomeCategory);
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void update(IncomeCategory incomeCategory)
        {
            try
            {
                var entry = daoContext.Entry<IncomeCategory>(incomeCategory);
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
                    IncomeCategory incomeCat = daoContext.IncomeCategories.Find(ids[i]);
                    if (incomeCat == null)
                        throw new Exception("Income Category with id:" + ids[i] + " is not found!");
                    daoContext.IncomeCategories.Remove(incomeCat);
                    daoContext.SaveChanges();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public IncomeCategory get(int id)
        {
            try
            {
                IncomeCategory incomeCat = daoContext.IncomeCategories.Find(id);
                return incomeCat;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public SearchResult<IncomeCategory> search(IncomeCategorySearchParameter parameter)
        {
            int page = parameter.page;
            int total = parameter.pageSize;

            var predicat = PredicateExtensions.PredicateExtensions.Begin<IncomeCategory>();

            if (parameter.name != null && parameter.name != "")
            {
                string name = parameter.name.ToLower();
                Expression<Func<IncomeCategory, bool>> filterName = i => i.name.ToLower().Contains(name);
                predicat = predicat.And(filterName);
            }
            if (parameter.userId != 0)
            {
                int userId = parameter.userId;
                Expression<Func<IncomeCategory, bool>> filterUser = i => i.user.id == userId;
                predicat = predicat.And(filterUser);
            }
            if (parameter.taxCategoryId != 0)
            {
                int taxCatId = parameter.taxCategoryId;
                Expression<Func<IncomeCategory, bool>> filterTaxCategory = i => i.taxCategory.id == taxCatId;
                predicat = predicat.And(filterTaxCategory);
            }
            if (parameter.incomeType != 0)
            {
                IncomeExpenseType? incomeType = parameter.incomeType;
                Expression<Func<IncomeCategory, bool>> filterIncomeType = i => i.incomeType == incomeType;
                predicat = predicat.And(filterIncomeType);
            }
            if (parameter.isDisabled != null)
            {
                Boolean? isDisabled = parameter.isDisabled;
                Expression<Func<IncomeCategory, bool>> filterDisabled = i => i.isDisabled == isDisabled;
                predicat = predicat.And(filterDisabled);
            }

            SearchResult<IncomeCategory> ret = null;
            try
            {
                var query = daoContext.IncomeCategories.Where(predicat)
                    .OrderBy(t => t.name)
                    .Skip((page - 1) * total)
                    .Take(total);

                List<IncomeCategory> result = query.ToList<IncomeCategory>();
                ret = new SearchResult<IncomeCategory>();
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
