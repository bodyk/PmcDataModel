using PmcDataModel;
using PmcDataModel.Configurations;
using PmcDataModel.Models;
using PmcDataModel.Models.Collections;
using PmcDataModel.RuleHelpers;
using System;
using System.Collections.Generic;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new PmcClient();
            client.ShowExample1();
            client.ShowExample2();
        }
    }
}
