using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.ResponseAssetHistoryByAssetId
{
    public class ResponseAssetHistory
    {
        public int AssetId { get; set; }
        public int AssetHistoryId { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string assHistoryDescription { get; set; }
        public int assHistoryQuantity { get; set; }
        public string assHistoryItemImage { get; set; }
        public string assHistoryStatus { get; set; }
    }
}
