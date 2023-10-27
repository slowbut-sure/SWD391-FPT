using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.Asset
{
    public class ResponseOfAssetHistory
    {
        public int AssetHistoryId { get; set; }

        public string Code { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string ItemImage { get; set; }

        public string Status { get; set; }
    }
}
