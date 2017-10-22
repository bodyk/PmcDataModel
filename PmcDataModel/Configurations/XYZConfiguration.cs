using System.Collections.Generic;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Store XyzRule collection and DefaultCountPositions 
    /// </summary>
    public class XyzConfiguration
    {
        #region Properties

        /// <summary>
        /// Default value for positions count
        /// </summary>
        public int? DefaultCountPositions { get; set; }

        /// <summary>
        /// XyzRule collection
        /// </summary>
        public List<XyzRule> Rules { get; set; }

        #endregion
    }
}
