﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDataManager.Library
{
    public class ConfigHelper

    {
            //TODO:   Move this from config to the API
            public static decimal getTaxRate()
            {
                string rateText = ConfigurationManager.AppSettings["taxRate"];

                if (decimal.TryParse(rateText, out decimal output) == false)
                {
                    throw new ConfigurationErrorsException("The tax rate is not setup correctly");
                }

                return output;
            }
        }
}
