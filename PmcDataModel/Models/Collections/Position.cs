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

        public PointDimension Dimension { get; set; }

        public override int Count => GetCountPoints();

        public Point<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new ContainerIndexOutOfRangeException(index, typeof(Point<int>).Name);
                }

                return new Point<T>(Dimension, Config.DataValue);
            }
        }

        public IEnumerator<Point<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Point<T>(Config.MatrixConfig.DefaultPointDimension, Config.DataValue);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Position(PmcConfiguration<T> config, int indexInPmc, int indexInContainer, int indexInMatrix, PointDimension dimension) : base(config)
        {
            _indexInPmc = indexInPmc;
            _indexInContainer = indexInContainer;
            _indexInMatrix = indexInMatrix;

            Dimension = dimension;
        }

        private int GetCountPoints()
        {
            return Config.GetCountPointsXyRule(Dimension, _indexInContainer, _indexInMatrix);
        }
    }
}
