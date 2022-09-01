using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace A.I.neural.network
{
    class program
    {
        static void Main(string[] Args)
        {
            int[] diameter = new int[9];
            int[] length = new int[9];
            int[] correctAnswer = new int[9];
            bool[] correct = new bool[9];
            double[] result = new double[9];
            int[] correctThings = new int[9];

            Random r = new Random();
            double[] weights = { -2, 0.1};
            double[] oldWeights = new double[2];
            oldWeights[0] = weights[0];
            oldWeights[1] = weights[1];
            double mutaion = 6;

            double learningRate = 1;            

            for (int i = 0; i < 8; i++)
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
            }
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
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Ring", correctAnswer[i]);
                        }
                        if (result[i] > 0 && correctAnswer[i] == 2)
                        {
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Ring", correctAnswer[i]);
                        }
                        if (result[i] < 0 && correctAnswer[i] == 2)
                        {
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Pen", correctAnswer[i]);
                        }
                        if (result[i] < 0 && correctAnswer[i] == 1)
                        {
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Pen", correctAnswer[i]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    oldWeights[0] = weights[0];
                    oldWeights[1] = weights[1];
                    weights[0] = WeightChange(correctThings[j], diameter[j], learningRate);
                    weights[0] = WeightChange(correctThings[j], length[j], learningRate);
                    for (int i = 0; i < 8; i++)
                    {
                        result[i] = ((diameter[i] * weights[0]) + (length[i] * weights[1])) + mutaion;
                        if (result[i] > 0 && correctAnswer[i] == 1)
                        {
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Ring", correctAnswer[i]);
                        }
                        if (result[i] > 0 && correctAnswer[i] == 2)
                        {
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Ring", correctAnswer[i]);
                        }
                        if (result[i] < 0 && correctAnswer[i] == 2)
                        {
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Pen", correctAnswer[i]);
                        }
                        if (result[i] < 0 && correctAnswer[i] == 1)
                        {
                            Console.WriteLine(result[i] + " My aswer: {0}, computer answer: Pen", correctAnswer[i]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
        public static double WeightChange(int correctThing, double weigth, double learningRate)
        {
            double result=correctThing*weigth*learningRate;            
            return result;
        }
    }
}