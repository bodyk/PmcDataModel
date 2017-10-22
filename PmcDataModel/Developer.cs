using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    public abstract class Developer<T>
    {
        public PmcConfiguration Config { get; set; }

        protected Developer(PmcConfiguration config)
        {
            Config = config;
        }

        public abstract Pmc<T> Create(T value);
    }
}
