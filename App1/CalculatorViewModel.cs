using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App1.Annotations;
using App1.Common;

namespace App1
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private readonly IEquationParser _equationParser;
        private readonly Calculator _calculator;
        private string _equation;
        private string _result;

        public CalculatorViewModel(IEquationParser equationParser, Calculator calculator)
        {
            _equationParser = equationParser;
            _calculator = calculator;

            ExecuteCommand = new DelegateCommand(Execute);
        }

        public ICommand ExecuteCommand { get; set; }

        public string Equation
        {
            get { return _equation; }
            set
            {
                _equation = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(Equation))
            {
                Result = "Nothing";
                return;
            }

            try
            {
                var equation = _equationParser.Parse(Equation);
                Result = _calculator.Solve(equation).ToString();
            }
            catch (Exception)
            {
                Result = "Error";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}