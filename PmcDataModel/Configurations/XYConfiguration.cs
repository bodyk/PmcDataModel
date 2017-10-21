﻿using System.Collections.Generic;
using PmcDataModel.Models;

namespace PmcDataModel.Configurations
{
    public class XyConfiguration
    {
        public int DefaultCountPoints { get; set; } = 2;

        public List<XyRule> Rules { get; set; }
    }
}