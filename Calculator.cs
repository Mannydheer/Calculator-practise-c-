//System is a namespace, allows to use the Console class (ex).
using System;
using static System.Console;

namespace Calculator
{
    public class Calculator
    {
        public bool finished = false;
        public string[] methods = { "add", "subtract", "divide", "multiply" };
        public int total = 0;
        public string input;

        public void CalculateTotal(int number)
        {
            switch (input)
            {
                case "add":
                    {
                        total += number;
                    }
                    break;
                case "subtract":
                    {
                        total -= number;
                    }
                    break;
                case "divide":
                    {
                        total /= number;
                    }
                    break;
                case "multiply":
                    {
                        total *= number;
                    }
                    break;

                default:
                    break;
            }
        }

        public void ShowOptions()
        {
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("Choose a method by typing:");
            WriteLine("\t - add");
            WriteLine("\t - subtract");
            WriteLine("\t - divide");
            WriteLine("\t - multiply");
            ResetColor();
        }

    }

}
