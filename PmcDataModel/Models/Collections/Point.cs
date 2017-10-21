using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Configurations;

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
                case PointDimension.XY:
                    DataValue.AddRange(Enumerable.Repeat(dataValue, 2));
                    break;
                case PointDimension.XYZ:
                    DataValue.AddRange(Enumerable.Repeat(dataValue, 3));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
