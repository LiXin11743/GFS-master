using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZGZY.Model;

namespace ZGZY.BLL
{
    public class Finance
    {
        private static readonly ZGZY.IDAL.IFinance dal = ZGZY.DALFactory.Factory.GetFinanceDAL();

        public int AddFinance(Model.Finance Model)
        {
            return dal.AddFinance(Model);
        }
        public int DeleteFinanceByFinanceID(object Id)
        {
            return dal.DeleteFinanceByFinanceID(Id);
        }
        public int EditFinanceByFinanceID(Model.Finance Model)
        {
            return dal.EditFinanceByFinanceID(Model);
        }
        public SqlDataReader GetFinanceByID(object ID)
        {

            return dal.GetFinanceByID(ID);
        }
        public DataTable GetFinanceDataByWhere(string Where, List<SqlParameter> ParameList)
        {
            return dal.GetFinanceDataByWhere(Where, ParameList);
        }
        public VW_GetEndDateAndBeginDateByChannelID Get_VWDate(object ChannelID)
        {
            if (ChannelID != null)
            {
                return dal.Get_VWDate(ChannelID);
            }
            return null;
        }
        public List<Model.VW_GetEndDateAndBeginDateByChannelID> GetFinanceFromCombobox()
        {
            List<Model.VW_GetEndDateAndBeginDateByChannelID> list = new List<VW_GetEndDateAndBeginDateByChannelID>();
            SqlDataReader read = dal.GetFinanceFromCombobox();
            while (read.Read())
            {
                list.Add(new VW_GetEndDateAndBeginDateByChannelID()
                {
                    Id = Int32.Parse(read["Id"].ToString()),
                    ChannelName = read["ChannelName"].ToString(),
                    GetBeginDate = DateTime.Parse(read["GetBeginDate"].ToString()),
                    GetEndDate = DateTime.Parse(read["GetEndDate"].ToString())
                });
            }

            return list;

        }
    }
}
