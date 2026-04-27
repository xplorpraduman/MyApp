namespace MyApp.Service
{
    public class DelegateService
    {
        public string SayMorning(string name)
        {
            return $"Good Morning {name}";
        }

        public string SayEvening(string name)
        {
            return $"Good Evening {name}";
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public bool IsAdult(int age)
        {
            return age >= 18;
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
