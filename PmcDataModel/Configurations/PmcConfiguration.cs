using System.Linq;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.Configurations
{
    public class PmcConfiguration<T>
    {
        public T DataValue { get; set; }
        public int CountContainers { get; set; }
        public int CountMatrices { get; set; }
        public int CountPositions { get; set; }
        public int CountPoints { get; set; }
        public MatrixConfiguration MatrixConfig { get; set; }
        public XyConfiguration XyConfig { get; set; }
        public XyzConfiguration XyzConfig { get; set; }

        public PointDimension GetPointDimension(int indexInContainer)
        {
            var conteinerNumberToDimension = MatrixConfig.MatrixNumberToDimensionRules
                .FirstOrDefault(r => r.MatrixNumbers.Contains(indexInContainer));

            return conteinerNumberToDimension?.Dimension ?? MatrixConfig.DefaultPointDimension;
        }

        public int GetCountPointsXyzRule(int indexInContainer)
        {
            if (GetPointDimension(indexInContainer) == PointDimension.XYZ)
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
            if (dimension == PointDimension.XY)
            {
                var path = new PointPath
                {
                    MatrixNumber = indexInContainer,
                    PositionNumber = indexInMatrix
                };

                var customPointsNumber = XyConfig.Rules?.FirstOrDefault(r => r.Path.Equals(path))?.CountPoints;

                return customPointsNumber ?? XyConfig.DefaultCountPoints;
            }
            else
            {
                return CountPoints;
            }
        }
    }
}
