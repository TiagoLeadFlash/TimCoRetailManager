﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Helpers;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public class ProductEndpoint : IProductEndpoint
    {
        private IAPIHelper _apiHelper;

        public ProductEndpoint(IAPIHelper apihelper)
        {
            _apiHelper = apihelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ProductModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}