using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models.Request.ServiceRequest
{
    public class UpdateService
    {
        [Required(ErrorMessage = "The Service Code field is required.")]
        public string ServiceCode { get; set; } = null!;

        [Required(ErrorMessage = "The Service Price field is required.")]
        public decimal ServicePrice { get; set; }

        [Required(ErrorMessage = "The Service Unit field is required.")]
        public string ServiceUnit { get; set; } = null!;

        [Required(ErrorMessage = "The Service status field is required.")]
        public string ServiceStatus { get; set; } = null!;
    }
}
