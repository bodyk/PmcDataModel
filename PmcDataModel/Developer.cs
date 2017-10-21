using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    public abstract class Developer<T>
    {
        public PmcConfiguration<T> Config { get; set; }

        protected Developer(PmcConfiguration<T> config)
        {
            Config = config;
        }

        public abstract Pmc<T> Create();
    }
}
