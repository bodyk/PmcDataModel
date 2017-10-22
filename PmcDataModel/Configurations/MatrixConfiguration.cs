using System.Collections.Generic;
using PmcDataModel.Models.Collections;
using PmcDataModel.RuleHelpers;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Configuration which show relation between matrix number and point dimension
    /// </summary>
    public class MatrixConfiguration
    {
        /// <summary>
        /// Default value for point dimension
        /// </summary>
        public PointDimension DefaultPointDimension { get; set; } = PointDimension.X;


        /// <summary>
        /// Relation between matrix number and point dimension
        /// </summary>
        public List<MatrixNumberToDimension> MatrixNumberToDimensionRules { get; set; } = new List<MatrixNumberToDimension>();
    }
}
