using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace TestUIAuto
{
    public class Functions
    {
        // Functions 
        public const string MemoryClear = "Memory clear";
        public const string Backspace = "Backspace";
        public const string MemoryRecall = "Memory recall";
        public const string ClearEntry = "Clear entry";
        public const string MemoryStore = "Memory store";
        public const string Clear = "Clear";
        public const string DecimalSeparator = "Decimal separator";
        public const string MemoryAdd = "Memory add";
        public const string MemoryRemove = "Memory subtract";
        public const string Equals = "Equals";
    }
    class Program
    {
        AutomationElement _calculatorAutomationElement;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Calculator();
        }
        public  void Calculator()
        {
            var _calculatorProcess = Process.Start("Calc.exe");
            Thread.Sleep(2000);

            int ct = 0;
            do
            {
                 _calculatorAutomationElement = AutomationElement.RootElement.FindFirst
            (TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty,
            "Calculator"));

                ++ct;
                Thread.Sleep(100);
            }
            while (_calculatorAutomationElement == null && ct < 50);


            if (_calculatorAutomationElement == null)
            {
                throw new InvalidOperationException("Calculator must be running");
            }

            var _resultTextBoxAutomationElement = _calculatorAutomationElement.FindFirst
            (TreeScope.Descendants, new PropertyCondition
            (AutomationElement.AutomationIdProperty, "CalculatorResults"));

            if (_resultTextBoxAutomationElement == null)
            {
                throw new InvalidOperationException("Could not find result box");
            }
            var _control1 = _calculatorAutomationElement.FindFirst
            (TreeScope.Descendants, new PropertyCondition
            (AutomationElement.AutomationIdProperty, "num1Button"));
            InvokePattern num1 = (InvokePattern)_control1.GetCurrentPattern(InvokePattern.Pattern);
            num1.Invoke(); 
             var _controlPlus = _calculatorAutomationElement.FindFirst
            (TreeScope.Descendants, new PropertyCondition
            (AutomationElement.AutomationIdProperty, "plusButton"));
            InvokePattern numPlus = (InvokePattern)_controlPlus.GetCurrentPattern(InvokePattern.Pattern);
            numPlus.Invoke();
            var _control2 = _calculatorAutomationElement.FindFirst
            (TreeScope.Descendants, new PropertyCondition
            (AutomationElement.AutomationIdProperty, "num2Button"));
            InvokePattern num2 = (InvokePattern)_control2.GetCurrentPattern(InvokePattern.Pattern);
            num2.Invoke();
            var _controlEql = _calculatorAutomationElement.FindFirst
            (TreeScope.Descendants, new PropertyCondition
            (AutomationElement.AutomationIdProperty, "equalButton"));
            InvokePattern numEql = (InvokePattern)_controlEql.GetCurrentPattern(InvokePattern.Pattern);
            numEql.Invoke();

            //GetInvokePattern(GetFunctionButton(Functions.Clear)).Invoke();
        }
        public InvokePattern GetInvokePattern(AutomationElement element)
        {
            return element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
        }
        public AutomationElement GetFunctionButton(string functionName)
        {
            AutomationElement functionButton = _calculatorAutomationElement.FindFirst
            (TreeScope.Descendants, new PropertyCondition
            (AutomationElement.NameProperty, functionName));

            if (functionButton == null)
            {
                throw new InvalidOperationException("No function button found with name: " +
                functionName);
            }

            return functionButton;
        }
    }
}
