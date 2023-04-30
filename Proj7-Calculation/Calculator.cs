using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj7_Calculation
{
    public class Calculator
    {
        Dictionary<string, double> CalcInput = new();

        public double GetValue()
        {
            return CalcInput.ContainsKey("currentValue") ? CalcInput["currentValue"] : 0;
        }

        public void Store(string key, string value)
        {
            double x;
            double.TryParse(value, out x);
            CalcInput[key] = x;
        }

        public double Parse(string value)
        {
            double x;
            if(CalcInput.ContainsKey(value))
            {
                x = CalcInput[value];
            }
            else
            {
                double.TryParse(value, out x);
            }
            return x;
        }

        public void Add(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x + y;
        }

        public void Sub(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = y - x;
        }

        public void Mult(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x * y;
        }

        public void Div(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x / y;
        }

        public void Sqr(string a)
        {
            double x = Parse(a);
            CalcInput["currentValue"] = x * x;
        }

        public void Sqrt(string a)
        {
            double x = Parse(a);
            CalcInput["currentValue"] = Math.Sqrt(x);
        }

        public void Clear(string a)
        {
            double x = Parse(a);
            CalcInput["currentValue"] = 0;
        }

        public void Pow(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = Math.Pow(x, y);
        }

        public void Mod(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x % y;
        }

        public void Fact(string a)
        {
            double x = Parse(a);
            double temp = x;

            for(double i = x - 1; i > 0; i--)
            {
                temp *= i;
            }

            CalcInput["currentValue"] = temp;
        }
    }
}
