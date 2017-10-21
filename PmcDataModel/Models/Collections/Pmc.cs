using PmcDataModel.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PmcDataModel.Models.Collections
{
    public enum PointDimension
    {
        X,
        XY,
        XYZ
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
                    throw new IndexOutOfRangeException();
                }

                return new Container<T>(Config, index);
            }
        }

        public Pmc(PmcConfiguration<T> config) : base(config)
        {
        }

        public IEnumerator<Container<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Container<T>(Config, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Count;
        }
    }
}
