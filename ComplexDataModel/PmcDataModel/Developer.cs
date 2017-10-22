using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    /// <summary>
    /// Abstract base class to provide factory method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Developer<T>
    {
        #region Properties

        /// <summary>
        /// Value to store all configuration properties
        /// </summary>
        protected PmcConfiguration Config { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Init configuration from constructor
        /// </summary>
        /// <param name="config"></param>
        protected Developer(PmcConfiguration config)
        {
            Config = config;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method which return Pmc instance 
        /// </summary>
        /// <param name="value">Parametrized value(int, double or decimal)</param>
        /// <returns>Pmc instance</returns>
        public abstract Pmc<T> Create(T value);

        #endregion
    }
}
