using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.IDAL
{
   public interface ICustomerFinance
    {
        int AddCustomerFinance(Model.CustomerFinance Model);
        int DeleteCustomerFinanceByCustomerFinanceID(object Id);
        int EditCustomerFinanceByCustomerFinanceID(Model.CustomerFinance Model);
        Model.CustomerFinance GetCustomerFinanceByID(object ID);
        DataTable GetCustomerFinanceDataByWhere(string Where, List<SqlParameter> ParameList);
        int DeleteDataByWhere(string sql, List<SqlParameter> list);
       int  EditCustomerFinanceByFinanceId(Model.CustomerFinance modelCusFin);
    }
}
