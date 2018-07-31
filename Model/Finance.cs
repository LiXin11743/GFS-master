using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    public class Finance
    {
        public int Id { get; set; }

        public string FinanceName { get; set; }

        public int ChannelId { get; set; }

        public int ManagerId { get; set; }

        public int State { get; set; }

        public DateTime CreateDate { get; set; }

        public int FinanceType { get; set; }

        public string  Remark { get; set; }

        public int FinanceNum { get; set; }

        public double Amount { get; set; }
    }
}
