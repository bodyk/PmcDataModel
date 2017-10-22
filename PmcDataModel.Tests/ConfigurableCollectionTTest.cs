// <copyright file="ConfigurableCollectionTTest.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.Models.Collections.Tests
{
    /// <summary>This class contains parameterized unit tests for ConfigurableCollection`1</summary>
    [TestFixture]
    [PexClass(typeof(ConfigurableCollection<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ConfigurableCollectionTTest
    {

        /// <summary>Test stub for get_Count()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int CountGetTest<T>([PexAssumeNotNull]ConfigurableCollection<T> target)
        {
            int result = target.Count;
            return result;
            // TODO: add assertions to method ConfigurableCollectionTTest.CountGetTest(ConfigurableCollection`1<!!0>)
        }
    }
}
