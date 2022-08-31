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
            for (int i = 0; i < 9; i++)
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
            
        }
    }
}