using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kyrosoft.bookkeeping.entity;
using System.Data.SqlClient;
using System.Data.Entity;

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
    }
}
