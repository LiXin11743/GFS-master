using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
   public class VW_GetEndDateAndBeginDateByChannelID
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public DateTime GetBeginDate { get; set; }
        public DateTime GetEndDate { get; set; }
    }
}
