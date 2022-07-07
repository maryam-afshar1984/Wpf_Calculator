using Caliburn.Micro;
using Microsoft.Extensions.Logging;
using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Calculator.Models;
using Wpf_Calculator.ViewModels;
using Wpf_Calculator.Views;

namespace Wpf_Calculator
{
    public class Bootstrapper : BootstrapperBase
    {
        //IOC. It is going to handle the instaces of all classes
        private SimpleContainer _container = new SimpleContainer();

        //IOC container configuration
        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            _container.
                PerRequest<IMathCalculator, MyCalculatorModel>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        public Bootstrapper()
        {
            Initialize();
        }

       
        //IOC override methods
        #region IOC override methods
        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
        #endregion /IOC override methods

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<MyCalculatorViewModel>();
        }

    }
}
