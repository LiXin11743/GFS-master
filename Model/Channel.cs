using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZGZY.Model
{
    public class Channel
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Creator { get; set; }
        public int SealNameId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
