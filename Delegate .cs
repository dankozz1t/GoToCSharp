namespace GoToCSharp
{
    delegate int CalcDelegate(int a, int b);

    class Calc
    {


        public int Add(int a, int b)
        {
            return a + b;
        }

        public static int Diff(int a, int b)
        {
            return a - b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }

    }

}