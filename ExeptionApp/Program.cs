﻿namespace ExeptionApp
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

        delegate void DelegatedCalculation(int a, int b);

        static void Subtract(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void ShowMessage()
        {
            Console.WriteLine("'Sup,World!");
        }

        static int Summarize(int a, int b, int c)
        {
            return a + b + c;
        }

        static bool CheckLength(string _row)
        {
            if (_row.Length > 3) return true;
            return false;
        }

        delegate void ShowMessageDelegate();
        delegate int SummarizeDelegate(int a, int b, int c);
        delegate bool CheckLengthDelegate(string row);

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

            DelegatedCalculation calcDelegate = Subtract;
            calcDelegate += Add;
            calcDelegate -= Add;
            calcDelegate.Invoke(100, 50);

            ShowMessageDelegate showMessageDelegate = ShowMessage;
            showMessageDelegate.Invoke();

            SummarizeDelegate summarizeDelegate = Summarize;
            int SummarizedResult = sumDelegate.Invoke(1, 20, 300);
            Console.WriteLine(SummarizedResult);

            CheckLengthDelegate checkLengthDelegate = CheckLength;
            bool status = checkLengthDelegate.Invoke("Ataraxis");
            Console.WriteLine(status);


            Console.ReadKey();            
        }
    }
}
