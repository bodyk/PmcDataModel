using System.Collections.Generic;

namespace PmcDataModel.Configurations
{
    public class XyzConfiguration
    {
        public int DefaultCountPositions { get; set; } = 2;

        public List<XyzRule> Rules { get; set; }
    }
}
