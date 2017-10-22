using PmcDataModel.Configurations;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Base class for all custom collections
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ConfigurableCollection<T>
    {
        /// <summary>
        /// Count elements inside collection
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Contain all data configuration
        /// </summary>
        public PmcConfiguration Config { get; set; }


        /// <summary>
        /// Some numeric value, which will be inside containers
        /// </summary>
        public T DataValue { get; set; }

        /// <summary>
        /// Handle required params, ConfigurableCollection Constructor
        /// </summary>
        /// <param name="config">Contain all data configuration</param>
        /// <param name="value">Some numeric value, which will be inside containers</param>
        protected ConfigurableCollection(PmcConfiguration config, T value)
        {
            Config = config;
            DataValue = value;
        }

        /// <summary>
        /// Check is index is not out of collection range
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        protected bool IsValidIndex(int i)
        {
            return i < Count;
        }
    }
}
