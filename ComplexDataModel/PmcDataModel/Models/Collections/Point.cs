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
        public List<T> DataValue { get; } = new List<T>();

        public PointDimension Dimension { get; private set; }

        public Point(PointDimension dimension, T dataValue)
        {
            Dimension = dimension;

            FormPoint(dataValue);
        }

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
    }
}
