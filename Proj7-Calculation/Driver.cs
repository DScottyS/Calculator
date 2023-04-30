namespace Proj7_Calculation
{
    internal class Driver
    {
        static void Main()
        {
            Menu();
            
            Calculator calc = new Calculator();

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


            while(true)
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
                    else if(input[0] == "sqr" || input[0] == "sqrt" || input[0] == "fact")
                    {
                        dispatch[input[0]](input[1]);
                    }
                    else
                    {
                        dispatch[input[0]](input[1], calc.GetValue().ToString());
                    }
                }
                else if (input.Length == 1)
                {
                    dispatch[input[0]](calc.GetValue().ToString());
                }

            }
        }

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
            Console.WriteLine("To get the Factorial type: fact [number]\n");
            Console.WriteLine("All functions can be used with the last number produced by the calulator by\nignoring the number that would be in [number1]");
            Console.WriteLine("---------------------------------------------------------------------------\n");
        }
    }
}