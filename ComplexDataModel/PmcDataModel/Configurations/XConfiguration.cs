using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmcDataModel.Configurations
{
    public class XConfiguration
    {
        public int DefaultCountPoints { get; set; } = 2;

        public List<XRule> Rules { get; set; }
    }
}
