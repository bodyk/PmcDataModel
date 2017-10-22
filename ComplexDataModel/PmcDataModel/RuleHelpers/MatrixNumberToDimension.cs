using System.Collections.Generic;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.RuleHelpers
{
    /// <summary>
    /// IndexInContainer To Dimension relation
    /// </summary>
    public class MatrixNumberToDimension
    {
        #region Properties

        /// <summary>
        /// Matrix indexes inside containers
        /// </summary>
        public List<int> IndexInContainer { get; set; }

        /// <summary>
        /// Point dimension (X, XY, XYZ)
        /// </summary>
        public PointDimension Dimension { get; set; }

        #endregion
    }
}
