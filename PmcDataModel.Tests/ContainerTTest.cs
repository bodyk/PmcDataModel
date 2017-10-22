using System.Collections.Generic;
using PmcDataModel.Configurations;
// <copyright file="ContainerTTest.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using PmcDataModel.Models.Collections;

namespace PmcDataModel.Models.Collections.Tests
{
    /// <summary>This class contains parameterized unit tests for Container`1</summary>
    [TestFixture]
    [PexClass(typeof(Container<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ContainerTTest
    {

        /// <summary>Test stub for .ctor(PmcConfiguration`1&lt;!0&gt;, Int32)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Container<T> ConstructorTest<T>(PmcConfiguration<T> config, int indexInPmc)
        {
            Container<T> target = new Container<T>(config, indexInPmc);
            return target;
            // TODO: add assertions to method ContainerTTest.ConstructorTest(PmcConfiguration`1<!!0>, Int32)
        }

        /// <summary>Test stub for GetEnumerator()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IEnumerator<Matrix<T>> GetEnumeratorTest<T>([PexAssumeUnderTest]Container<T> target)
        {
            IEnumerator<Matrix<T>> result = target.GetEnumerator();
            return result;
            // TODO: add assertions to method ContainerTTest.GetEnumeratorTest(Container`1<!!0>)
        }

        /// <summary>Test stub for get_Count()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int CountGetTest<T>([PexAssumeUnderTest]Container<T> target)
        {
            int result = target.Count;
            return result;
            // TODO: add assertions to method ContainerTTest.CountGetTest(Container`1<!!0>)
        }

        /// <summary>Test stub for get_Item(Int32)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Matrix<T> ItemGetTest<T>([PexAssumeUnderTest]Container<T> target, int index)
        {
            Matrix<T> result = target[index];
            return result;
            // TODO: add assertions to method ContainerTTest.ItemGetTest(Container`1<!!0>, Int32)
        }
    }
}
