namespace PmcDataModel.Models
{
    /// <summary>
    /// Represent path to specific point (contains matrix and position indexes)
    /// </summary>
    public class PointPath
    {
        #region Properties

        /// <summary>
        /// Matrix index inside container
        /// </summary>
        public int? IndexInContainer { get; set; }

        /// <summary>
        /// Position index inside matrix
        /// </summary>
        public int IndexInMatrix { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Compare two PointPath values
        /// </summary>
        /// <param name="other">point with which is compared</param>
        /// <returns>Comparison result</returns>
        public bool Equals(PointPath other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.IndexInContainer == null || IndexInContainer == null)
            {
                return other.IndexInMatrix == IndexInMatrix;
            }

            return other.IndexInContainer == IndexInContainer && other.IndexInMatrix == IndexInMatrix;
        }

        #endregion
    }
}
