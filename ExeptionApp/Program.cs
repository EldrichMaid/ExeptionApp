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
            catch (System.DivideByZeroException)
            {
                Console.WriteLine("На ноль делить нельзя!");
            }
            finally
            {
                Console.WriteLine("Блок Finally сработал!");
            }

            Console.ReadKey();            
        }
    }
}
