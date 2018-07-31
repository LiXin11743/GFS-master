using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.IDAL
{

    public interface ICustomers
    {
        /// <summary>
        /// 根据菜单标识码和用户id获取此用户拥有该菜单下的哪些按钮权限
        /// </summary>
        SqlDataReader GetCustomersTbaleNoP();
        DataTable GetButtonByMenuCodeAndUserId(string menuCode, int userId);
        int AddCustomers(ZGZY.Model.Customers model);
        int EditCustomers(ZGZY.Model.Customers model);
        int DeleteCustomersById(object Id);
        ZGZY.Model.Customers GetCustomersById(object ID);
    }
}
