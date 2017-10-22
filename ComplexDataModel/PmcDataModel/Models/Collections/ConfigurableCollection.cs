using PmcDataModel.Configurations;

namespace PmcDataModel.Models.Collections
{
    public abstract class ConfigurableCollection<T>
    {
        public abstract int Count { get; }
        public PmcConfiguration Config { get; set; }
        public T DataValue { get; set; }

        protected ConfigurableCollection(PmcConfiguration config, T value)
        {
            Config = config;
            DataValue = value;
        }

        protected bool IsValidIndex(int i)
        {
            return i < Count;
        }
    }
}
