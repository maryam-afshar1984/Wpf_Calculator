using Caliburn.Micro;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Calculator.Dialogs.YesNo;
using Wpf_Calculator.Models;


namespace Wpf_Calculator.ViewModels
{
    public class MyCalculatorViewModel:Screen
    {

        double total;
        private string _title = "WPF Calculator App";
        public string Title
        {
            get
            {
                return _title;
            }
        }

        private string _firstnumber="00";
        public string FirstNumber
        {
            get
            {
                return _firstnumber;
            }
            set
            {
                _firstnumber = value;
                NotifyOfPropertyChange(() => FirstNumber);
            }
        }

        private string _secondnumber="00";
        public string SecoundNumber
        {
            get
            {
                return _secondnumber;
            }
            set
            {
                _secondnumber = value;
                 NotifyOfPropertyChange(() => SecoundNumber);
            }
        }

        private string _result = "Result";
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                NotifyOfPropertyChange(() => Result);
            }
        }


        //for IOC
        private IMathCalculator _mathCalculator;
        public MyCalculatorViewModel(IMathCalculator mathCalculator)
        {
            _mathCalculator = mathCalculator;
        }

        //Events and methods
        public void Sum_Click(string firstNumber, string secoundNumber)
        {
            try
            {
                MyCalculatorModel calculators = new MyCalculatorModel();
                total = calculators.Sum(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber));
                Serilog.Log.Debug("Sum {A} and {B}", firstNumber, secoundNumber);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Something went wrong during Sum_Click event!");
            }

            Result = total.ToString();
            total = 0;
        }

        public void Subtraction_Click(string firstNumber, string secoundNumber)
        {
            try
            {
                MyCalculatorModel calculators = new MyCalculatorModel();
                total = calculators.Subtract(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber));
                Serilog.Log.Debug("Subtract {A} from {B}", secoundNumber, firstNumber);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Something went wrong during Subtraction_Click event!");
            }

            Result = total.ToString();
            total = 0;
        }

        public void Multiplication_Click(string firstNumber, string secoundNumber)
        {
            try
            {
                MyCalculatorModel calculators = new MyCalculatorModel();
                total = calculators.Multiply(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber));
                Serilog.Log.Debug("Multiply {A} to {B}", firstNumber, secoundNumber);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Something went wrong during Multiplication_Click event!");
            }

            Result = total.ToString();
            total = 0;
        }

        public void Division_Click(string firstNumber, string secoundNumber)
        {
            try
            {
                MyCalculatorModel calculators = new MyCalculatorModel();
                total = calculators.Divide(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber));
                Serilog.Log.Debug("Divide {A} by {B}", firstNumber, secoundNumber);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Something went wrong during Division_Click event!");
            }

            Result = total.ToString();
            total = 0;
        }

        public bool CanClear(string firstNumber, string secoundNumber, string result)
        {
            if (!string.IsNullOrWhiteSpace(firstNumber) || !string.IsNullOrWhiteSpace(secoundNumber) || ! string.IsNullOrWhiteSpace(result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear_Click(string firstNumber, string secoundNumber, string result)
        {
            try
            {
                bool flag = CanClear(firstNumber, secoundNumber, result);

                YesNoDialogBox msgbox = new YesNoDialogBox("Are you sure?");
                if ((bool)msgbox.ShowDialog() && flag)
                {
                    FirstNumber = "00";
                    SecoundNumber = "00";
                    Result = "Result";
                    MessageBox.Show("They have been cleared!");
                    Serilog.Log.Information("All previous numbers and result have been cleared!");
                }
                else
                {
                    MessageBox.Show("You can continue with previous numbers!");
                    Serilog.Log.Information("User is continuing with previous numbers!");
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Something went wrong during clear numbers and result method!");
            }
           
        }
    }
}
