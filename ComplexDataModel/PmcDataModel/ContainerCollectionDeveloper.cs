using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    // build containers
    public class ContainerCollectionDeveloper<T>: Developer<T> where T: struct 
    {

        public ContainerCollectionDeveloper(PmcConfiguration config) : base(config)
        {
        }

        public override Pmc<T> Create(T value)
        {
            return new Pmc<T>(Config, value);
        }
    }
}
