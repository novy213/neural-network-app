using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace A.I.neural.network
{
    class program
    {
        static void Main(string[] Args)
        {
            //int[] diameter = new int[9];
            int[] diameter = { 23,18,8,200,8,30,5,10,0};
            //int[] length = new int[9];
            int[] length = {4,3,2,30,150,350,100,200,0};
            //int[] correctAnswer = new int[9];
            int[] correctAnswer = { 1,1,1,1,2,2,2,2, 0 };
            bool[] correct = new bool[9];
            double[] result = new double[9];
            //int[] correctThings = new int[9];
            int[] correctThings = { 1, 1, 1, 1, -1, -1, -1, -1 ,0};
            int idWrong=0;

            Random r = new Random();
            double[] weights = { -2, 0.1};
            double[] oldWeights = new double[2];
            oldWeights[0] = weights[0];
            oldWeights[1] = weights[1];
            double mutaion = 6;

            int k = 0;

            double learningRate = 0.2;            

            /*for (int i = 0; i < 8; i++)
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
                }
                if (correctAnswer[i] == 1)
                {
                    correctThings[i] = 1;
                }
                else if (correctAnswer[i] == 2)
                {
                    correctThings[i] = -1;
                }
            }*/
            Console.WriteLine();
            Console.WriteLine();
            for (int j = 0; j < 9; j++)
            {
                if (result[0] == 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        result[i] = ((diameter[i] * weights[0]) + (length[i] * weights[1])) + mutaion;
                        if (result[i] > 0 && correctAnswer[i] == 1)
                        {
                            correct[i] = true;
                            Console.WriteLine(result[i] + " " + correct[i]);
                        }
                        else if (result[i] < 0 && correctAnswer[i] == 2)
                        {
                            correct[i] = true;
                            Console.WriteLine(result[i] + " " + correct[i]);
                        }
                        else
                        {
                            correct[i] = false;
                            Console.WriteLine(result[i] + " " + correct[i]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    while (idWrong == 0)
                    {
                        if (correct[k] == false)
                        {
                            idWrong = k;
                            break;
                        }
                        k++;
                    }
                    oldWeights[0] = weights[0];
                    oldWeights[1] = weights[1];
                    weights[0] = WeightChange(correctThings[idWrong], diameter[idWrong], learningRate, oldWeights[0]);
                    weights[1] = WeightChange(correctThings[idWrong], length[idWrong], learningRate, oldWeights[1]);
                    for (int i = 0; i < 8; i++)
                    {
                        result[i] = ((diameter[i] * weights[0]) + (length[i] * weights[1])) + mutaion;
                        if (result[i] > 0 && correctAnswer[i] == 1)
                        {
                            correct[i] = true;
                            Console.WriteLine(result[i] +" "+ correct[i]);                          
                        }                       
                        else if (result[i] < 0 && correctAnswer[i] == 2)
                        {
                            correct[i] = true;
                            Console.WriteLine(result[i] +" "+ correct[i]);
                        }    
                        else
                        {
                            correct[i] = false;
                            Console.WriteLine(result[i] + " " + correct[i]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    idWrong = 0;
                    k = 0;
                }
            }
        }
        public static double WeightChange(int correctThing, double arm, double learningRate, double weigth)
        {
            double result=(correctThing*arm*learningRate) + weigth;            
            return result;
        }
    }
}