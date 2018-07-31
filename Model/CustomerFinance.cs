using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    public class CustomerFinance
    {
        public int Id { get; set; }
        public int FinanceId { get; set; }
        public int CusId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
