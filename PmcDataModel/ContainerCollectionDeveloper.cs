using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;

namespace PmcDataModel
{
    /// <summary>
    /// Factory Method realization
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ContainerCollectionDeveloper<T>: Developer<T> where T: struct 
    {

        /// <summary>
        /// Handle configuration by constructor
        /// </summary>
        /// <param name="config"></param>
        public ContainerCollectionDeveloper(PmcConfiguration config) : base(config)
        {
        }

        /// <inheritdoc />
        public override Pmc<T> Create(T value)
        {
            return new Pmc<T>(Config, value);
        }
    }
}
