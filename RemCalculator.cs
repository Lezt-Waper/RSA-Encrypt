using System.Data.Common;

namespace test.RemCalculatorLib;

class RemCalculator
{
    static public int RemWithPower(int arg, int power, int divisor)
    {
        long result = 1;
        long temp = arg % divisor;

        while (power != 0)
        {
            if ((power % 2) == 1)
            {
                result = (result * temp) % divisor;
            }

            temp = (temp % divisor) * (temp % divisor);
            power /= 2;
        }
        return (int) result;
    }

    static public int GCD(int arg1, int arg2)
    {
        int temp;

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

    static public Comb Pulverizer(int arg1, int arg2)
    {
        List<Comb> combs = new List<Comb>();
        combs.Add(new Comb(1, 0));
        combs.Add(new Comb(0, 1));

        int temp, quote, step = 2;

        //if (arg1 < arg2)
        //{
        //    temp = arg1;
        //    arg1 = arg2;
        //    arg2 = temp;
        //}

        while (true)
        {
            quote = arg1 / arg2;
            arg1 = arg1 % arg2;

            if (arg1 == 0 || arg2 == 0)
                break;

            combs.Add(new Comb(combs[step - 2].a - quote * combs[step - 1].a, combs[step - 2].b - quote * combs[step - 1].b));

            temp = arg1;
            arg1 = arg2;
            arg2 = temp;

            step++;
        }

        return combs[step - 1];
    }

    public record Comb(int a, int b);
}