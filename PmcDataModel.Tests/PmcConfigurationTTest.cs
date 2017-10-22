using PmcDataModel.Models.Collections;
// <copyright file="PmcConfigurationTTest.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using PmcDataModel.Configurations;

namespace PmcDataModel.Configurations.Tests
{
    /// <summary>This class contains parameterized unit tests for PmcConfiguration`1</summary>
    [TestFixture]
    [PexClass(typeof(PmcConfiguration<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class PmcConfigurationTTest
    {

        /// <summary>Test stub for .ctor()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public PmcConfiguration<T> ConstructorTest<T>()
        {
            PmcConfiguration<T> target = new PmcConfiguration<T>();
            return target;
            // TODO: add assertions to method PmcConfigurationTTest.ConstructorTest()
        }

        /// <summary>Test stub for GetCountPointsXyRule(PointDimension, Int32, Int32)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int GetCountPointsXyRuleTest<T>(
            [PexAssumeUnderTest]PmcConfiguration<T> target,
            PointDimension dimension,
            int indexInContainer,
            int indexInMatrix
        )
        {
            int result = target.GetCountPointsXyRule(dimension, indexInContainer, indexInMatrix);
            return result;
            // TODO: add assertions to method PmcConfigurationTTest.GetCountPointsXyRuleTest(PmcConfiguration`1<!!0>, PointDimension, Int32, Int32)
        }

        /// <summary>Test stub for GetCountPointsXyzRule(Int32)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int GetCountPointsXyzRuleTest<T>([PexAssumeUnderTest]PmcConfiguration<T> target, int indexInContainer)
        {
            int result = target.GetCountPointsXyzRule(indexInContainer);
            return result;
            // TODO: add assertions to method PmcConfigurationTTest.GetCountPointsXyzRuleTest(PmcConfiguration`1<!!0>, Int32)
        }

        /// <summary>Test stub for GetPointDimension(Int32)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public PointDimension GetPointDimensionTest<T>([PexAssumeUnderTest]PmcConfiguration<T> target, int indexInContainer)
        {
            PointDimension result = target.GetPointDimension(indexInContainer);
            return result;
            // TODO: add assertions to method PmcConfigurationTTest.GetPointDimensionTest(PmcConfiguration`1<!!0>, Int32)
        }
    }
}
