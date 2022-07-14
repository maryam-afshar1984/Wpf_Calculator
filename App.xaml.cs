using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Calculator
{
    public partial class App : Application
    {
        public App()
        {
            //Configuration a Serilog
            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                   .MinimumLevel.Debug()
                   .WriteTo.Console()
                   .WriteTo.File("F:\\Wpf\\Source\\Wpf_Calculator\\logs\\Log_Serilog.txt"
                   , rollingInterval: RollingInterval.Day)
                   .CreateLogger();
            Serilog.Log.Information("Hello, This is my log for MyCalcolatur App!");
        }
    }
}
