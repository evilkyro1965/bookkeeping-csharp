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

    }
}
