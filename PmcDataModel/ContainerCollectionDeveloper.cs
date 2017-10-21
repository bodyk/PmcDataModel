using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    // build containers
    public class ContainerCollectionDeveloper<T>: Developer<T> where T: struct 
    {

        public ContainerCollectionDeveloper(PmcConfiguration<T> config) : base(config)
        {
        }

        public override Pmc<T> Create()
        {
            return new Pmc<T>(Config);
        }
    }
}
