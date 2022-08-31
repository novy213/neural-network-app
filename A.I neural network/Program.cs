using System;
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

            Random r = new Random();
            double[] weights = { -2, 0,1};
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
            }
            Console.WriteLine();
            Console.WriteLine();
            for(int i = 0; i < 8; i++)
            {
                result[i] = (diameter[i] * weights[0]) + (length[i] * weights[1])+mutaion;
                if (result[i] > 0 && correctAnswer[i] == 1)
                {
                    Console.WriteLine(result[i] + " Correct Ring");
                }
                if (result[i] > 0 && correctAnswer[i] == 2)
                {
                    Console.WriteLine(result[i] + " Incorrect Ring");
                }
                if (result[i] < 0 && correctAnswer[i] == 2)
                {
                    Console.WriteLine(result[i] + " Correct Pen");
                }
                if (result[i] < 0 && correctAnswer[i] == 1)
                {
                    Console.WriteLine(result[i] + " Incorrect Pen");
                }
            }
        }
    }
}