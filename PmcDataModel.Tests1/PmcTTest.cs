// <copyright file="PmcTTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.Models.Collections.Tests
{
    /// <summary>This class contains parameterized unit tests for Pmc`1</summary>
    [PexClass(typeof(Pmc<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class PmcTTest
    {
        /// <summary>Test stub for .ctor(PmcConfiguration`1&lt;!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Pmc<T> ConstructorTest<T>(PmcConfiguration<T> config)
        {
            Pmc<T> target = new Pmc<T>(config);
            return target;
            // TODO: add assertions to method PmcTTest.ConstructorTest(PmcConfiguration`1<!!0>)
        }

        /// <summary>Test stub for get_Count()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int CountGetTest<T>([PexAssumeUnderTest]Pmc<T> target)
        {
            int result = target.Count;
            return result;
            // TODO: add assertions to method PmcTTest.CountGetTest(Pmc`1<!!0>)
        }

        /// <summary>Test stub for GetEnumerator()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IEnumerator<Container<T>> GetEnumeratorTest<T>([PexAssumeUnderTest]Pmc<T> target)
        {
            IEnumerator<Container<T>> result = target.GetEnumerator();
            return result;
            // TODO: add assertions to method PmcTTest.GetEnumeratorTest(Pmc`1<!!0>)
        }

        /// <summary>Test stub for get_Item(Int32)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Container<T> ItemGetTest<T>([PexAssumeUnderTest]Pmc<T> target, int index)
        {
            Container<T> result = target[index];
            return result;
            // TODO: add assertions to method PmcTTest.ItemGetTest(Pmc`1<!!0>, Int32)
        }
    }
}
