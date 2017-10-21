using PmcDataModel.Configurations;

namespace PmcDataModel.Models.Collections
{
    public abstract class ConfigurableCollection<T>
    {
        public abstract int Count { get; }
        public PmcConfiguration<T> Config { get; set; }

        protected ConfigurableCollection(PmcConfiguration<T> config)
        {
            Config = config;
        }

        protected bool IsValidIndex(int i)
        {
            return i < Count;
        }
    }
}
