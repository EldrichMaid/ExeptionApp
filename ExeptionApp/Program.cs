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
        static void Main()
        {
            Exception exception = new Exception();
            exception.Data.Add("Дата исключения : ", DateTime.Now);

            Exception AnotherException = new("Собственное исключения") {HelpLink = "www.google.com"};
        }
    }
}
