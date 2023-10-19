using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.AssetRequest
{
    public class UpdateAsset
    {
        public int AssetHistoryId { get; set; }

        public int ApartmentId { get; set; }

        public string AssetName { get; set; }

        public int Quantity { get; set; }

        public string AssetDescription { get; set; }

        public string ItemImage { get; set; }

        public string AssetStatus { get; set; }
    }
}
