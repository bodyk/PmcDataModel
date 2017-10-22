using System.Linq;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.Configurations
{
    public class PmcConfiguration
    {
        public int CountContainers { get; set; }
        public int CountMatrices { get; set; }
        public int CountPositions { get; set; }
        public int CountPoints { get; set; }
        public MatrixConfiguration MatrixConfig { get; set; }
        public XConfiguration XConfig { get; set; } = new XConfiguration();
        public XyConfiguration XyConfig { get; set; } = new XyConfiguration();
        public XyzConfiguration XyzConfig { get; set; } = new XyzConfiguration();

        public PointDimension GetPointDimension(int indexInContainer)
        {
            var conteinerNumberToDimension = MatrixConfig.MatrixNumberToDimensionRules
                .FirstOrDefault(r => r.MatrixNumbers.Contains(indexInContainer));

            return conteinerNumberToDimension?.Dimension ?? MatrixConfig.DefaultPointDimension;
        }

        public int GetCountPointsXyzRule(int indexInContainer)
        {
            if (GetPointDimension(indexInContainer) == PointDimension.Xyz)
            {
                var customPositionCount = XyzConfig.Rules?.FirstOrDefault(r => r.MatrixNumber == indexInContainer)?.CountPositions;

                return customPositionCount ?? XyzConfig.DefaultCountPositions;
            }
            else
            {
                return CountPositions;
            }
        }

        public int GetCountPointsXyRule(PointDimension dimension, int indexInContainer, int indexInMatrix)
        {
            if (dimension == PointDimension.Xy)
            {
                var path = new PointPath
                {
                    MatrixNumber = indexInContainer,
                    PositionNumber = indexInMatrix
                };

                var customPointsNumber = XyConfig.Rules?.FirstOrDefault(r => r.Path.Equals(path))?.CountPoints;

                return customPointsNumber ?? XyConfig.DefaultCountPoints;
            }
            else if (dimension == PointDimension.X)
            {
                var path = new PointPath
                {
                    MatrixNumber = indexInContainer,
                    PositionNumber = indexInMatrix
                };

                var customPointsNumber = XConfig.Rules?.FirstOrDefault(r => r.Path.Equals(path))?.CountPoints;

                return customPointsNumber ?? XyConfig.DefaultCountPoints;
            }
            else
            {
                return CountPoints;
            }
        }
    }
}
