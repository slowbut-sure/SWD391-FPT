using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.RequestRequest
{
    public class UpdateRequest
    {
        public int ApartmentId { get; set; }
        public string RequestDescription { get; set; }
        public DateTime rqBookDateTime { get; set; }
        public DateTime rqEndDate { get; set; }
        public bool rqIsSequence { get; set; }
        public int RequestSequence { get; set; }
        public string ReqStatus { get; set; }
    }
}
