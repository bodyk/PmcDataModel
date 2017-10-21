using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmcDataModel;
using PmcDataModel.Models;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration<int> conf = new Configuration<int>
            {
                DataValue = 10,
                CountContainers = 10,
                CountMatrices = 10,
                CountPositions = 6,
                CountPoints = 5,
            };
            Developer<int> dev = new ContainerDeveloper<int>(conf);
            var containers = dev.Create();

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
                            Console.WriteLine($"\t\t\tPoint: {point.DataValue}");
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
