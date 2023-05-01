﻿namespace Proj7_Calculation
{
    internal class Driver
    {
        static void Main()
        {
            Menu();
            

            Dictionary<string, dynamic> dispatch = new();
            dispatch["add"] = new Action<string, string>((a, b) => calc.Add(a, b));
            dispatch["store"] = new Action<string, string>((a, b) => calc.Store(a, b));
            dispatch["sub"] = new Action<string, string>((a, b) => calc.Sub(a, b));
            dispatch["mult"] = new Action<string, string>((a, b) => calc.Mult(a, b));
            dispatch["div"] = new Action<string, string>((a, b) => calc.Div(a, b));
            dispatch["pow"] = new Action<string, string>((a, b) => calc.Pow(a, b));
            dispatch["mod"] = new Action<string, string>((a, b) => calc.Mod(a, b));
            dispatch["fact"] = new Action<string>((a) => calc.Fact(a));
            dispatch["sqr"] = new Action<string>((a) => calc.Sqr(a));
            dispatch["sqrt"] = new Action<string>((a) => calc.Sqrt(a));
            dispatch["clear"] = new Action<string>((a) => calc.Clear(a));
            dispatch["set"] = new Action<string>((a) => calc.Set(a));
            dispatch["import"] = new Action<string>((a) => calc.Import(a));
            dispatch["export"] = new Action(() => calc.Export());
            dispatch["view"] = new Action(() => View());



            while(true)
            {
                try
                {
                    Console.WriteLine(calc.GetValue());
                    string[] input = Console.ReadLine().ToLower().Split(" ");

                    if(input.Length == 3)
                    {
                        dispatch[input[0]](input[1], input[2]);
                    }
                    else if(input.Length == 2)
                    {
                        if(input[0] == "div" || input[0] == "pow" || input[0] == "mod")
                        {
                            dispatch[input[0]](calc.GetValue().ToString(), input[1]);
                        }
                        else if(input[0] == "sqr" || input[0] == "sqrt" || input[0] == "fact" || input[0] == "set" || input[0] == "import")
                        {
                            dispatch[input[0]](input[1]);
                        }
                        else
                        {
                            dispatch[input[0]](input[1], calc.GetValue().ToString());
                        }
                    }
                    else if(input.Length == 1)
                    {
                        if(input[0] == "view" || input[0] == "export")
                        {
                            dispatch[input[0]]();
                        }
                        else
                        {
                            dispatch[input[0]](calc.GetValue().ToString());
                        }
                    }
                }
                catch(KeyNotFoundException)
                {
                    Console.WriteLine("I'm sorry, that is not a valid command");
                }
            }
        }

        public static Calculator calc = new Calculator();


        public static void Menu()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("                Welcome to cool calculator so cool very wow                ");
            Console.WriteLine("---------------------------------------------------------------------------\n");
            Console.WriteLine("To Add type: add [number1] [number2]");
            Console.WriteLine("To Subtract type: sub [number1] [number2]");
            Console.WriteLine("To Multiply type: mult [number1] [number2]");
            Console.WriteLine("To Divide type: div [number1] [number2]");
            Console.WriteLine("To get Modulo type: mod [number1] [number2]");
            Console.WriteLine("To get the Square type: sqr [number]");
            Console.WriteLine("To get the Square Root type: sqrt [number]");
            Console.WriteLine("To raise a number to a Power type: pow [number] [exponent]");
            Console.WriteLine("To get the Factorial type: fact [number]");
            Console.WriteLine("To Store a number type: store [name] [number]");
            Console.WriteLine("To View the numbers currently stored type: view");
            Console.WriteLine("To Set a number to a previously stored number type: set [name]");
            Console.WriteLine("To Export your stored variables type: export");
            Console.WriteLine("To Import a saved file: import [filename.txt] (must be in CalcData folder)\n");
            Console.WriteLine("All functions can be used with the last number produced by the calulator by");
            Console.WriteLine("ignoring the number that would be in [number1]\n");
            Console.WriteLine("Note: only standard numbers are accepted by the calculator, special symbols");
            Console.WriteLine("such as pi(π) will not be recognized by the calculator");
            Console.WriteLine("---------------------------------------------------------------------------\n");
        }

        public static void View()
        {
            Console.WriteLine();
            foreach(KeyValuePair<string, double> StoredValue in calc.CalcInput) 
            {
                Console.WriteLine($"{StoredValue.Key}, {StoredValue.Value}");
            }
            Console.WriteLine();
        }
    }
}