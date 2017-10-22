using PmcDataModel.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using PmcDataModel.Exceptions;

namespace PmcDataModel.Models.Collections
{
    public enum PointDimension
    {
        X,
        Xy,
        Xyz
    }

    /// <summary>
    /// Main collection with containers
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Pmc<T> : ConfigurableCollection<T>, IIndexable<Container<T>>, IEnumerable<Container<T>>
    {
        public override int Count => Config.CountContainers;

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

        public Pmc(PmcConfiguration config, T value) : base(config, value)
        {
        }

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
    }
}
