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
    }
}
