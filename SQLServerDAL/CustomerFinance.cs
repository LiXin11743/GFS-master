using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.Model;

namespace ZGZY.SQLServerDAL
{
    public class CustomerFinance : IDAL.ICustomerFinance
    {
        public int AddCustomerFinance(Model.CustomerFinance Model)
        {
            string sql= "insert into CustomerFinance(CusId, FinanceId, BeginDate, EndDate) values(@CusId, @FinanceId, @BeginDate, @EndDate)";
            return ZGZY.Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.connStr,CommandType.Text,sql,new SqlParameter[] {
                new SqlParameter("@CusId",Model.CusId),
                new SqlParameter("@FinanceId",Model.FinanceId),
                new SqlParameter("@BeginDate",Model.BeginDate),
                new SqlParameter("@EndDate",Model.EndDate)
            });
        }

        public int DeleteCustomerFinanceByCustomerFinanceID(object Id)
        {
            string sqlstr = "delete CustomerFinance where Id = @Id";
            return Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.connStr,CommandType.Text,sqlstr,new SqlParameter[] { new SqlParameter("@Id",Id)});
        }

        public int DeleteDataByWhere(string sql, List<SqlParameter> list)
        {
            string sqlstr = "delete CustomerFinance  "+sql;
            Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.connStr,CommandType.Text,sqlstr,list.ToArray());
            return 0;
        }

        public int EditCustomerFinanceByCustomerFinanceID(Model.CustomerFinance modelCusFin)
        {
            throw new NotImplementedException();
        }

        

        public int EditCustomerFinanceByFinanceId(Model.CustomerFinance modelCusFin)
        {
         
            //update CustomerFinance set  CusId=@CusId, BeginDate=@BeginDate, EndDate=@EndDate where FinanceId=@FinanceId
            StringBuilder str = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            if (modelCusFin.EndDate!=null) str.Append("EndDate=@EndDate,");list.Add(new SqlParameter("@EndDate",modelCusFin.EndDate));
            if (modelCusFin.BeginDate != null) str.Append("BeginDate=@BeginDate,"); list.Add(new SqlParameter("@BeginDate", modelCusFin.BeginDate));
            if (modelCusFin.CusId != 0) str.Append("CusId=@CusId,"); list.Add(new SqlParameter("@CusId", modelCusFin.CusId));
            if (str.Length>0)
            {
                str.Remove(str.Length-1,1);
                list.Add(new SqlParameter("@FinanceId",modelCusFin.FinanceId));
                return Common.SqlHelper.ExecuteNonQuery(Common.SqlHelper.connStr, CommandType.Text, " update CustomerFinance set " + str.ToString()+ " where FinanceId=@FinanceId", list.ToArray());
            }
            
            

            return 0;
        }

        public Model.CustomerFinance GetCustomerFinanceByID(object ID)
        {
            string sql = "select * from where Id=@Id";
            SqlDataReader READ = Common.SqlHelper.ExecuteReader(Common.SqlHelper.connStr,CommandType.Text,sql,new SqlParameter[] {new SqlParameter("@Id",ID) });
            Model.CustomerFinance model = null;
            while (READ.Read())
            {
                model = new Model.CustomerFinance();
                model.Id =Int32.Parse(READ["Id"].ToString());
                model.CusId = Int32.Parse(READ["CusId"].ToString());
                model.FinanceId = Int32.Parse(READ["FinanceId"].ToString());
                model.BeginDate = DateTime.Parse(READ["BeginDate"].ToString());
                model.EndDate = DateTime.Parse(READ["EndDate"].ToString());
                return model;
            }
            return model; 
        }

        public DataTable GetCustomerFinanceDataByWhere(string Where, List<SqlParameter> ParameList)
        {
            string wheresql = "select * from CustomerFinance where 1=1 "+Where;
            return Common.SqlHelper.GetDataTable(Common.SqlHelper.connStr,CommandType.Text,wheresql,ParameList.ToArray());
        }
    }
}
