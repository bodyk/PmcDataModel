using PmcDataModel.Models;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Represent XyRule which describe in requirements
    /// </summary>
    public class XyRule
    {
        #region Properties

        /// <summary>
        /// Path to Point
        /// </summary>
        public PointPath Path { get; set; }

        /// <summary>
        /// Count point instances
        /// </summary>
        public int CountPoints { get; set; }

        #endregion
    }
}
