﻿using PmcDataModel.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PmcDataModel.Exceptions;

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
        public PointDimension Dimension { get; set; }

        public Position<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new ContainerIndexOutOfRangeException(index, typeof(Position<int>).Name);
                }

                return new Position<T>(Config, DataValue, _indexInPmc, _indexInContainer, index, GetPointDimension());
            }
        }

        public IEnumerator<Position<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Position<T>(Config, DataValue, _indexInPmc, _indexInContainer, i, Dimension);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Matrix(PmcConfiguration config, T value, int indexInPmc, int indexInContainer) : base(config, value)
        {
            _indexInPmc = indexInPmc;
            _indexInContainer = indexInContainer;

            Dimension = GetPointDimension();
        }

        private PointDimension GetPointDimension()
        {
            return Config.GetPointDimension(_indexInContainer);
        }

        private int GetCountPoints()
        {
            return Config.GetCountPointsXyzRule(_indexInContainer);
        }
    }
}
