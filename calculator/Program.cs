using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string way = "input.txt";
            if (CheckInput(way))
                if (CheckError(way))
                {
                    File.WriteAllText("output.txt", Calculate(way).ToString());
                    Console.WriteLine("результат в файле output.txt");
                }
        }

        static bool CheckInput(string way)
        {
            if (File.ReadAllText(way) != string.Empty)
                return true;
            else
            {
                Console.WriteLine("error");
                return false;
            }
        }

        static string[] CheckArray(string way)
        {
            string[] oldInput = File.ReadAllText(way).Replace('.', ',').Split(' ');
            string[] input = new string[oldInput.Count()];
            int j = 0;
            for (int i = 0; i < oldInput.Count(); i++)
            {
               if (oldInput[i] != " ")
               {
                    input[j] = oldInput[i];
                    j++;
               }
            }
            return input;
        }

        static bool CheckError(string way)
        {
            string[] input = CheckArray(way);

            if ((input[2] == "/") && (int.Parse(input[3]) == 0))
            {
                Console.WriteLine("на 0 делить нельзя");
                return false;
            }
            else if ((input[1] == "+" || input[1] == "*" || input[1] == "/" || input[1] == "-") && (Double.TryParse(input[0], out double a)) && (Double.TryParse(input[2], out double b)))
            {
                return true;
            }
            else
            {
                Console.WriteLine("error");
                return false;
            }
        }

        static double Calculate(string way)
        {
            string[] input = CheckArray(way);
            double answer;
            switch (input[1])
            {
                case "+" :
                    answer = Convert.ToDouble(input[0]) + Convert.ToDouble(input[2]);
                    break;
                case "*":
                    answer = Convert.ToDouble(input[0]) * Convert.ToDouble(input[2]);
                    break;
                case "-":
                    answer = Convert.ToDouble(input[0]) - Convert.ToDouble(input[2]);
                    break;
                default:
                    answer = Convert.ToDouble(input[0]) / Convert.ToDouble(input[2]);
                    break;
            }
            return answer;
        }

    }
}
