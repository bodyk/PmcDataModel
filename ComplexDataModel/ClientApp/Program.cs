using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel;
using PmcDataModel.Configurations;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;
using PmcDataModel.RuleHelpers;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var conf = new PmcConfiguration<double>
            {
                DataValue = 10.5,
                CountContainers = 2,
                CountMatrices = 2,
                CountPositions = 2,
                CountPoints = 1,
                MatrixConfig = new MatrixConfiguration
                {
                    DefaultPointDimension = PointDimension.X,
                    MatrixNumberToDimensionRules = new List<MatrixNumberToDimension>()
                    {
                        {
                            new MatrixNumberToDimension
                            {
                                MatrixNumbers = new List<int>
                                {
                                    0
                                },
                                Dimension = PointDimension.XY
                            }
                        },
                        {
                            new MatrixNumberToDimension
                            {
                                MatrixNumbers = new List<int>
                                {
                                    1
                                },
                                Dimension = PointDimension.XYZ
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
                            CountPoints = 5,
                            Path = new PositionPath
                            {
                                MatrixNumber = 0,
                                PositionNumber = 0
                            }
                        }
                    }
                }
            };
            Developer<double> dev = new ContainerCollectionDeveloper<double>(conf);
            var containers = dev.Create();

            Console.WriteLine("FirstMatrix: ");

            foreach (var i in containers[0][0][0][0].DataValue)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(containers[0][0][1].Count);

            //foreach (var container in containers)
            //{
            //    Console.WriteLine("Container: ");
            //    foreach (var matrix in container)
            //    {
            //        Console.WriteLine("\tMatrix: ");
            //        foreach (var position in matrix)
            //        {
            //            Console.WriteLine("\t\tPosition: ");
            //            foreach (var point in position)
            //            {
            //                Console.WriteLine($"\t\t\tPoint: {point.DataValue}");
            //            }
            //            Console.WriteLine();
            //        }
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
