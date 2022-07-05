using Caliburn.Micro;
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
        
        public void Click_Sum(string firstNumber, string secoundNumber)
        {

            CalculatorModel calculators = new CalculatorModel();
            total = calculators.Sum(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber));

            Result = total.ToString();
            total = 0;
        }

        public void Click_Subtraction(string firstNumber, string secoundNumber)
        {
            CalculatorModel calculators = new CalculatorModel();
            total = calculators.Subtract(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber)); ;

            Result = total.ToString();
            total = 0;
        }

        public void Click_Multiplication(string firstNumber, string secoundNumber)
        {
            CalculatorModel calculators = new CalculatorModel();
            total = calculators.Multiply(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber));

            Result = total.ToString();
            total = 0;
        }

        public void Click_Division(string firstNumber, string secoundNumber)
        {
            CalculatorModel calculators = new CalculatorModel();
            total = calculators.Divide(Convert.ToDouble(firstNumber), Convert.ToDouble(secoundNumber));

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

        public void Clear(string firstNumber, string secoundNumber, string result)
        {
           bool flag = CanClear(firstNumber, secoundNumber, result);

                YesNoDialogBox msgbox = new YesNoDialogBox("Are you sure?");
                if ((bool)msgbox.ShowDialog() && flag)
                {
                    FirstNumber = "00";
                    SecoundNumber = "00";
                    Result = "Result";
                    MessageBox.Show("They have been cleared!");
                }
                else 
                {
                    MessageBox.Show("You can continue with previous numbers!");
                }
        }
    }
}
