using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using test.FermatTest;
using test.RemCalculatorLib;
using test.RSALib;

namespace test;
class Program
{
    public static void Main(string[] arg)
    {
        int p1 = 0;
        int temp = 0;
        Random random = new Random();
        bool isPrime1 = false;
        bool isPrime2 = false;

        while (!isPrime1)
        {
            p1 = random.Next(10000, 99999);
            if (p1 % 2 == 0) p1++;
            isPrime1 = FermatTester.FermatPrimalityTest(p1);
            isPrime2 = FermatTester.FermatPrimalityTest(p1);
        }

        Console.WriteLine($"Number: {p1}, isPrime1: {isPrime1}, isPrime2: {isPrime2}");


    }
}



