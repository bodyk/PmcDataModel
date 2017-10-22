using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PmcDataModel.Configurations;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;
using PmcDataModel.RuleHelpers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PmcDataModel.Tests
{
    [TestClass]
    public class PmcConfigurationsExample1Tests
    {
        private Developer<int> _developer;
        private PmcConfiguration _config;
        private Pmc<int> _pmc;
        private int _data;

        private int _pos1XYpointsCount;
        private int _pos2XYpointsCount;
        private int _posDefaultXYpointsCount;

        private int _pos1XpointsCount;
        private int _pos2XpointsCount;
        private int _posDefaultXpointsCount;

        [SetUp]
        public void TestSetup()
        {
            _data = 5;

            _pos1XYpointsCount = 50;
            _pos2XYpointsCount = 200;
            _posDefaultXYpointsCount = 0;

            _pos1XpointsCount = _pos2XpointsCount = 1;
            _posDefaultXpointsCount = 0;

            _config = new PmcConfiguration
            {
                CountContainers = 3,
                CountPositions = 100,
                CountMatrices = 2,
                MatrixConfig = new MatrixConfiguration
                {
                    MatrixNumberToDimensionRules = new List<MatrixNumberToDimension>
                    {
                        new MatrixNumberToDimension
                        {
                            Dimension = PointDimension.Xy,
                            IndexInContainer = new List<int>
                            {
                                0
                            }
                        },
                        new MatrixNumberToDimension
                        {
                            Dimension = PointDimension.X,
                            IndexInContainer = new List<int>
                            {
                                1
                            }
                        }
                    }
                },
                XyConfig = new XyConfiguration
                {
                    Rules = new List<XyRule>
                    {
                        new XyRule
                        {
                            CountPoints = _pos1XYpointsCount,
                            Path = new PointPath
                            {
                                IndexInMatrix = 0
                            }
                        },
                        new XyRule
                        {
                            CountPoints = _pos2XYpointsCount,
                            Path = new PointPath
                            {
                                IndexInMatrix = 1
                            }
                        }
                    },
                    DefaultCountPoints = _posDefaultXYpointsCount
                },
                XConfig = new XConfiguration
                {
                    DefaultCountPoints = _posDefaultXpointsCount,
                    Rules = new List<XRule>
                    {
                        new XRule
                        {
                            CountPoints = _pos1XpointsCount,
                            Path = new PointPath
                            {
                                IndexInMatrix = 0
                            }
                        },
                        new XRule
                        {
                            CountPoints = _pos2XpointsCount,
                            Path = new PointPath
                            {
                                IndexInMatrix = 1
                            }
                        }
                    }
                }
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
        public void FirstMatrix_Returns_XY_Dimension()
        {
            // Arrange

            //Act
            var dimension = _pmc[0][0].Dimension;

            //Assert
            Assert.AreEqual(PointDimension.Xy, dimension);
        }

        [Test]
        public void SecondMatrix_Returns_X_Dimension()
        {
            // Arrange

            //Act
            var dimension = _pmc[0][1].Dimension;

            //Assert
            Assert.AreEqual(PointDimension.X, dimension);
        }

        [Test]
        public void XY_FirstPosition_Returns_ValidPointsCount()
        {
            // Arrange

            //Act
            var count = _pmc[0][0][0].Count;

            //Assert
            Assert.AreEqual(_pos1XYpointsCount, count);
        }

        [Test]
        public void XY_SecondPosition_Returns_ValidPointsCount()
        {
            // Arrange

            //Act
            var count = _pmc[0][0][1].Count;

            //Assert
            Assert.AreEqual(_pos2XYpointsCount, count);
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void XY_OtherPosition_Returns_ValidPointsCount(int pos)
        {
            // Arrange

            //Act
            var count = _pmc[0][0][pos].Count;

            //Assert
            Assert.AreEqual(_posDefaultXYpointsCount, count);
        }

        [Test]
        public void X_FirstPosition_Returns_ValidPointsCount()
        {
            // Arrange

            //Act
            var count = _pmc[0][1][0].Count;

            //Assert
            Assert.AreEqual(_pos1XpointsCount, count);
        }

        [Test]
        public void X_SecondPosition_Returns_ValidPointsCount()
        {
            // Arrange

            //Act
            var count = _pmc[0][1][1].Count;

            //Assert
            Assert.AreEqual(_pos2XpointsCount, count);
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void X_OtherPosition_Returns_ValidPointsCount(int pos)
        {
            // Arrange

            //Act
            var count = _pmc[0][1][pos].Count;

            //Assert
            Assert.AreEqual(_posDefaultXpointsCount, count);
        }
    }
}
