namespace ExeptionApp
{
    public class MyException : Exception
    {
        public MyException()
        { }

        public MyException(string message)
            : base(message)
        { }
    }
    internal class Program
    {
        static int Division(int a, int b)
            {
                return a / b;
            }

        public delegate int SumDelegate(int a, int b, int c);

        static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }

        delegate int DelegatedSubtraction(int a, int b);

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static void Main()
        {
            Exception exception = new Exception();
            exception.Data.Add("Дата исключения : ", DateTime.Now);

            Exception AnotherException = new("Собственное исключения") {HelpLink = "www.google.com"};

            try
            {
                int result = Division(7, 0);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                if (ex is DivideByZeroException) Console.WriteLine("На ноль делить нельзя!");
                else Console.WriteLine("Произошла непредвиденная ошибка в приложении.");
            }
            finally
            {
                Console.WriteLine("Блок Finally сработал!");
            }

            try
            {
                throw new ArgumentOutOfRangeException("Argument out of range error thrown");
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                throw new RankException("Rank error thrown");
            }

            catch (RankException ex)
            {
                Console.WriteLine(ex.GetType());
            }

            SumDelegate sumDelegate = Sum;
            sumDelegate.Invoke(1, 10, 50);

            DelegatedSubtraction calcDelegate = Subtract;
            int SubtractionResult = calcDelegate(100, 50);
            Console.WriteLine(SubtractionResult);
            int SubtractionInvokation = calcDelegate.Invoke(100, 50);
            Console.WriteLine(SubtractionInvokation);

            Console.ReadKey();            
        }
    }
}
