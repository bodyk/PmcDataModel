using PmcDataModel.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with Positions
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Matrix<T> : ConfigurableCollection<T>, IIndexable<Position<T>>, IEnumerable<Position<T>>
    {
        private readonly int _indexInPmc;
        private readonly int _indexInContainer;

        public override int Count => GetCountPoints();

        public Position<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Position<T>(Config, _indexInPmc, _indexInContainer, index, GetPointDimension());
            }
        }

        public IEnumerator<Position<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Position<T>(Config, _indexInPmc, _indexInContainer, i, GetPointDimension());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Matrix(PmcConfiguration<T> config, int indexInPmc, int indexInContainer) : base(config)
        {
            _indexInPmc = indexInPmc;
            _indexInContainer = indexInContainer;
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
            if (GetPointDimension() == PointDimension.XYZ)
            {
                var customPositionCount = Config.XyzConfig.Rules?.FirstOrDefault(r => r.MatrixNumber == _indexInContainer)?.CountPositions;

                return customPositionCount ?? Config.XyzConfig.DefaultCountPositions;
            }
            else
            {
                return Config.CountPositions;
            }
        }
    }
}
