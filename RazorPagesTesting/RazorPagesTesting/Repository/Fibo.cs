namespace RazorPagesTesting.Repository
{
    public class FibonacciGenerator
    {
        public int GetFibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("Input must be non-negative");

            if (n == 0) return 0;
            if (n == 1) return 1;

            int a = 0, b = 1, c = 0;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }
}