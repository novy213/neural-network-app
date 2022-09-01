using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace A.I.neural.network
{
    class program
    {
        static void Main(string[] Args)
        {
            int[] diameter = new int[6];            
            int[] length = new int[6];                                   
            int[] correctAnswer = new int[6];                         
            bool[] correct = new bool[6];
            double[] result = new double[6];
            int[] correctThings = new int[6];           
            int idWrong=0;

            string[] thingName = new string[6];
            string[] computerThingName = new string[6];

            Random r = new Random();
            double[] weights = { -2, 0.1};
            double[] oldWeights = new double[2];
            oldWeights[0] = weights[0];
            oldWeights[1] = weights[1];
            double mutaion = 6;
            int idWrongCounter = 0;
            int attempCounter = 2;

            double learningRate = 0.2;            

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter the diameter");
                diameter[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the length");
                length[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the correct answer (1-ring, 2 - pen)");
                correctAnswer[i] = Convert.ToInt32(Console.ReadLine());
                if (i <= 8)
                {
                    Console.WriteLine("{0} values were taken", i + 1);
                    Console.WriteLine();
                }
                if (correctAnswer[i] == 1)
                {
                    thingName[i] = "Ring";
                    correctThings[i] = 1;
                }
                else if (correctAnswer[i] == 2)
                {
                    thingName[i] = "Pen";
                    correctThings[i] = -1;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int j = 0;; j++)
            {
                if (result[0] == 0)
                {
                    Console.WriteLine("Attempt " + (j+1) + " (next attemp enter)");
                    for (int i = 0; i < 5; i++)
                    {
                        result[i] = ((diameter[i] * weights[0]) + (length[i] * weights[1])) + mutaion;
                        if (result[i] > 0)
                        {
                            computerThingName[i] = "Ring";
                        }
                        else if (result[i] < 0)
                        {
                            computerThingName[i] = "Pen";
                        }
                        if (result[i] > 0 && correctAnswer[i] == 1)
                        {
                            correct[i] = true;
                            Console.Write(result[i] + " " + "Computer {0}, we {1}", computerThingName[i], thingName[i] +" ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(correct[i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (result[i] < 0 && correctAnswer[i] == 2)
                        {
                            correct[i] = true;
                            Console.Write(result[i] + " " + "Computer {0}, we {1}", computerThingName[i], thingName[i] +" ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(correct[i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            correct[i] = false;
                            Console.Write(result[i] + " " + "Computer {0}, we {1}", computerThingName[i], thingName[i] +" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(correct[i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.WriteLine();                   
                }
                else
                {
                    while (idWrong == 0)
                    {
                        if (correct[idWrongCounter] == false)
                        {
                            idWrong = idWrongCounter;
                            break;
                        }
                        idWrongCounter++;
                    }
                    oldWeights[0] = weights[0];
                    oldWeights[1] = weights[1];
                    weights[0] = WeightChange(correctThings[idWrong], diameter[idWrong], learningRate, oldWeights[0]);
                    weights[1] = WeightChange(correctThings[idWrong], length[idWrong], learningRate, oldWeights[1]);
                    for (int i = 0; i < 5; i++)
                    {
                        result[i] = ((diameter[i] * weights[0]) + (length[i] * weights[1])) + mutaion;
                        if (result[i] > 0)
                        {
                            computerThingName[i] = "Ring";
                        }
                        else if (result[i] < 0)
                        {
                            computerThingName[i] = "Pen";
                        }
                        if (result[i] > 0 && correctAnswer[i] == 1)
                        {
                            correct[i] = true;
                            Console.Write(result[i] + " " + "Computer {0}, we {1}", computerThingName[i], thingName[i] +" ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(correct[i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (result[i] < 0 && correctAnswer[i] == 2)
                        {
                            correct[i] = true;
                            Console.Write(result[i] + " " + "Computer {0}, we {1}", computerThingName[i], thingName[i] +" ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(correct[i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            correct[i] = false;
                            Console.Write   (result[i] + " " + "Computer {0}, we {1}", computerThingName[i], thingName[i] +" ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(correct[i]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.WriteLine();                  
                    idWrong = 0;
                    idWrongCounter = 0;
                }
                Console.WriteLine();
                Console.Write("Attempt " + attempCounter + " (next attemp enter)");
                Console.ReadLine();
                attempCounter++;
            }
        }
        public static double WeightChange(int correctThing, double arm, double learningRate, double weigth)
        {
            double result=(correctThing*arm*learningRate) + weigth;            
            return result;
        }
    }
}