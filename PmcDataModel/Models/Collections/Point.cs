using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Models.Collections
{
    /// <summary>
    /// Collection with generic numeral type(number, decimal, double)
    /// </summary>
    /// <typeparam name="T">Stored datatype</typeparam>
    public class Point<T> : ConfigurableCollection<T>
    {
        public T DataValue { get; set; }

        public Point(Configuration<T> config) : base(config)
        {
            DataValue = config.DataValue;
        }

        protected override bool IsValidIndex(int i)
        {
            throw new NotImplementedException();
        }
    }
}
