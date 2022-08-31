using System;
using System.Security.Cryptography.X509Certificates;

namespace A.I.neural.network
{
    class program
    {
        static void Main(string[] Args)
        {
            int[] diameter = new int[8];
            int[] lenght = new int[8];
            for(int i = 0; i <= 8; i++)
            {
                diameter[i] = int.TryParse(Console.ReadLine());
            }
        }
    }
}