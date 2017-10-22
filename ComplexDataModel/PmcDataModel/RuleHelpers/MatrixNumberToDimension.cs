using System.Collections.Generic;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.RuleHelpers
{
    public class MatrixNumberToDimension
    {
        public List<int> MatrixNumbers { get; set; }

        public PointDimension Dimension { get; set; }
    }
}
