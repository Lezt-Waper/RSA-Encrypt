using System.Data.Common;

namespace RSA_Encrypt.RSACalculatorLib;

class RSACalculator
{
    //Function for testing prime number
    static public bool FermatPrimalityTest(int arg)
    {
        Random random = new Random();
        List<int> numbersForTest = new List<int>();
        int temp;
        long power;

        //Make list numbers to test
        while (numbersForTest.Count() < (100))
        {
            temp = random.Next(2, arg - 1);
            if (!numbersForTest.Contains(temp))
                numbersForTest.Add(temp);
        }

        //Test argument is prime or not
        foreach (int a in numbersForTest)
        {
            power = RSACalculator.RemWithPower(a, arg - 1, arg);
            if (power != 1)
                return false;
        }

        return true;
    }

    //Caculate the modulo of arg in ring divisor with the power
    static public long RemWithPower(long arg, long power, long divisor)
    {
        long result = 1;

        //Temp is modulo of arg^(2^n) in ring divisor, base case is n = 0
        long temp = arg % divisor;

        while (power != 0)
        {
            //Check if power have 2^n
            if ((power % 2) == 1)
            {
                //Add the temp to the result
                result = ((result % divisor) * (temp % divisor)) % divisor;
            }

            //Compute the modulo of arg^(2^(n+1)) in ring divisor
            temp = ((temp % divisor) * (temp % divisor)) % divisor;

            //Go to next step n+1
            power /= 2;
        }
        return result;
    }

    //Find GCD of two number
    static public long GCD(long arg1, long arg2)
    {
        long temp;

        if (arg1 < arg2)
        {
            arg2 = arg2 % arg1;
        }

        while (arg2 != 0)
        {
            arg1 = arg1 % arg2;

            temp = arg1;
            arg1 = arg2;
            arg2 = temp;
        }

        return arg1;
    }

    //Find the inverse number of arg1 in ring arg2
    static public long Inverse(long arg1, long arg2)
    {
        long old_r = arg2, r = arg1;
        long old_t = 0, t = 1;
        long quotient = 0;
        long temp;

        while (r != 0)
        {
            quotient = old_r / r;

            //Compute new r
            temp = old_r;
            old_r = r;
            r = temp - quotient * r;

            //Compute new t
            temp = old_t;
            old_t = t;
            t = temp - quotient * t;
        }

        if (old_r > 1)
        {
            return -1;
        }
        if (old_t < 0)
        {
            old_t = old_t + arg2;
        }

        return old_t;
    }

    //Find the Bézout coefficients of arg1 and arg2
    static public Comb Puverizer(long arg1, long arg2)
    {
        long old_r = arg1, r = arg2;
        long old_s = 1, s = 0;
        long old_t = 0, t = 1;
        long quotient = 0;
        long temp;

        while (r != 0)
        {
            quotient = old_r / r;

            //Comput new r
            temp = old_r;
            old_r = r;
            r = temp - quotient * r;

            //Compute new s
            temp = old_s;
            old_s = s;
            s = temp - quotient * s;

            //Compute new t
            temp = old_t;
            old_t = t;
            t = temp - quotient * t;
        }

        return new Comb(old_s, old_t);
    }

    public record Comb(long a, long b);
}