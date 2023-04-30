namespace Proj7_Calculation
{
    internal class Driver
    {
        static void Main()
        {
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
    }
}