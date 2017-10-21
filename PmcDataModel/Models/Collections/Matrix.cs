using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with Positions
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Matrix<T> : ConfigurableCollection<T>, IIndexable<Position<T>>, IEnumerable<Position<T>>
    {
        public Position<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Position<T>(Config);
            }
        }

        public IEnumerator<Position<T>> GetEnumerator()
        {
            for (var i = 0; i < Config.CountContainers; i++)
            {
                yield return new Position<T>(Config);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Matrix(Configuration<T> config) : base(config)
        {
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Config.CountMatrices;
        }
    }
}
