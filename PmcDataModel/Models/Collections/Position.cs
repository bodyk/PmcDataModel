using PmcDataModel.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PmcDataModel.Exceptions;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with Points
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Position<T> : ConfigurableCollection<T>, IIndexable<Point<T>>, IEnumerable<Point<T>>
    {
        private readonly int _indexInPmc;
        private readonly int _indexInContainer;
        private readonly int _indexInMatrix;

        /// <summary>
        /// (X, XY, XYZ)
        /// </summary>
        public PointDimension Dimension { get; set; }

        /// <inheritdoc />
        public override int Count => GetCountPoints();

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">Special index</param>
        /// <exception cref="ContainerIndexOutOfRangeException"></exception>
        public Point<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new ContainerIndexOutOfRangeException(index, typeof(Point<int>).Name);
                }

                return new Point<T>(Dimension, DataValue);
            }
        }

        /// <summary>
        /// Returns enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Point<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Point<T>(Config.MatrixConfig.DefaultPointDimension, DataValue);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Position Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        /// <param name="indexInPmc"></param>
        /// <param name="indexInContainer"></param>
        /// <param name="indexInMatrix"></param>
        /// <param name="dimension"></param>
        public Position(PmcConfiguration config, T value, int indexInPmc, int indexInContainer, int indexInMatrix, PointDimension dimension) : base(config, value)
        {
            _indexInPmc = indexInPmc;
            _indexInContainer = indexInContainer;
            _indexInMatrix = indexInMatrix;

            Dimension = dimension;
        }

        private int GetCountPoints()
        {
            return Config.GetCountPointsXyAndXRule(Dimension, _indexInContainer, _indexInMatrix);
        }
    }
}
