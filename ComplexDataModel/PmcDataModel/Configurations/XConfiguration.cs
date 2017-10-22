using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Store XRule collection and DefaultCountPoints 
    /// </summary>
    public class XConfiguration
    {
        #region Properties

        /// <summary>
        /// Default value for points count
        /// </summary>
        public int? DefaultCountPoints { get; set; }

        /// <summary>
        /// XRule collection
        /// </summary>
        public List<XRule> Rules { get; set; }

        #endregion
    }
}
