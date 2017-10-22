using System;

namespace PmcDataModel.Exceptions
{
    public class ContainerIndexOutOfRangeException : Exception
    {
        public ContainerIndexOutOfRangeException(int index, string typeName)
            : base($"{index} is invalid {typeName} index")
        {
            
        }
    }
}
