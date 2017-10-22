using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Models;

namespace PmcDataModel.Configurations
{
    /// <summary>
    /// Represent XRule which describe in requirements
    /// </summary>
    public class XRule
    {
        /// <summary>
        /// Path to Point
        /// </summary>
        public PointPath Path { get; set; }

        /// <summary>
        /// Count point instances
        /// </summary>
        public int CountPoints { get; set; }
    }
}
