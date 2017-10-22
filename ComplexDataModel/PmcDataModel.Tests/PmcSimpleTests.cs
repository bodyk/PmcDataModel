using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PmcDataModel.Configurations;
using PmcDataModel.Exceptions;
using PmcDataModel.Models.Collections;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PmcDataModel.Tests
{
    [TestClass]
    public class PmcSimpleTests
    {
        private Developer<int> _developer;
        private PmcConfiguration _config;
        private Pmc<int> _pmc;
        private int _data;

        [SetUp]
        public void TestSetup()
        {
            _data = 5;
            _config = new PmcConfiguration
            {
                CountContainers = 1,
                CountMatrices = 1,
                CountPositions = 1,
                CountPoints = 1
            };
            _developer = new ContainerCollectionDeveloper<int>(_config);
            _pmc = _developer.Create(_data);
        }

        [TearDown]
        public void TestTearDown()
        {
            _config = null;
            _developer = null;
        }

        [Test]
        public void ValidPointAccess_Returns_ValidData()
        {
            // Arrange

            //Act
            var data = _pmc[0][0][0][0].DataValue[0];

            //Assert
            Assert.AreEqual(data, _data);
        }

        #region CountTests

        [Test]
        public void ContainerCount_Returns_CountDescribedInConfig()
        {
            // Arrange

            //Act
            var countContainers = _pmc.Count;

            //Assert
            Assert.AreEqual(countContainers, 1);
        }

        [Test]
        public void MatrixCount_Returns_CountDescribedInConfig()
        {
            // Arrange

            //Act
            var matrixCount = _pmc[0].Count;

            //Assert
            Assert.AreEqual(matrixCount, 1);
        }

        [Test]
        public void PositionCount_Returns_CountDescribedInConfig()
        {
            // Arrange

            //Act
            var positionCount = _pmc[0][0].Count;

            //Assert
            Assert.AreEqual(positionCount, 1);
        }

        [Test]
        public void PointCount_Returns_CountDescribedInConfig()
        {
            // Arrange

            //Act
            var pointCount = _pmc[0][0][0].Count;

            //Assert
            Assert.AreEqual(pointCount, 1);
        }

        #endregion

        #region InvalidIndexAccesTests

        [Test]
        public void InvalidContainerIndexAccess_Throws_ContainerIndexOutOfRangeException()
        {
            // Arrange

            //Act
            void CheckFunction()
            {
                //Arrange
                var invalidIndex = 1;

                //Act
                var data = _pmc[invalidIndex];
            }

            //Assert
            Assert.ThrowsException<ContainerIndexOutOfRangeException>((Action)CheckFunction);
        }

        [Test]
        public void InvalidMatrixIndexAccess_Throws_ContainerIndexOutOfRangeException()
        {
            // Arrange

            //Act
            void CheckFunction()
            {
                //Arrange
                var invalidIndex = 1;

                //Act
                var data = _pmc[0][invalidIndex];
            }

            //Assert
            Assert.ThrowsException<ContainerIndexOutOfRangeException>((Action)CheckFunction);
        }

        [Test]
        public void InvalidPositionIndexAccess_Throws_ContainerIndexOutOfRangeException()
        {
            // Arrange

            //Act
            void CheckFunction()
            {
                //Arrange
                var invalidIndex = 1;

                //Act
                var data = _pmc[0][0][invalidIndex];
            }

            //Assert
            Assert.ThrowsException<ContainerIndexOutOfRangeException>((Action)CheckFunction);
        }

        [Test]
        public void InvalidPointIndexAccess_Throws_ContainerIndexOutOfRangeException()
        {
            // Arrange

            //Act
            void CheckFunction()
            {
                //Arrange
                var invalidIndex = 1;

                //Act
                var data = _pmc[0][0][0][invalidIndex];
            }

            //Assert
            Assert.ThrowsException<ContainerIndexOutOfRangeException>((Action)CheckFunction);
        }

        #endregion

        #region ImmutabilityTests

        [Test]
        public void PointAssign_NotChangeValueInCollection()
        {
            // Arrange
            var newData = 6;

            //Act
            _pmc[0][0][0][0].DataValue[0] = newData;

            //Assert
            Assert.AreEqual(_pmc[0][0][0][0].DataValue[0], _data);
        }

        #endregion
    }
}
