

using System;
//System is a namespace, allows to use the Console class (ex).
using static System.Console;

namespace Calculator
{

    class Program
    {
        static void Main(string[] args)
        {

            //REFACTOR TO REUSABLE FUNCTION.
            ForegroundColor = ConsoleColor.Green;
            Title = ("INTEGER CALCULATOR");
            WriteLine("INTEGER CALCULATOR");
            ResetColor();
            //INSTANTIATE CALCULATOR CLASS.
            var calculate = new Calculator();
            //FUNCTION TO CALCULATE LOGIC.
            void CalculateLogic()
            {
                while (!calculate.finished)
                {
                    //SHOWING OPTIONS
                    calculate.ShowOptions();
                    //store the input from OPTIONS.
                    var methodInput = ReadLine();
                    var allowCalculate = false;

                    foreach (var method in calculate.methods)
                    {
                        if (methodInput == method)
                        {
                            allowCalculate = true;
                            break;
                        }
                    }

                    if (allowCalculate == false)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Invalid Entry");
                        ResetColor();
                    }
                    else
                    {

                        //store user input.
                        calculate.input = methodInput;
                        //validate integer input
                        bool validIntegerInput = false;

                        while (!validIntegerInput)
                        {
                            WriteLine("Enter number, if you are done, press e");
                            var input = ReadLine();
                            if (input == "e")
                            {
                                calculate.finished = true;
                                break;
                            }
                            else
                            {
                                //SHOW THE CALCULATION RESULT UI
                                ForegroundColor = ConsoleColor.DarkYellow;
                                WriteLine($"Method: {calculate.input} - Value: {input}");
                                ResetColor();
                                //PERFORM THE CALCULATE METHOD.
                                try
                                {
                                    calculate.CalculateTotal(int.Parse(input));
                                    validIntegerInput = true;
                                }
                                catch (FormatException e)
                                {
                                    ForegroundColor = ConsoleColor.Red;
                                    WriteLine($"Not an integer - {e.Message}");
                                    ResetColor();
                                }
                                //SHOW TOTAL UI.
                                ForegroundColor = ConsoleColor.DarkMagenta;
                                WriteLine($"Current Total: {calculate.total}");
                                ResetColor();

                            }
                        }
                        //ASKING USER TO INPUT NUMBER.
                    }
                }

            }

            //calculate Logic
            CalculateLogic();

            ForegroundColor = ConsoleColor.Green;
            WriteLine($"The total is: {calculate.total}");
            ResetColor();

            //reset.
            WriteLine("Calculate again? Type: reset");


            if (ReadLine() == "reset")
            {
                //RESET THE CALCULATOR.
                calculate.total = 0;
                calculate.input = null;
                calculate.finished = false;
                CalculateLogic();
            }



        }


    }
}
