         /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                     //
       // Project: Calculator                                                                                 //
      // File Name: Calculator                                                                               //
     // Course: CSCI 2210 – Introduction to Computer Science II                                             //
    // Author: Scotty Snyder, snyderds@etsu.edu, Department of Computing, East Tennessee State University  //
   // Created: Monday, April 29, 2023                                                                     //
  // Copyright: Scotty Snyder, 2023                                                                      //
 //                                                                                                     //
/////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj7_Calculation
{
    /// <summary>
    /// Calculator class does all the actual calculations
    /// </summary>
    public class Calculator
    {
        //CalcInput dictionary stores all the key value pairs
        public Dictionary<string, double> CalcInput = new();

        /// <summary>
        /// Gets the most current value used in the calculator
        /// </summary>
        /// <returns>the most recently used value in the calculator</returns>
        public double GetValue()
        {
            return CalcInput.ContainsKey("currentValue") ? CalcInput["currentValue"] : 0;
        }

        /// <summary>
        /// stores a value in calcinput
        /// </summary>
        /// <param name="key">the name you would like to save the value with</param>
        /// <param name="value">the value you would like to save</param>
        public void Store(string key, string value)
        {
            double x;
            double.TryParse(value, out x);
            CalcInput[key] = x;
        }

        /// <summary>
        /// parses input from the driver to make sure it's a valid number
        /// </summary>
        /// <param name="value">the value to be parsed</param>
        /// <returns>the parsed number, if value cannon be parsed, then 0</returns>
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

        /// <summary>
        /// adds two numbers
        /// </summary>
        /// <param name="a">the first number to add</param>
        /// <param name="b">the second number to add</param>
        public void Add(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x + y;
        }

        /// <summary>
        /// subtracts two numbers
        /// </summary>
        /// <param name="a">the number to subtract by</param>
        /// <param name="b">the number to subtract</param>
        public void Sub(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = y - x;
        }

        /// <summary>
        /// multiplies two numbers
        /// </summary>
        /// <param name="a">the first number to multiply</param>
        /// <param name="b">the second number to multiply</param>
        public void Mult(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x * y;
        }

        /// <summary>
        /// divides two numbers
        /// </summary>
        /// <param name="a">the number to divide</param>
        /// <param name="b">the number to divide by</param>
        public void Div(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x / y;
        }

        /// <summary>
        /// squares a number
        /// </summary>
        /// <param name="a">the number to be squared</param>
        public void Sqr(string a)
        {
            double x = Parse(a);
            CalcInput["currentValue"] = x * x;
        }

        /// <summary>
        /// gets the square root of a number
        /// </summary>
        /// <param name="a">the number to get the square root of</param>
        public void Sqrt(string a)
        {
            double x = Parse(a);
            CalcInput["currentValue"] = Math.Sqrt(x);
        }

        /// <summary>
        /// clears the console
        /// </summary>
        public void Clear()
        {
            CalcInput["currentValue"] = 0;
        }

        /// <summary>
        /// puts a to the power of b
        /// </summary>
        /// <param name="a">the number you would like to raise to a power</param>
        /// <param name="b">the power of the number</param>
        public void Pow(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = Math.Pow(x, y);
        }

        /// <summary>
        /// gets the modulo of a and b
        /// </summary>
        /// <param name="a">the number to get the remainder of</param>
        /// <param name="b">the number to divide by</param>
        public void Mod(string a, string b)
        {
            double x = Parse(a);
            double y = Parse(b);
            CalcInput["currentValue"] = x % y;
        }

        /// <summary>
        /// gets the factorial of a number
        /// </summary>
        /// <param name="a">the number to get the factorial of</param>
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

        /// <summary>
        /// sets the calculators most recent value to a stored value
        /// </summary>
        /// <param name="a">the stored value to set the most recent value to</param>
        public void Set(string a)
        {
            double x = CalcInput[a];
            CalcInput["currentValue"] = x;
        }

        /// <summary>
        /// exports saved variables to a semi-unique file
        /// </summary>
        public void Export()
        {
            DateTime dateTime = DateTime.Now;
            StreamWriter sw = new StreamWriter($"..\\..\\..\\..\\CalcData\\SavedVariables{dateTime.ToString("m-s")}.txt");

            foreach(KeyValuePair<string, double> StoredValue in CalcInput)
            {
                sw.WriteLine($"{StoredValue.Key}, {StoredValue.Value}");
            }
            sw.Close();
        }

        /// <summary>
        /// imports the kvps of files and saves them to CalcInput
        /// </summary>
        /// <param name="filePath">the path of the file to be imported from</param>
        public void Import(string filePath)
        {
            try
            {
                StreamReader sr = new StreamReader($"..\\..\\..\\..\\CalcData\\{filePath}");

                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] wholeLine = line.Split(',');
                    CalcInput.Add(wholeLine[0], Parse(wholeLine[1]));
                }
                sr.Close();
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("The given filepath was invalid");
            }         
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("There was an error with the formatting of the provided file");
            }
        }
    }
}
