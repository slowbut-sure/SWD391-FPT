using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums.Status
{
    public enum RequestEnum
    {
        PENDING=0,
        PROCESSING=1,
        WORKING=2,
        DONE=3,
        CANCELED=4
    }
}
