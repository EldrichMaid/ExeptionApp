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

    class Car { }
    class Lexus : Car { }

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

        delegate void GreatTheWorld(string _message);
      
        delegate int RandomNumberDelegate();

        public delegate Car CovariantDelegation();
        public static Car CarMethod()
        {
            return null;
        }
        public static Lexus LexusMethod()
        {
            return null;
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

            DelegatedCalculation calcDelegate = Subtract;
            calcDelegate += Add;
            calcDelegate -= Add;
            calcDelegate.Invoke(100, 50);

            Action showMessageDelegate = ShowMessage;
            showMessageDelegate.Invoke();

            Func<int, int, int, int> SummarizeDelegate = Sum; // Первые три параметра - входные,последний - выходной.
            int SumarizedResult = SummarizeDelegate.Invoke(1, 30, 120);
            Console.WriteLine(SumarizedResult);

            Predicate<string> checkLengthDelegate = CheckLength; // Только один параметр на вход и один bool на выход.
            bool status = checkLengthDelegate.Invoke("Ataraxis");
            Console.WriteLine(status);

            GreatTheWorld Greatings = delegate (string _message)
            {
                Console.WriteLine(_message);
            };
            Greatings.Invoke("Hello World!");

            RandomNumberDelegate randomNumberDelegate = delegate
            {
                return new Random().Next(0, 100);
            };
            int RandomResult = randomNumberDelegate.Invoke();
            Console.WriteLine(RandomResult);

            GreatTheWorld GreatAsLambda = (string _message) =>
            {
                Console.WriteLine(_message);
            };
            GreatAsLambda.Invoke("Hello World!");

            RandomNumberDelegate RandomDelegateAsLambda = () =>
            {
                return new Random().Next(0, 100);
            };
            int LambdaResult = RandomDelegateAsLambda.Invoke();
            Console.WriteLine(LambdaResult);

            CovariantDelegation Lexus = LexusMethod;


            Console.ReadKey();            
        }
    }
}
