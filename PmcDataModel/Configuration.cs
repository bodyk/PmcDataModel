using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel
{
    public class Configuration<T>
    {
        public T DataValue { get; set; }
        public int CountContainers { get; set; }
        public int CountMatrices { get; set; }
        public int CountPositions { get; set; }
        public int CountPoints { get; set; }
    }
}
