using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZGZY.IDAL;
using ZGZY.Model;

namespace ZGZY.SQLServerDAL
{
    public class Finance : IDAL.IFinance
    {
        public int AddFinance(Model.Finance Model)
        {
            string sqlstr = @"insert into Finance
            (FinanceName, ChannelId, ManagerId, [State], CreateDate, FinanceType, Remark, Amount, FinanceNum) values
            (@FinanceName,@ChannelId,@ManagerId,@State,GETDATE(),@FinanceType,@Remark,@Amount,@FinanceNum)  SELECT SCOPE_IDENTITY()";
           return Int32.Parse(ZGZY.Common.SqlHelper.ExecuteScalar(ZGZY.Common.SqlHelper.connStr, CommandType.Text, sqlstr, new SqlParameter[] {
                new SqlParameter("@FinanceName",Model.FinanceName),
                new SqlParameter("@ChannelId",Model.ChannelId),
                new SqlParameter("@ManagerId",Model.ManagerId),
                new SqlParameter("@State",Model.State),
                new SqlParameter("@FinanceType",Model.FinanceType),
                new SqlParameter("@Remark",Model.Remark),
                new SqlParameter("@Amount",Model.Amount),
                new SqlParameter("@FinanceNum",Model.FinanceNum)
            }).ToString());
        }

        public int DeleteFinanceByFinanceID(object Id)
        {
            string sql = "delete Finance where Id=@Id";
            string sqlwhere = " where FinanceId=@FinanceId ";
            new ZGZY.SQLServerDAL.CustomerFinance().DeleteDataByWhere(sqlwhere,new List<SqlParameter>() {new SqlParameter("@FinanceId", Id) });
            return ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr,CommandType.Text,sql,new SqlParameter[] {new SqlParameter("@Id",Id) });
        }

        public int EditFinanceByFinanceID(Model.Finance Model)
        {
            StringBuilder SqlStr = new StringBuilder();
            List<SqlParameter> ParamList = new List<SqlParameter>();
            if (Model.FinanceName != null) SqlStr.Append("FinanceName=@FinanceName,");ParamList.Add(new SqlParameter( "@FinanceName", Model.FinanceName));
            if (Model.ChannelId != 0) SqlStr.Append("ChannelId=@ChannelId,"); ParamList.Add(new SqlParameter("@ChannelId", Model.ChannelId));
            if (Model.ManagerId != 0) SqlStr.Append("ManagerId=@ManagerId,"); ParamList.Add(new SqlParameter("@ManagerId", Model.ManagerId));
            if (Model.State != -1) SqlStr.Append("State=@State,"); ParamList.Add(new SqlParameter("@State", Model.State));
            if (Model.FinanceType != -1) SqlStr.Append("FinanceType=@FinanceType,"); ParamList.Add(new SqlParameter("@FinanceType", Model.FinanceType));
            if (Model.Remark != null) SqlStr.Append("Remark=@Remark,"); ParamList.Add(new SqlParameter("@Remark", Model.Remark));
            if (Model.FinanceNum != 0) SqlStr.Append("FinanceNum=@FinanceNum,"); ParamList.Add(new SqlParameter("@FinanceNum", Model.FinanceNum));
            if (Model.Amount != -1) SqlStr.Append("Amount=@Amount,"); ParamList.Add(new SqlParameter("@Amount", Model.Amount));
            if (ParamList.Count > 0) SqlStr.Remove(SqlStr.Length-1,1); SqlStr.Append(" where  Id=@Id"); ParamList.Add(new SqlParameter("@Id", Model.Id));
            return ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, " update Finance set " + SqlStr.ToString(), ParamList.ToArray());
        }

        public SqlDataReader GetFinanceByID(object ID)
        {
            string sql = "select * from Finance where Id=@Id";
            return Common.SqlHelper.ExecuteReader(Common.SqlHelper.connStr,CommandType.Text,sql,new SqlParameter[]{ new SqlParameter("@Id",ID)});
        }

        public DataTable GetFinanceDataByWhere(string Where, List<SqlParameter> ParameList)
        {
            String SQL = " SELECT * FROM  Finance WHERE 1=1 "+Where;
            return Common.SqlHelper.GetDataTable(Common.SqlHelper.connStr, CommandType.Text, SQL, ParameList.ToArray());
        }

        public SqlDataReader GetFinanceFromCombobox()
        {
            string sql = "select * from VW_GetEndDateAndBeginDateByChannelID ";
           return Common.SqlHelper.ExecuteReader(Common.SqlHelper.connStr, CommandType.Text, sql, null);
        }

        public VW_GetEndDateAndBeginDateByChannelID Get_VWDate(object ChannelID)
        {
            VW_GetEndDateAndBeginDateByChannelID model = null;
            string sql = "select * from VW_GetEndDateAndBeginDateByChannelID where Id =@ID";
            SqlDataReader read = Common.SqlHelper.ExecuteReader(Common.SqlHelper.connStr,CommandType.Text,sql,new SqlParameter[] {new SqlParameter("@ID",ChannelID) });
            while (read.Read())
            {
                model = new VW_GetEndDateAndBeginDateByChannelID();
                model.Id =Int32.Parse(read["Id"].ToString());
                model.ChannelName = read["ChannelName"].ToString();
                model.GetBeginDate =DateTime.Parse(read["GetBeginDate"].ToString());
                model.GetEndDate = DateTime.Parse(read["GetEndDate"].ToString());
            }
            return model;
        }
    }
}
