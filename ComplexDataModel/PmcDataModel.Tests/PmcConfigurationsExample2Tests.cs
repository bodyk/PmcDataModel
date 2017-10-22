using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PmcDataModel.Configurations;
using PmcDataModel.Models.Collections;
using PmcDataModel.RuleHelpers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PmcDataModel.Tests
{
    [TestClass]
    public class PmcConfigurationsExample2Tests
    {
        private Developer<double> _developer;
        private PmcConfiguration _config;
        private Pmc<double> _pmc;
        private double _data;

        [SetUp]
        public void TestSetup()
        {
            _data = 18.5;

            _config = new PmcConfiguration
            {
                CountContainers = 10,
                CountPositions = 10,
                CountMatrices = 10,
                MatrixConfig = new MatrixConfiguration
                {
                    MatrixNumberToDimensionRules = new List<MatrixNumberToDimension>
                    {
                        new MatrixNumberToDimension
                        {
                            Dimension = PointDimension.Xy,
                            IndexInContainer = new List<int>
                            {
                                0,
                                1,
                                2,
                                3,
                                4
                            }
                        },
                        new MatrixNumberToDimension
                        {
                            Dimension = PointDimension.X,
                            IndexInContainer = new List<int>
                            {
                                5,
                                6,
                                7,
                                8,
                                9
                            }
                        }
                    }
                }
            };

            _developer = new ContainerCollectionDeveloper<double>(_config);
            _pmc = _developer.Create(_data);
        }

        [TearDown]
        public void TestTearDown()
        {
            _config = null;
            _developer = null;
        }

        [Test]
        [TestCase(0, PointDimension.Xy)]
        [TestCase(1, PointDimension.Xy)]
        [TestCase(2, PointDimension.Xy)]
        [TestCase(3, PointDimension.Xy)]
        [TestCase(4, PointDimension.Xy)]
        [TestCase(5, PointDimension.X)]
        [TestCase(6, PointDimension.X)]
        [TestCase(7, PointDimension.X)]
        [TestCase(8, PointDimension.X)]
        [TestCase(9, PointDimension.X)]
        public void FirstMatrix_Returns_XY_Dimension(int index, PointDimension expectedDimension)
        {
            // Arrange

            //Act
            var actualDimension = _pmc[0][index].Dimension;

            //Assert
            Assert.AreEqual(expectedDimension, actualDimension);
        }
    }
}
