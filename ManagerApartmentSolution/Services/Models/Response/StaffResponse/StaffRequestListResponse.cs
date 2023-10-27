using Services.Models.Response.Response.PackageResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Response.Response.StaffResponse
{
    public class StaffRequestListResponse
	{
		public int ApartmentId { get; set; }
		public int ApartmentOwnerId { get; set; }
		public string? ApartmentName { get; set; }
		public string? ApartmentTypeName { get; set; }
		public string? ApartmentOwner { get; set; }
		public DateTime? BookDateTime { get; set; }
		public DateTime? EndDate { get; set; }
        public ICollection<ResponseOfPackageIdName> Packages { get; set; }
		public string? PackageName { get; set; }
		public int NumberOfAddOnService { get; set; }
	}
}
