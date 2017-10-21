﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Configurations;

namespace PmcDataModel.Models.Collections
{
    public abstract class ConfigurableCollection<T>
    {
        public PmcConfiguration<T> Config { get; set; }

        protected ConfigurableCollection(PmcConfiguration<T> config)
        {
            Config = config;
        }

        protected abstract bool IsValidIndex(int i);
    }
}