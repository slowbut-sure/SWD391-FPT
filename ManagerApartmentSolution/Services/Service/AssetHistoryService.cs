﻿using ManagerApartment.Models;
using Services.Models.Response.Response.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Servicesss
{
    public interface AssetHistoryService
    {
        Task<List<ResponseOfAssetHistory>> GetAllAssetHistoris();
        Task<ResponseOfAssetHistory> GetAssetHistoryById(int id);
    }
}
