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
    }
}
