using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Calculator.Models
{
    public interface IMathCalculator
    {
        //All necessary methods for overwriting in one class
        double Sum(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }
}
