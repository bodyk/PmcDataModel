using System.Collections.Generic;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Store XyzRule collection and DefaultCountPositions 
    /// </summary>
    public class XyzConfiguration
    {
        /// <summary>
        /// Default value for positions count
        /// </summary>
        public int DefaultCountPositions { get; set; } = 2;

        /// <summary>
        /// XyzRule collection
        /// </summary>
        public List<XyzRule> Rules { get; set; }
    }
}
