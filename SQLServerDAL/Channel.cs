using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZGZY.Model;

namespace ZGZY.SQLServerDAL
{
    public class Channel : ZGZY.IDAL.IChannel
    {/// <summary>
    /// 用于新增引用
    /// </summary>
    /// <param name="Model"></param>
    /// <returns></returns>
        public int AddChannel(Model.Channel Model)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert Channel(CreateDate, ChannelName,Creator, SealNameId, BeginDate, EndDate) values(GETDATE(),@ChannelName,@Creator,@SealNameId,@BeginDate,@EndDate)");
            return ZGZY.Common.SqlHelper.ExecuteNonQuery(
                ZGZY.Common.SqlHelper.connStr,
                CommandType.Text, strsql.ToString(),
                new SqlParameter[] {
                        new SqlParameter("@ChannelName",Model.ChannelName),
                        new SqlParameter("@Creator",Model.Creator),
                        new SqlParameter("@SealNameId",Model.SealNameId),
                        new SqlParameter("@BeginDate",Model.BeginDate),
                        new SqlParameter("@EndDate",Model.EndDate)
                });
        }
        /// <summary>
        /// 用于删除引用
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteChannelById(object Id)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("delete Channel where Id=@Id");
            return ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strsql.ToString(), new SqlParameter[] { new SqlParameter("@Id", Id) });
        }
        /// <summary>
        ///用于修改引用
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int EditChannelById(Model.Channel Model)
        {
            StringBuilder strsql = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            if (Model.ChannelName != "" && Model.ChannelName != null)
                strsql.Append("ChannelName=@ChannelName,"); list.Add(new SqlParameter("@ChannelName", Model.ChannelName));
            if (Model.SealNameId != 0)
                strsql.Append("SealNameId=@SealNameId,"); list.Add(new SqlParameter("@SealNameId", Model.SealNameId));
            if (Model.BeginDate != null)
                strsql.Append("BeginDate=@BeginDate,"); list.Add(new SqlParameter("@BeginDate", Model.BeginDate));
            if (Model.EndDate != null)
                strsql.Append("EndDate=@EndDate,"); list.Add(new SqlParameter("@EndDate", Model.EndDate));
            if(Model.Creator!=null)
                strsql.Append("Creator=@Creator,"); list.Add(new SqlParameter("@Creator", Model.Creator));
            if (strsql.Length > 0)
            {
                strsql.Remove(strsql.Length - 1, 1);
                strsql.Append(" where Id=@Id ");
                list.Add(new SqlParameter("@Id", Model.Id));
            }
            return ZGZY.Common.SqlHelper.ExecuteNonQuery(ZGZY.Common.SqlHelper.connStr, CommandType.Text, " update Channel set " + strsql.ToString(), list.ToArray());
        }
        /// <summary>
        /// 用于更具id去查询某一引用
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Model.Channel GetChannelById(object Id)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from Channel where Id=@Id");
            SqlDataReader READ = ZGZY.Common.SqlHelper.ExecuteReader(ZGZY.Common.SqlHelper.connStr, CommandType.Text, strsql.ToString(), new SqlParameter[] { new SqlParameter("@Id", Id) });

            while (READ.Read())
            {
                ZGZY.Model.Channel model = new Model.Channel();
                //Id, ChannelName, CreateDate, Creator, SealNameId, BeginDate, EndDate
                model.Id = int.Parse(READ["id"].ToString());
                model.ChannelName = READ["ChannelName"].ToString();
                model.CreateDate = DateTime.Parse(READ["CreateDate"].ToString());
                model.Creator = READ["Creator"].ToString();
                model.SealNameId = Int32.Parse(READ["SealNameId"].ToString());
                model.BeginDate = DateTime.Parse(READ["BeginDate"].ToString());
                model.EndDate = DateTime.Parse(READ["EndDate"].ToString());
                return model;
            }
            return null;
        }
        /// <summary>
        /// 无参查询所有引用
        /// </summary>
        /// <returns></returns>
        public SqlDataReader GetChannelTableNoP()
        {
            string strsql = "select * from Channel ";
            return Common.SqlHelper.ExecuteReader(Common.SqlHelper.connStr,CommandType.Text,strsql,null);
        }
        /// <summary>
        ///查询当前用户是否拥有该页面权限 
        /// </summary>
        /// <param name="menuCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
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
    }
}
