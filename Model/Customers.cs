using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    public class Customers
    {
        public int Id { get; set; }
        public string CusCode { get; set; }
        public string CusName { get; set; }
        public int State { get; set; }
        public int CusType { get; set; }
        public int CusLevel { get; set; }
        public DateTime CreateDate { get; set; }
        public int SalesmanId { get; set; }
        public int ServicerId { get; set; }
        public string Remark { get; set; }
    }
}
