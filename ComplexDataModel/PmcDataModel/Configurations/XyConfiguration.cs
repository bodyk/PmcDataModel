using System.Collections.Generic;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Store XyRule collection and DefaultCountPoints 
    /// </summary>
    public class XyConfiguration
    {
        #region Properties

        /// <summary>
        /// Default value for points count
        /// </summary>
        public int? DefaultCountPoints { get; set; }

        /// <summary>
        /// XyRule collection
        /// </summary>
        public List<XyRule> Rules { get; set; }

        #endregion
    }
}
