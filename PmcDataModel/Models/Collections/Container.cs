using System;
using System.Collections;
using System.Collections.Generic;
using PmcDataModel.Configurations;
using PmcDataModel.Exceptions;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with Matrices
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Container<T> : ConfigurableCollection<T>, IIndexable<Matrix<T>>, IEnumerable<Matrix<T>>
    {
        private readonly int _indexInPmc;

        /// <inheritdoc />
        public override int Count => Config.CountMatrices;

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">Special index</param>
        /// <exception cref="ContainerIndexOutOfRangeException"></exception>
        public Matrix<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new ContainerIndexOutOfRangeException(index, typeof(Matrix<int>).Name);
                }
                
                return new Matrix<T>(Config, DataValue, _indexInPmc, index);
            }
        }

        /// <summary>
        /// Returns enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Matrix<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Matrix<T>(Config, DataValue, _indexInPmc, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Container Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        /// <param name="indexInPmc"></param>
        public Container(PmcConfiguration config, T value, int indexInPmc) : base(config, value)
        {
            _indexInPmc = indexInPmc;
        }
    }
}
