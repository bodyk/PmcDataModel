using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Models.Collections
{
    public enum PosDataType
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

        Container<T> IIndexable<Container<T>>.this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Container<T>(Config);
            }
        }

        public Pmc(Configuration<T> config) : base(config)
        {
        }

        public IEnumerator<Container<T>> GetEnumerator()
        {
            for (var i = 0; i < Config.CountContainers; i++)
            {
                yield return new Container<T>(Config);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Config.CountContainers;
        }
    }
}
