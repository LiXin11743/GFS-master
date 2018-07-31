using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.BLL
{
    public class Customers
    {
        private static readonly ZGZY.IDAL.ICustomers dal = ZGZY.DALFactory.Factory.GetCustomersDAL();
        public DataTable GetButtonByMenuCodeAndUserId(string menuCode, int userId)
        {
            return dal.GetButtonByMenuCodeAndUserId(menuCode, userId);
        }
        public List<Model.Customers> GetCustomersTbaleNoP()
        {
            List<Model.Customers> list = new List<Model.Customers>();
            SqlDataReader read = dal.GetCustomersTbaleNoP();
            while (read.Read())
            {
                Model.Customers modelcus = new Model.Customers();

                    modelcus.Id = Int32.Parse(read["Id"].ToString());
                    modelcus.CusCode = read["CusCode"].ToString();
                    modelcus.CusName = read["CusName"].ToString();
                    modelcus.State = Int32.Parse(read["State"].ToString());
                    modelcus.CusType = Int32.Parse(read["CusType"].ToString());
                    modelcus.CusLevel = Int32.Parse(read["CusLevel"].ToString());
                    modelcus.CreateDate = DateTime.Parse(read["CreateDate"].ToString() == "" ? null : read["CreateDate"].ToString());
                    modelcus.SalesmanId = Int32.Parse(read["SalesmanId"].ToString());
                    modelcus.ServicerId = Int32.Parse(read["ServicerId"].ToString());
                modelcus.Remark = read["Remark"].ToString();
                list.Add(modelcus);
            }

            return list;

        }
        public int AddCustomers(ZGZY.Model.Customers model)
        {
            return dal.AddCustomers(model);
        }
        public ZGZY.Model.Customers GetCustomersById(object Id)
        {
            return dal.GetCustomersById(Id);
        }
        public int EditCustomers(ZGZY.Model.Customers model)
        {
            return dal.EditCustomers(model);
        }
        public int DeleteCustomersById(object Id)
        {
            return dal.DeleteCustomersById(Id);
        }
    }
}
