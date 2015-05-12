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
    public class IncomeDao : BaseDao<Income>, IIncomeDao
    {
        public void create(Income income)
        {
            try
            {
                daoContext.Incomes.Add(income);
                daoContext.SaveChanges();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void update(Income income)
        {
            try
            {
                var entry = daoContext.Entry<Income>(income);
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
                    Income income = daoContext.Incomes.Find(ids[i]);
                    if (income == null)
                        throw new Exception("Income with id:" + ids[i] + " is not found!");
                    daoContext.Incomes.Remove(income);
                    daoContext.SaveChanges();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public Income get(int id)
        {
            try
            {
                Income income = daoContext.Incomes.Find(id);
                return income;
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public SearchResult<Income> search(IncomeSearchParameter parameter)
        {
            int page = parameter.page;
            int total = parameter.pageSize;

            var predicat = PredicateExtensions.PredicateExtensions.Begin<Income>();

            if (parameter.name != null && parameter.name != "")
            {
                string name = parameter.name.ToLower();
                Expression<Func<Income, bool>> filterName = i => i.name.ToLower().Contains(name);
                predicat = predicat.And(filterName);
            }
            if (parameter.date != null)
            {
                DateTime? date = parameter.date;
                Expression<Func<Income, bool>> filterDate = i => i.date.Equals(date);
                predicat = predicat.And(filterDate);
            }
            if (parameter.description != null && parameter.description != "")
            {
                string description = parameter.description.ToLower();
                Expression<Func<Income, bool>> filterDesc = i => i.description.Equals(description);
                predicat = predicat.And(filterDesc);
            }
            if (parameter.userId != 0)
            {
                int userId = parameter.userId;
                Expression<Func<Income, bool>> filterUser = i => i.user.id == userId;
                predicat = predicat.And(filterUser);
            }
            if (parameter.incomeCategoryId != 0)
            {
                int incomeCategoryId = parameter.incomeCategoryId;
                Expression<Func<Income, bool>> filterIncomeCategory = i => i.incomeCategory.id == incomeCategoryId;
                predicat = predicat.And(filterIncomeCategory);
            }
            if (parameter.amount != null)
            {
                double? amount = parameter.amount;
                Expression<Func<Income, bool>> filterAmount = i => i.amount == amount;
                predicat = predicat.And(filterAmount);
            }

            SearchResult<Income> ret = null;
            try
            {
                var query = daoContext.Incomes.Where(predicat)
                    .OrderBy(t => t.name)
                    .Skip((page - 1) * total)
                    .Take(total);

                List<Income> result = query.ToList<Income>();
                ret = new SearchResult<Income>();
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
