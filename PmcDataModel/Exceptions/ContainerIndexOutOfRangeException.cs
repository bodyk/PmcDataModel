using System;

namespace PmcDataModel.Exceptions
{
    /// <summary>
    /// Exception to show out of range in custom collections
    /// </summary>
    public class ContainerIndexOutOfRangeException : Exception
    {
        #region Constructor

        /// <summary>
        /// Form error message and pass to base constructor
        /// </summary>
        /// <param name="index"></param>
        /// <param name="typeName"></param>
        public ContainerIndexOutOfRangeException(int index, string typeName)
            : base($"{index} is invalid {typeName} index")
        {

        }

        #endregion
    }
}
