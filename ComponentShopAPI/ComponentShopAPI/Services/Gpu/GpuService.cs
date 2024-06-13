﻿using ComponentShopAPI.Entities;
using ComponentShopAPI.Helpers;

namespace ComponentShopAPI.Services.GpuSearch
{
    public class GpuService : IGpuService
    {
        public GpuService() { }

        public List<Gpu> Search(List<Gpu> gpus, GpuQueryParameters queryParameters)
        {
            var queryResults = gpus.Where(gpu =>
                gpu.Name.IndexOf(queryParameters.Name, StringComparison.OrdinalIgnoreCase) >= 0 &&
                gpu.Price >= queryParameters.PriceLow &&
                gpu.Price < queryParameters.PriceHigh
                );
            if (queryParameters.AvailableOnly)
            {
                queryResults = queryResults.Where(gpu => gpu.Quantity > 0);
            }
            if (queryParameters.Memory != -1)
            {
                queryResults = queryResults.Where(gpu => gpu.Memory == queryParameters.Memory);
            }
            if (queryParameters.Slot != "")
            {
                queryResults = queryResults.Where(gpu => gpu.Slot == queryParameters.Slot);
            }
            if (queryParameters.Ports.Count > 0)
            {
                foreach (var port in queryParameters.Ports)
                {
                    queryResults = queryResults.Where(gpu => gpu.Ports.Contains(port));
                }
            }
            if (queryParameters.Sort == "Ascending")
            {
                queryResults = queryResults.OrderBy(gpu => gpu.Price);
            }
            if (queryParameters.Sort == "Descending")
            {
                queryResults = queryResults.OrderByDescending(gpu => gpu.Price);
            }

            return queryResults.ToList();
        }
    }
}
