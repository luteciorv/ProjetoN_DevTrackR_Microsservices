using DevTrackR.ShippingOrders.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrackR.ShippingOrders.Application.Services.Interfaces
{
    public interface IShippingService
    {
        Task<List<ShippingServiceViewModel>> GetAllAsync();
    }
}
