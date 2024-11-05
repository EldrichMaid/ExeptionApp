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
            
        }
    }
}
