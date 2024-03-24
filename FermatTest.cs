using test.RemCalculatorLib;

namespace test.FermatTest;
class FermatTester
{
    static public bool FermatPrimalityTest(int arg)
    {
        Random random = new Random();
        List<int> numbersForTest = new List<int>();
        int temp;
        long power;
        
        //Make list numbers to test
        while (numbersForTest.Count() < (100))
        {
            temp = random.Next(2, arg-1);
            if(!numbersForTest.Contains(temp))
                numbersForTest.Add(temp);
        }

        //Test argument is prime or not
        foreach(int a in numbersForTest)
        {
            power = RemCalculator.RemWithPower(a, arg-1, arg);
            if(power != 1)
                return false;
        }

        return true;
    }
}