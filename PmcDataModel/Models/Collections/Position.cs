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
    /// Collection with Points
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Position<T> : ConfigurableCollection<T>, IIndexable<Point<T>>, IEnumerable<Point<T>>
    {
        private readonly int _containerIndex;

        public Point<T> this[int index]
        {
            get
            {
                if (!IsValidIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return new Point<T>(GetPointDimension(), Config.DataValue);
            }
        }

        public IEnumerator<Point<T>> GetEnumerator()
        {
            for (var i = 0; i < Config.CountContainers; i++)
            {
                yield return new Point<T>(Config.MatrixConfig.DefaultPointDimension, Config.DataValue);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Position(PmcConfiguration<T> config, int containerIndex) : base(config)
        {
            _containerIndex = containerIndex;
        }

        protected override bool IsValidIndex(int i)
        {
            return i < Config.CountPoints;
        }

        private PointDimension GetPointDimension()
        {
            var conteinerNumberToDimension = Config.MatrixConfig.NumberToDimensionRules
                .FirstOrDefault(r => r.MatrixNumbers.Contains(_containerIndex));

            return conteinerNumberToDimension?.Dimension ?? Config.MatrixConfig.DefaultPointDimension;
        }
    }
}
