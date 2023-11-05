using ManagerApartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class RequestDetailView : RequestView
    {
        public List<Service>? AddOnList { get; set; }
    }
}
