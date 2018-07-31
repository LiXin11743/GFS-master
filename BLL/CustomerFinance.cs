using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.BLL
{
    public class CustomerFinance
    {
        private static readonly ZGZY.IDAL.ICustomerFinance dal = ZGZY.DALFactory.Factory.GetCustomerFinanceDAL();

        public int AddCustomerFinance(Model.CustomerFinance Model)
        {
            return dal.AddCustomerFinance(Model);
        }
        public int DeleteCustomerFinanceByCustomerFinanceID(object Id)
        {
            return dal.DeleteCustomerFinanceByCustomerFinanceID(Id);
        }
        public int EditCustomerFinanceByCustomerFinanceID(Model.CustomerFinance Model)
        {
            return dal.EditCustomerFinanceByCustomerFinanceID(Model);
        }
        public Model.CustomerFinance GetCustomerFinanceByID(object ID)
        {
            return dal.GetCustomerFinanceByID(ID);
        }
        public DataTable GetCustomerFinanceDataByWhere(string Where, List<SqlParameter> ParameList)
        {
            return dal.GetCustomerFinanceDataByWhere(Where, ParameList);
        }
       public int EditCustomerFinanceByFinanceId(Model.CustomerFinance modelCusFin) {
            return dal.EditCustomerFinanceByFinanceId(modelCusFin);
        }
    }
}
