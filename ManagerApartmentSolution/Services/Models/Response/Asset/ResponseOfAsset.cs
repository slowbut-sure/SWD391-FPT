using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Asset
{
    public class ResponseOfAsset
    {
        public int AssetId { get; set; }

        public int? AssetHistoryId { get; set; }

        public int? ApartmentId { get; set; }

        public string? Name { get; set; }

        public int? Quantity { get; set; }

        public string? Description { get; set; }

        public string? ItemImage { get; set; }

        public string? Status { get; set; }
    }
}
