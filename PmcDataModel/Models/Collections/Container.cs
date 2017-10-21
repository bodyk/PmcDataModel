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

        public override int Count => Config.CountMatrices;

        public Matrix<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new ContainerIndexOutOfRangeException(index, typeof(Matrix<int>).Name);
                }
                
                return new Matrix<T>(Config, _indexInPmc, index);
            }
        }

        public IEnumerator<Matrix<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Matrix<T>(Config, _indexInPmc, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Container(PmcConfiguration<T> config, int indexInPmc) : base(config)
        {
            _indexInPmc = indexInPmc;
        }
    }
}
