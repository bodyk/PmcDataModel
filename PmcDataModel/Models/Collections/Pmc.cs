using PmcDataModel.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using PmcDataModel.Exceptions;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Represent enumeration of point dimensions
    /// </summary>
    public enum PointDimension
    {
        /// <summary>
        /// 1D dimension
        /// </summary>
        X,
        /// <summary>
        /// 2D dimension
        /// </summary>
        Xy,
        /// <summary>
        /// 3D dimension
        /// </summary>
        Xyz
    }

    /// <summary>
    /// Main collection with containers
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Pmc<T> : ConfigurableCollection<T>, IIndexable<Container<T>>, IEnumerable<Container<T>>
    {
        #region Properties

        /// <inheritdoc />
        public override int Count => Config.CountContainers;

        #endregion

        #region Constructor

        /// <summary>
        /// Pmc Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        public Pmc(PmcConfiguration config, T value) : base(config, value)
        {
        }

        #endregion

        #region Indexable and foreach access methods

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="index">Special index</param>
        /// <exception cref="ContainerIndexOutOfRangeException"></exception>
        public Container<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new ContainerIndexOutOfRangeException(index, typeof(Container<int>).Name);
                }

                return new Container<T>(Config, DataValue, index);
            }
        }

        /// <summary>
        /// Returns enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Container<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Container<T>(Config, DataValue, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
