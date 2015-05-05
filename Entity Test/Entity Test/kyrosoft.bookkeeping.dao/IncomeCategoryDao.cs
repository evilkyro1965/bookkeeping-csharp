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
    }
}
