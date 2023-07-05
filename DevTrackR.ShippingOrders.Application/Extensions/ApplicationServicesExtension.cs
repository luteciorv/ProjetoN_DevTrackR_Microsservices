using DevTrackR.ShippingOrders.Application.Services;
using DevTrackR.ShippingOrders.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTrackR.ShippingOrders.Application.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderService, ShippingOrderService>();
            services.AddScoped<IShippingService, ShippingServiceService>();
        }
    }
}
