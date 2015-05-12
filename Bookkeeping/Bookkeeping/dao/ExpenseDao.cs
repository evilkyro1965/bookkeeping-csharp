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
    public class ExpenseDao:BaseDao<Expense>,IExpenseDao
    {
        public void create(Expense expense)
        {
            try
            {
                daoContext.Expenses.Add(expense);
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void update(Expense expense)
        {
            try
            {
                var entry = daoContext.Entry<Expense>(expense);
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
                    Expense expense = daoContext.Expenses.Find(ids[i]);
                    if (expense == null)
                        throw new Exception("Expense with id:" + ids[i] + " is not found!");
                    daoContext.Expenses.Remove(expense);
                    daoContext.SaveChanges();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public Expense get(int id)
        {
            try
            {
                Expense expense = daoContext.Expenses.Find(id);
                return expense;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public SearchResult<Expense> search(ExpenseSearchParameter parameter)
        {
            int page = parameter.page;
            int total = parameter.pageSize;

            var predicat = PredicateExtensions.PredicateExtensions.Begin<Expense>();

            if (parameter.name != null && parameter.name != "")
            {
                string name = parameter.name.ToLower();
                Expression<Func<Expense, bool>> filterName = i => i.name.ToLower().Contains(name);
                predicat = predicat.And(filterName);
            }
            if (parameter.date != null)
            {
                DateTime? date = parameter.date;
                Expression<Func<Expense, bool>> filterDate = i => i.date.Equals(date);
                predicat = predicat.And(filterDate);
            }
            if (parameter.description != null && parameter.description != "")
            {
                string description = parameter.description.ToLower();
                Expression<Func<Expense, bool>> filterDesc = i => i.description.Equals(description);
                predicat = predicat.And(filterDesc);
            }
            if (parameter.userId != 0)
            {
                int userId = parameter.userId;
                Expression<Func<Expense, bool>> filterUser = i => i.user.id == userId;
                predicat = predicat.And(filterUser);
            }
            if (parameter.expenseCategoryId != 0)
            {
                int expenseCategoryId = parameter.expenseCategoryId;
                Expression<Func<Expense, bool>> filterExpenseCategory = i => i.expenseCategory.id == expenseCategoryId;
                predicat = predicat.And(filterExpenseCategory);
            }
            if (parameter.amount != null)
            {
                double? amount = parameter.amount;
                Expression<Func<Expense, bool>> filterAmount = i => i.amount == amount;
                predicat = predicat.And(filterAmount);
            }

            SearchResult<Expense> ret = null;
            try
            {
                var query = daoContext.Expenses.Where(predicat)
                    .OrderBy(t => t.name)
                    .Skip((page - 1) * total)
                    .Take(total);

                List<Expense> result = query.ToList<Expense>();
                ret = new SearchResult<Expense>();
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
