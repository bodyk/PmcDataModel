using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with Points
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Position<T> : ConfigurableCollection<T>, IIndexable<Point<T>>, IEnumerable<Point<T>>
    {
        public Point<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Point<T>(Config);
            }
        }

        public IEnumerator<Point<T>> GetEnumerator()
        {
            for (var i = 0; i < Config.CountContainers; i++)
            {
                yield return new Point<T>(Config);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Position(Configuration<T> config) : base(config)
        {
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Config.CountPoints;
        }
    }
}
