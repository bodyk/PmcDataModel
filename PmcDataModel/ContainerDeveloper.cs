using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    // build containers
    public class ContainerDeveloper<T>: Developer<T> where T: struct 
    {

        public ContainerDeveloper(Configuration<T> config) : base(config)
        {
        }

        public override Pmc<T> Create()
        {
            return new Pmc<T>(Config);
        }
    }
}
