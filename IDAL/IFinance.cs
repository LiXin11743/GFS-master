using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ZGZY.IDAL
{
    public interface IFinance
    {
        int AddFinance(Model.Finance Model);
        int DeleteFinanceByFinanceID(object Id);
        int EditFinanceByFinanceID(Model.Finance Model);
        SqlDataReader GetFinanceByID(object ID);
        DataTable GetFinanceDataByWhere(string Where, List<SqlParameter> ParameList);
        Model.VW_GetEndDateAndBeginDateByChannelID Get_VWDate(object ChannelID);
        SqlDataReader GetFinanceFromCombobox();
    }
}
