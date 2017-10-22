using System;
using System.Collections.Generic;
using System.Linq;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with generic numeral type(number, decimal, double)
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Point<T>
    {
        #region Properties

        /// <summary>
        /// 1, 2 or 3 values depend on dimension
        /// </summary>
        public List<T> DataValue { get; } = new List<T>();

        /// <summary>
        /// (X, XY, XYZ)
        /// </summary>
        public PointDimension Dimension { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Point Constructor
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="dataValue"></param>
        public Point(PointDimension dimension, T dataValue)
        {
            Dimension = dimension;

            FormPoint(dataValue);
        }

        #endregion

        #region Private Methods

        private void FormPoint(T dataValue)
        {
            switch (Dimension)
            {
                case PointDimension.X:
                    DataValue.Add(dataValue);
                    break;
                case PointDimension.Xy:
                    DataValue.AddRange(Enumerable.Repeat(dataValue, 2));
                    break;
                case PointDimension.Xyz:
                    DataValue.AddRange(Enumerable.Repeat(dataValue, 3));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
