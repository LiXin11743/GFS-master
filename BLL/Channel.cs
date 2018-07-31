using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.BLL
{
   public class Channel
    {
        private static readonly ZGZY.IDAL.IChannel dal = ZGZY.DALFactory.Factory.GetChannelDAL();
        public int DeleteChannelById(object Id) {
            return dal.DeleteChannelById(Id);
        }
        public Model.Channel GetChannelById(object Id)
        {
            return dal.GetChannelById(Id);
        }
        public int EditChannelById(Model.Channel model)
        {
            return dal.EditChannelById(model);
        }
        public int AddChannel(Model.Channel model)
        {
            return dal.AddChannel(model);
        }
        /// <summary>
        ///实例化当前所有channel 用于结算页面的下拉填充数据 
        /// </summary>
        /// <returns></returns>
        public List<Model.Channel> GetChannelTableNoP()
        {
           SqlDataReader read=  dal.GetChannelTableNoP();
            List<Model.Channel> list = new List<Model.Channel>();
            while (read.Read())
            {
                list.Add(new Model.Channel() {
                    Id = Int32.Parse(read["Id"].ToString()),
                    CreateDate = DateTime.Parse(read["CreateDate"].ToString()),
                    ChannelName = read["ChannelName"].ToString(),
                    BeginDate = DateTime.Parse(read["BeginDate"].ToString()),
                    EndDate = DateTime.Parse(read["EndDate"].ToString()),
                    Creator = read["Creator"].ToString(),
                    SealNameId = Int32.Parse(read["SealNameId"].ToString())
                });
            }
            return list;
        }
        public DataTable DeleteChannelById(string menuCode,int userId)
        {
            return dal.GetButtonByMenuCodeAndUserId(menuCode, userId);
        }
        public string GetPager(string tableName, string columns, string order, int pageSize, int pageIndex, string where, out int totalCount)
        {
            DataTable dt = ZGZY.Common.SqlPagerHelper.GetPager(tableName, columns, order, pageSize, pageIndex, where, out totalCount);
            return ZGZY.Common.JsonHelper.ToJson(dt);
        }
    }
}
