// <copyright file="MatrixConfigurationTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using PmcDataModel.Configurations;

namespace PmcDataModel.Configurations.Tests
{
    /// <summary>This class contains parameterized unit tests for MatrixConfiguration</summary>
    [PexClass(typeof(MatrixConfiguration))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class MatrixConfigurationTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public MatrixConfiguration ConstructorTest()
        {
            MatrixConfiguration target = new MatrixConfiguration();
            return target;
            // TODO: add assertions to method MatrixConfigurationTest.ConstructorTest()
        }
    }
}
