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
    public class ExpenseCategoryDao:BaseDao<ExpenseCategory>,IExpenseCategoryDao
    {
        public void create(ExpenseCategory expenseCategory)
        {
            try
            {
                daoContext.ExpenseCategories.Add(expenseCategory);
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void update(ExpenseCategory expenseCategory)
        {
            try
            {
                var entry = daoContext.Entry<ExpenseCategory>(expenseCategory);
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
                    ExpenseCategory expenseCategory = daoContext.ExpenseCategories.Find(ids[i]);
                    if (expenseCategory == null)
                        throw new Exception("Expense Category with id:" + ids[i] + " is not found!");
                    daoContext.ExpenseCategories.Remove(expenseCategory);
                    daoContext.SaveChanges();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public ExpenseCategory get(int id)
        {
            try
            {
                ExpenseCategory expenseCategory = daoContext.ExpenseCategories.Find(id);
                return expenseCategory;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public SearchResult<ExpenseCategory> search(ExpenseCategorySearchParameter parameter)
        {
            int page = parameter.page;
            int total = parameter.pageSize;

            var predicat = PredicateExtensions.PredicateExtensions.Begin<ExpenseCategory>();

            if (parameter.name != null && parameter.name != "")
            {
                string name = parameter.name.ToLower();
                Expression<Func<ExpenseCategory, bool>> filterName = e => e.name.ToLower().Contains(name);
                predicat = predicat.And(filterName);
            }
            if (parameter.userId != 0)
            {
                int userId = parameter.userId;
                Expression<Func<ExpenseCategory, bool>> filterUser = e => e.user.id == userId;
                predicat = predicat.And(filterUser);
            }
            if (parameter.taxCategoryId != 0)
            {
                int taxCatId = parameter.taxCategoryId;
                Expression<Func<ExpenseCategory, bool>> filterTaxCategory = e => e.taxCategory.id == taxCatId;
                predicat = predicat.And(filterTaxCategory);
            }
            if (parameter.expenseType != 0)
            {
                IncomeExpenseType? expenseType = parameter.expenseType;
                Expression<Func<ExpenseCategory, bool>> filterIncomeType = e => e.expenseType == expenseType;
                predicat = predicat.And(filterIncomeType);
            }
            if (parameter.isDisabled != null)
            {
                Boolean? isDisabled = parameter.isDisabled;
                Expression<Func<ExpenseCategory, bool>> filterDisabled = e => e.isDisabled == isDisabled;
                predicat = predicat.And(filterDisabled);
            }

            SearchResult<ExpenseCategory> ret = null;
            try
            {
                var query = daoContext.ExpenseCategories.Where(predicat)
                    .OrderBy(t => t.name)
                    .Skip((page - 1) * total)
                    .Take(total);

                List<ExpenseCategory> result = query.ToList<ExpenseCategory>();
                ret = new SearchResult<ExpenseCategory>();
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
