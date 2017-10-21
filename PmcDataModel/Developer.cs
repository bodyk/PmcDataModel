using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    public abstract class Developer<T>
    {
        public Configuration<T> Config { get; set; }

        protected Developer(Configuration<T> config)
        {
            Config = config;
        }

        public abstract Pmc<T> Create();
    }
}
