using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Configurations;

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

        public override int Count => GetCountPoints();

        public Point<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Point<T>(GetPointDimension(), Config.DataValue);
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

        public Position(PmcConfiguration<T> config, int indexInPmc, int indexInContainer, int indexInMatrix) : base(config)
        {
            _indexInPmc = indexInPmc;
            _indexInContainer = indexInContainer;
            _indexInMatrix = indexInMatrix;
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Count;
        }

        private PointDimension GetPointDimension()
        {
            var conteinerNumberToDimension = Config.MatrixConfig.MatrixNumberToDimensionRules
                .FirstOrDefault(r => r.MatrixNumbers.Contains(_indexInContainer));

            return conteinerNumberToDimension?.Dimension ?? Config.MatrixConfig.DefaultPointDimension;
        }

        private int GetCountPoints()
        {
            if (GetPointDimension() == PointDimension.XY)
            {
                var path = new PositionPath
                {
                    MatrixNumber = _indexInContainer,
                    PositionNumber = _indexInMatrix
                };

                var customPointsNumber = Config.XyConfig.Rules?.FirstOrDefault(r => r.Path.Equals(path))?.CountPoints;

                return customPointsNumber ?? Config.XyConfig.DefaultCountPoints;
            }
            else
            {
                return Config.CountPoints;
            }
        }
    }
}
