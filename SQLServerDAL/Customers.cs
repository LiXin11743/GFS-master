using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZGZY.Model;

namespace ZGZY.SQLServerDAL
{
    public class Customers : ZGZY.IDAL.ICustomers
    {
        public int AddCustomers(Model.Customers model)
        {
            StringBuilder strSql = new StringBuilder();//Id, CreateDate,
            strSql.Append("insert into Customers values(@CusCode, @CusName, @State, @CusType, @CusLevel, GETDATE(),@SalesmanId, @ServicerId, @Remark)");
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@CusCode", model.CusCode),
                new SqlParameter("@CusName", model.CusName),
                new SqlParameter("@State", model.State),
                new SqlParameter("@CusType", model.CusType),
                new SqlParameter("@CusLevel", model.CusLevel),
                new SqlParameter("@SalesmanId", model.SalesmanId),
                new SqlParameter("@ServicerId", model.ServicerId),
                new SqlParameter("@Remark", model.Remark)
            };
            using (SqlConnection con = new SqlConnection(ZGZY.Common.SqlHelper.connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand(strSql.ToString(), con);
                com.Parameters.AddRange(paras);

                int sum = com.ExecuteNonQuery();
                return sum;
            }
        }
        public int DeleteCustomersById(object Id)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("delete Customers where Id=@id");
            SqlParameter[] par = new SqlParameter[] { new SqlParameter("@id", Id) };
            return ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strsql.ToString(), par);
        }
        public int EditCustomers(Model.Customers model)
        {
            if (model != null)
            {
                StringBuilder strsql = new StringBuilder();
                List<SqlParameter> list = new List<SqlParameter>();
                if (model.CusName != "")
                    strsql.Append("CusName=@CusName,"); list.Add(new SqlParameter("@CusName", model.CusName));
                if (model.State != -1)
                    strsql.Append("[State]=@State,"); list.Add(new SqlParameter("@State", model.State));
                if (model.CusType != -1)
                    strsql.Append(" CusType=@CusType,"); list.Add(new SqlParameter("@CusType", model.CusType));
                if (model.CusLevel >= 0)
                    strsql.Append("CusLevel=@CusLevel,"); list.Add(new SqlParameter("@CusLevel", model.CusLevel));
                if (model.SalesmanId != 0)
                    strsql.Append("SalesmanId=@SalesmanId,"); list.Add(new SqlParameter("@SalesmanId", model.SalesmanId));
                if (model.ServicerId != 0)
                    strsql.Append("ServicerId=@ServicerId,"); list.Add(new SqlParameter("@ServicerId", model.ServicerId));
                if (model.Remark != null)
                    strsql.Append("Remark=@Remark,"); list.Add(new SqlParameter("@Remark", model.Remark));
                if (strsql.Length > 0)
                {
                    strsql.Remove(strsql.Length-1, 1);
                    strsql.Append(" where  Id=@Id ");
                    list.Add(new SqlParameter("@Id", model.Id));
                    return ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, "update Customers set " + strsql.ToString(), list.ToArray());
                }
            }
            return -1;
        }
        public DataTable GetButtonByMenuCodeAndUserId(string menuCode, int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct(b.Id) id,b.Code code,b.Name name,b.Icon icon,b.Sort sort from tbUser u");
            strSql.Append(" join tbUserRole ur on u.Id=ur.UserId");
            strSql.Append(" join tbRoleMenuButton rmb on ur.RoleId=rmb.RoleId");
            strSql.Append(" join tbMenu m on rmb.MenuId=m.Id");
            strSql.Append(" join tbButton b on rmb.ButtonId=b.Id");
            strSql.Append(" where u.Id=@Id and m.Code=@MenuCode order by b.Sort");
            SqlParameter[] paras = {
                                   new SqlParameter("@Id",userId),
                                   new SqlParameter("@MenuCode",menuCode)
                                   };

            return ZGZY.Common.SqlHelper.GetDataTable(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strSql.ToString(), paras);
        }

        public Model.Customers GetCustomersById(object ID)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from Customers where Id=@id");
            using (SqlConnection con = new SqlConnection(ZGZY.Common.SqlHelper.connStr))
            {
                con.Open();
                SqlCommand com = new SqlCommand(strsql.ToString(),con);
                com.Parameters.Add(new SqlParameter("@id", ID));
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    ZGZY.Model.Customers model = new Model.Customers();
                    model.Id =int.Parse(read["id"].ToString());
                    model.State = int.Parse(read["State"].ToString());
                    model.CusType = int.Parse(read["CusType"].ToString());
                    model.CusLevel = int.Parse(read["CusLevel"].ToString());
                    model.CusCode = read["CusCode"].ToString();
                    model.CusName = read["CusName"].ToString();
                    model.CreateDate =DateTime.Parse(read["CreateDate"].ToString());
                    model.SalesmanId = int.Parse(read["SalesmanId"].ToString());
                    model.ServicerId = int.Parse(read["ServicerId"].ToString());
                    model.Remark = read["Remark"].ToString();
                    return model;
                }
            }
            return null;
        }

        public SqlDataReader GetCustomersTbaleNoP()
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("Select * from Customers");
            return ZGZY.Common.SqlHelper.ExecuteReader(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strsql.ToString());
        }
      

    }
}
