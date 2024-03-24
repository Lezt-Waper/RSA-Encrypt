using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.FermatTest;

namespace test.RSALib
{
    public class RSA
    {
        private int p1, p2;
        private int privateKey;
        public int N {  get; set; }
        public int publicKey { get; set; }

        public RSA() 
        {
            p1 = 0;
            p2 = 0;

        }

        public async void Initial()
        {
            p1 = await GeneratePrimes();
            p2 = await GeneratePrimes();
            N = p1 * p2;
        }

        public static async Task<int> GeneratePrimes()
        {
            int p1 = 0;
            int temp = 0;
            Random random = new Random();
            bool isPrime1 = false;

            while (!isPrime1)
            {
                p1 = random.Next(10000, 15000);
                if (p1 % 2 == 0) p1++;
                isPrime1 = FermatTester.FermatPrimalityTest(p1);
            }

            return p1;
        }
        
    }
}
