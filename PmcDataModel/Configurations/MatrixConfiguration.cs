using System.Collections.Generic;
using PmcDataModel.Models.Collections;
using PmcDataModel.RuleHelpers;

namespace PmcDataModel.Configurations
{
    public class MatrixConfiguration
    {
        public PointDimension DefaultPointDimension { get; set; } = PointDimension.X;
        public List<MatrixNumberToDimension> MatrixNumberToDimensionRules { get; set; }
    }
}
