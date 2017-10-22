using System;
using System.Collections.Generic;
using PmcDataModel;
using PmcDataModel.Configurations;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;
using PmcDataModel.RuleHelpers;

namespace ClientApp
{
    public class PmcClient
    {
        //Example 1:  A container collection contains 3 containers.  All data points are decimal.  Each matrix contains 100 positions.  
        //Each container contains 2 matrices with the first matrix in each container being XY data and the second matrix in each container being X data.  
        //Position 1 of the XY data contains 50 points.  Position 2 of the XY data contains 200 points.  The other XY positions are empty.  
        //Position 1 and 2 of the X data matrix contain a numerical value, the others do not
        public void ShowExample1()
        {
            var conf = new PmcConfiguration
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
                            MatrixNumbers = new List<int>
                            {
                                0
                            }
                        },
                        new MatrixNumberToDimension
                        {
                            Dimension = PointDimension.X,
                            MatrixNumbers = new List<int>
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
                            CountPoints = 50,
                            Path = new PointPath
                            {
                                PositionNumber = 0
                            }
                        },
                        new XyRule
                        {
                            CountPoints = 200,
                            Path = new PointPath
                            {
                                PositionNumber = 1
                            }
                        }
                    },
                    DefaultCountPoints = 0
                },
                XConfig = new XConfiguration
                {
                    DefaultCountPoints = 0,
                    Rules = new List<XRule>
                    {
                        new XRule
                        {
                            CountPoints = 1,
                            Path = new PointPath
                            {
                                PositionNumber = 0
                            }
                        },
                        new XRule
                        {
                            CountPoints = 1,
                            Path = new PointPath
                            {
                                PositionNumber = 1
                            }
                        }
                    }
                }
            };

            Developer<decimal> dev = new ContainerCollectionDeveloper<decimal>(conf);
            var containers = dev.Create(new decimal(150));

            Console.WriteLine($"Count containers: {containers.Count}");//3
            Console.WriteLine($"Count matrices in each container: {containers[0].Count}");//2
            Console.WriteLine($"First matrix dimension: {containers[0][0].Dimension}");//XY
            Console.WriteLine($"Second matrix dimension: {containers[0][1].Dimension}");//X
            Console.WriteLine($"Position 1 of the XY data contains {containers[0][0][0].Count} points");//50
            Console.WriteLine($"Position 2 of the XY data contains {containers[0][0][1].Count} points");//200
            Console.WriteLine($"Position 3 and other of the XY data contains {containers[0][0][2].Count} points");//0
            Console.WriteLine($"Position 1 of the X data contains {containers[0][1][0].Count} points");//numerical value, 1 at this case
            Console.WriteLine($"Position 2 of the X data contains {containers[0][1][1].Count} points");//numerical value, 1 at this case
            Console.WriteLine($"Position 3 and other of the X data contains {containers[0][1][2].Count} points");//0
            Console.WriteLine($"Data value at 1 container, 1 matrix, 1 position, 1 point, X: {containers[0][0][0][0].DataValue[0]}");//0


            //Uncomment line below to watch all data

            //ShowData(containers);

            Console.WriteLine();
        }

        //A container collection contains 10 containers.  All data points are double.  
        //Each container contains 10 matrices with the first 5 matrices being XY data and the remaining 5 being X data. 
        //All positions in all matrices contain values.
        public void ShowExample2()
        {
            var conf = new PmcConfiguration
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
                            MatrixNumbers = new List<int>
                            {
                                0, 1, 2, 3, 4
                            }
                        },
                        new MatrixNumberToDimension
                        {
                            Dimension = PointDimension.X,
                            MatrixNumbers = new List<int>
                            {
                                5, 6, 7, 8, 9
                            }
                        }
                    }
                }
            };

            Developer<double> dev = new ContainerCollectionDeveloper<double>(conf);
            var containers = dev.Create(10.5);

            Console.WriteLine($"Count containers: {containers.Count}");//10
            Console.WriteLine($"Count matrices in each container: {containers[0].Count}");//10

            for (var i = 0; i < containers[0].Count; i++)
            {
                Console.WriteLine($"{i} matrix dimension: {containers[0][i].Dimension}");// First 5 - XY, other - X
            }

            Console.WriteLine($"Data value at 1 container, 1 matrix, 1 position, 1 point, X: {containers[0][0][0][0].DataValue[0]}");//0


            //Uncomment line below to watch all data

            //ShowData(containers);

            Console.WriteLine();
        }

        public void ShowData<T>(Pmc<T> containers)
        {
            foreach (var container in containers)
            {
                Console.WriteLine("Container: ");
                foreach (var matrix in container)
                {
                    Console.WriteLine("\tMatrix: ");
                    foreach (var position in matrix)
                    {
                        Console.WriteLine("\t\tPosition: ");
                        foreach (var point in position)
                        {
                            Console.WriteLine($"\t\t\t{point.Dimension} - ");
                            foreach (var value in point.DataValue)
                            {
                                Console.WriteLine($"\t\t\t\t{value}");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
