using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Configurations;

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

        public override int Count => Config.CountPositions;

        public Position<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Position<T>(Config, _indexInPmc, _indexInContainer, index);
            }
        }

        public IEnumerator<Position<T>> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return new Position<T>(Config, _indexInPmc, _indexInContainer, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Matrix(PmcConfiguration<T> config, int indexInPmc, int indexInContainer) : base(config)
        {
            _indexInPmc = indexInPmc;
            _indexInContainer = indexInContainer;
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Count;
        }
    }
}
