using System;

class Program
{
    static void Main(string[] args)
    {
       PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string firstArg = tokens[0];

            if (firstArg == "mode")
            {
                char operand = tokens[1][0];
                ICalculationStrategy strategy = null;
                switch (operand)
                {
                    case '+':
                        strategy = new AdditionStrategy();
                        break;
                    case '-':
                        strategy = new SubtractionStrategy();
                        break;
                    case '*':
                        strategy=new MultyplicationStrategy();
                        break;
                    case '/':
                        strategy=new DivideStrategy();
                        break;
                }
                if (strategy == null)
                {
                    throw new InvalidOperationException("Invalid Mode!");
                }
                calculator.ChangeStrategy(strategy);
            }
            else
            {
                int first = int.Parse(firstArg);
                int second = int.Parse(tokens[1]);

                int result = calculator.PerformCalculation(first, second);

                Console.WriteLine(result);
            }
        }
    }
}