using PmcDataModel.Configurations;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Base class for all custom collections
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ConfigurableCollection<T>
    {
        #region Properties

        /// <summary>
        /// Count elements inside collection
        /// </summary>
        public abstract int Count { get; }

        /// <summary>
        /// Contain all data configuration
        /// </summary>
        protected PmcConfiguration Config { get; set; }


        /// <summary>
        /// Some numeric value, which will be inside containers
        /// </summary>
        public T DataValue { get; }

        #endregion

        #region Constructor

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

        #endregion

        #region Methods

        /// <summary>
        /// Check is index is not out of collection range
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        protected bool IsValidIndex(int i)
        {
            return i < Count;
        }

        #endregion
    }
}
