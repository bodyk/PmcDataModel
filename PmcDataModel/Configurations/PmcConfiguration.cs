using System.Linq;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Handle all configurations
    /// </summary>
    public class PmcConfiguration
    {
        /// <summary>
        /// Count Containers in collection
        /// </summary>
        public int CountContainers { get; set; }

        /// <summary>
        /// Count Matrices in collection
        /// </summary>
        public int CountMatrices { get; set; }

        /// <summary>
        /// Count Positions in collection
        /// </summary>
        public int CountPositions { get; set; }

        /// <summary>
        /// Count Points in collection
        /// </summary>
        public int CountPoints { get; set; }

        /// <summary>
        /// Represent configuration for matrices
        /// </summary>
        public MatrixConfiguration MatrixConfig { get; set; } = new MatrixConfiguration();

        /// <summary>
        /// Store XRule collection and DefaultCountPoints 
        /// </summary>
        public XConfiguration XConfig { get; set; } = new XConfiguration();

        /// <summary>
        /// Store XyRule collection and DefaultCountPoints 
        /// </summary>
        public XyConfiguration XyConfig { get; set; } = new XyConfiguration();

        /// <summary>
        /// Store XyzRule collection and DefaultCountPoints 
        /// </summary>
        public XyzConfiguration XyzConfig { get; set; } = new XyzConfiguration();

        /// <summary>
        /// Helper method to get dimension base on matrix index inside container
        /// </summary>
        /// <param name="indexInContainer"></param>
        /// <returns></returns>
        public PointDimension GetPointDimension(int indexInContainer)
        {
            var containerNumberToDimension = MatrixConfig.MatrixNumberToDimensionRules
                .FirstOrDefault(r => r.IndexInContainer.Contains(indexInContainer));

            return containerNumberToDimension?.Dimension ?? MatrixConfig.DefaultPointDimension;
        }

        /// <summary>
        /// Helper method to get points count base on matrix index inside container and XyzRule
        /// </summary>
        /// <param name="indexInContainer"></param>
        /// <returns></returns>
        public int GetCountPointsXyzRule(int indexInContainer)
        {
            if (GetPointDimension(indexInContainer) == PointDimension.Xyz)
            {
                var customPositionCount = XyzConfig.Rules?.FirstOrDefault(r => r.IndexInContainer == indexInContainer)?.CountPositions;

                return customPositionCount ?? XyzConfig.DefaultCountPositions ?? CountPositions;
            }
            else
            {
                return CountPositions;
            }
        }

        /// <summary>
        /// Helper method to get points count base on matrix index inside container and XyRule, XRule
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="indexInContainer"></param>
        /// <param name="indexInMatrix"></param>
        /// <returns></returns>
        public int GetCountPointsXyAndXRule(PointDimension dimension, int indexInContainer, int indexInMatrix)
        {
            switch (dimension)
            {
                case PointDimension.Xy:
                {
                    var path = new PointPath
                    {
                        IndexInContainer = indexInContainer,
                        IndexInMatrix = indexInMatrix
                    };

                    var customPointsNumber = XyConfig.Rules?.FirstOrDefault(r => r.Path.Equals(path))?.CountPoints;

                    return customPointsNumber ?? XyConfig.DefaultCountPoints ?? CountPoints;
                }
                case PointDimension.X:
                {
                    var path = new PointPath
                    {
                        IndexInContainer = indexInContainer,
                        IndexInMatrix = indexInMatrix
                    };

                    var customPointsNumber = XConfig.Rules?.FirstOrDefault(r => r.Path.Equals(path))?.CountPoints;

                    return customPointsNumber ?? XyConfig.DefaultCountPoints ?? CountPoints;
                }
                default:
                    return CountPoints;
            }
        }
    }
}
