﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Models;

namespace PmcDataModel.Configurations
{
    public class XyRule
    {
        public PositionPath Path { get; set; }

        public int CountPoints { get; set; }
    }
}