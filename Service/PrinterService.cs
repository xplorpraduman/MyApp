using MyApp.Interface;

namespace MyApp.Service
{
    public class Printer : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }
}
