using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ZGZY.IDAL
{
  public interface IChannel
    {
        SqlDataReader GetChannelTableNoP();
        int DeleteChannelById(object Id);
        int EditChannelById(ZGZY.Model.Channel Model);
        int AddChannel(ZGZY.Model.Channel Model);
        ZGZY.Model.Channel GetChannelById(object Id);
        DataTable GetButtonByMenuCodeAndUserId(string menuCode, int userId);
    }
}
