﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with Matrices
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Container<T> : ConfigurableCollection<T>, IIndexable<Matrix<T>>, IEnumerable<Matrix<T>>
    {
        public Matrix<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Matrix<T>(Config);
            }
        }

        public IEnumerator<Matrix<T>> GetEnumerator()
        {
            for (var i = 0; i < Config.CountContainers; i++)
            {
                yield return new Matrix<T>(Config);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Container(Configuration<T> config) : base(config)
        {
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Config.CountMatrices;
        }
    }
}
