using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Models.Collections
{
    public abstract class ConfigurableCollection<T>
    {
        public Configuration<T> Config { get; set; }

        protected ConfigurableCollection(Configuration<T> config)
        {
            Config = config;
        }

        protected abstract bool IsValidIndex(int i);
    }
}
